using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaMastaCoda.Gravity
{
    public class DirectionalGravityProvider : GravityProvider
    {
        public float strength = 5.0f;

        public override Vector3 CalcAcceleration(GravityHandler mass)
        {
            return -transform.up * strength;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawRay(transform.position, -transform.up);
        }
    }
}
