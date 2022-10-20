using System;
using UnityEngine;


namespace DaMastaCoda.Gravity
{
    [RequireComponent(typeof(Rigidbody))]
    public class GravityHandler : MonoBehaviour
    {
        Vector3 previousAcceleration = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 currentDown = Vector3.down;
        Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            currentDown = previousAcceleration.normalized;

            rb.AddForce(previousAcceleration, ForceMode.Acceleration);

            previousAcceleration = new Vector3(0.0f, 0.0f, 0.0f);
        }

        internal void AddAcceleration(Vector3 accel)
        {
            previousAcceleration += accel;
        }
    }
}