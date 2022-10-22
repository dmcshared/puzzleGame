using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaMastaCoda.Gravity
{
    public class SphericalGravityProviderCurved : GravityProvider
    {
        public AnimationCurve curve;

        public override Vector3 CalcAcceleration(GravityHandler mass)
        {
            Vector3 direction = transform.position - mass.transform.position;

            Debug.Log(direction.magnitude);

            return direction.normalized * curve.Evaluate(direction.magnitude);
        }
    }
}
