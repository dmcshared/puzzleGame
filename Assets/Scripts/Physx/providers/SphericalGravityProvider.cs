using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaMastaCoda.Gravity
{
    public class SphericalGravityProvider : GravityProvider
    {

        public float strength = 5.0f;

        public override Vector3 CalcAcceleration(GravityHandler mass)
        {
            Vector3 direction = transform.position - mass.transform.position;

            return direction.normalized * strength;
        }
    }
}