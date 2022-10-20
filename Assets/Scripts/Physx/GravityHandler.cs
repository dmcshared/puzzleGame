using System;
using UnityEngine;


namespace DaMastaCoda.Gravity
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityHandler : MonoBehaviour
    {
        Vector3 previousAcceleration = new Vector3(0.0f, 0.0f, 0.0f);
        public Vector3 currentDown = Vector3.down;
        Rigidbody rb;

        public bool useStandardGravDefault = true;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
        }

        private void FixedUpdate()
        {
            if (previousAcceleration.magnitude == 0.0f)
                previousAcceleration = Physics.gravity;

            currentDown = previousAcceleration.normalized;

            rb.AddForce(previousAcceleration, ForceMode.Acceleration);

            previousAcceleration = new Vector3(0.0f, 0.0f, 0.0f);
        }

        internal void AddAcceleration(Vector3 accel)
        {
            previousAcceleration += accel;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawRay(transform.position, currentDown);

        }
    }
}