using System;
using UnityEngine;

namespace DaMastaCoda.Gravity.PC.v1
{
    public class PlayerController : MonoBehaviour
    {
        GravityHandler gh;
        public float speed = 2.0f;
        public float sprintMultiplier = 4.0f;
        public float crouchMultiplier = 0.3f;
        public float slideDrag = 0.2f;
        public float crouchDrag = 1.0f;
        public float mouseSpeed = 8.0f;

        public Collider nonCrouchCollider;

        Rigidbody rb;

        Transform hinge;

        public bool isGrounded = false;

        private float getSpeedMultiplier()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                return sprintMultiplier;
            }
            else if (Input.GetKey(KeyCode.LeftControl) && rb.velocity.magnitude > 1.0f)
            {
                return crouchMultiplier;
            }
            else
            {
                return 1.0f;
            }
        }

        private float getDragMultiplier()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                return rb.velocity.magnitude > 1.0f ? slideDrag : crouchDrag;
            }
            else
            {
                return 1.0f;
            }
        }

        private void Start()
        {
            gh = GetComponent<GravityHandler>();
            rb = GetComponent<Rigidbody>();
            hinge = gameObject.GetComponentInChildren<Camera>().transform.parent;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            UpdateHFacing(mouseSpeed * Input.GetAxisRaw("Mouse X"));
            UpdateVFacing(mouseSpeed * Input.GetAxisRaw("Mouse Y"));

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(
                    transform.up * (15.0f + Mathf.Pow(rb.velocity.magnitude, 0.5f)),
                    ForceMode.Impulse
                );
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                nonCrouchCollider.enabled = false;
                hinge.localPosition = Vector3.Lerp(
                    hinge.localPosition,
                    new Vector3(0.0f, 0.5f, 0.0f),
                    12.0f * Time.deltaTime
                );
            }
            else
            {
                nonCrouchCollider.enabled = true;
                hinge.localPosition = Vector3.Lerp(
                    hinge.localPosition,
                    new Vector3(0.0f, 1.5f, 0.0f),
                    12.0f * Time.deltaTime
                );
            }
        }

        private void FixedUpdate()
        {
            UpdateMovement();
            UpdateGrounded();

            if (isGrounded)
                ApplyLinearDrag();
        }

        private void ApplyLinearDrag()
        {
            rb.AddForce(-rb.velocity * 5.6f * getDragMultiplier(), ForceMode.Acceleration);
        }

        private void UpdateGrounded()
        {
            isGrounded = Physics.Raycast(
                transform.position + transform.up * 0.1f,
                -transform.up,
                .5f
            );
        }

        private void UpdateMovement()
        {
            var accel =
                Input.GetAxis("Vertical") * transform.forward
                + Input.GetAxis("Horizontal") * transform.right;

            rb.AddForce(
                accel * speed * (isGrounded ? getSpeedMultiplier() : 0.2f),
                ForceMode.Acceleration
            );
        }

        private void UpdateHFacing(float hMovement)
        {
            var facing = transform.forward;
            var right = Vector3.Cross(facing, gh.currentDown);
            var new_facing = (Vector3.Cross(gh.currentDown, right) + right * hMovement).normalized;

            var targetRot = Quaternion.LookRotation(new_facing, -gh.currentDown);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRot,
                7.0f * Time.deltaTime
            );
        }

        private void UpdateVFacing(float vMovement)
        {
            var facing = hinge.forward;
            var up = hinge.up;
            var new_facing = (Vector3.Cross(hinge.right, up) + up * vMovement).normalized;

            var targetRot = Quaternion.LookRotation(
                new_facing,
                Vector3.Cross(-hinge.right, new_facing)
            );

            hinge.rotation = Quaternion.Slerp(hinge.rotation, targetRot, 7.0f * Time.deltaTime);

            if (
                hinge.localRotation.eulerAngles.x > 80.0f
                && hinge.localRotation.eulerAngles.x < 180.0f
            )
            {
                hinge.localRotation = Quaternion.Euler(80.0f, 0.0f, 0.0f);
            }
            else if (
                hinge.localRotation.eulerAngles.x < 280.0f
                && hinge.localRotation.eulerAngles.x > 180.0f
            )
            {
                hinge.localRotation = Quaternion.Euler(-80.0f, 0.0f, 0.0f);
            }
        }
    }
}
