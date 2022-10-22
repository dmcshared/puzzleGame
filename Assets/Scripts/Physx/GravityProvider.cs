using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaMastaCoda.Gravity
{
    public abstract class GravityProvider : MonoBehaviour
    {
        List<GravityHandler> masses = new List<GravityHandler>();
        public Collider gravityTrigger;

        private void Start()
        {
            if (gravityTrigger == null)
            {
                gravityTrigger = GetComponent<Collider>();
                gravityTrigger.isTrigger = true;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            var isGravd = other.GetComponentInParent<GravityHandler>();

            if (isGravd != null)
            {
                masses.Add(isGravd);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var isGravd = other.GetComponentInParent<GravityHandler>();

            if (isGravd != null)
            {
                masses.Remove(isGravd);
            }
        }

        private void FixedUpdate()
        {
            foreach (var mass in masses)
            {
                mass.AddAcceleration(CalcAcceleration(mass));
            }
        }

        public abstract Vector3 CalcAcceleration(GravityHandler mass);
    }
}
