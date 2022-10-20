using System;
using UnityEngine;
namespace DaMastaCoda.Gravity.PC.v1
{
    public class PlayerController : MonoBehaviour
    {

        GravityHandler gh;
        public float speed = 2.0f;
        Rigidbody rb;

        private void Start()
        {
            gh = GetComponent<GravityHandler>();
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            UpdateFacing();

        }

        private void FixedUpdate()
        {
            UpdateMovement();

        }

        private void UpdateMovement()
        {
            var accel = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right;

            rb.AddForce(accel * speed, ForceMode.Acceleration);

        }

        private void UpdateFacing()
        {
            var facing = transform.forward;
            var right = Vector3.Cross(facing, gh.currentDown);
            var new_facing = Vector3.Cross(gh.currentDown, right);

            var targetRot = Quaternion.LookRotation(new_facing, -gh.currentDown);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 7.0f * Time.deltaTime);
        }
    }
}