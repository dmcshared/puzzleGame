using System;
using UnityEngine;

//p\left(x\right)=-\arctan\left(\frac{-x+\sqrt{x^{2}-4\frac{gx^{2}}{2s^{2}}\left(\frac{gx^{2}}{2s^{2}}+b_{y}\right)}}{\frac{gx^{2}}{s^{2}}}\right)

namespace DaMastaCoda.PuzzleGame
{
    public class ShootObject : PassiveConsumer
    {
        public GameObject target;
        public float strength = 20.0f;

        public override void Consume()
        {
            var overlaps = Physics.OverlapBox(transform.position, transform.localScale);

            foreach (var item in overlaps)
            {
                var rb = item.GetComponentInParent<Rigidbody>();
                var fps = item.GetComponentInParent<FirstPersonController>();

                if (rb)
                {
                    var hDistance = Mathf.Pow(
                        Mathf.Pow(rb.position.x - target.transform.position.x, 2)
                            + Mathf.Pow(rb.position.z - target.transform.position.z, 2),
                        0.5f
                    );
                    var vDistance = target.transform.position.y - rb.position.y;

                    var direction = new Vector3(
                        rb.position.x - target.transform.position.x,
                        0,
                        rb.position.z - target.transform.position.z
                    ).normalized;
                    var up = Vector3.up;

                    var forceAngle = calculateForce(hDistance, vDistance);

                    var totalForce =
                        (direction * -Mathf.Cos(-forceAngle) + up * Mathf.Sin(-forceAngle))
                        * strength;

                    var upForce = Mathf.Sin(-forceAngle) * strength;

                    Debug.Log(totalForce);

                    rb.velocity = totalForce;

                    if (fps)
                    {
                        fps.physControl = upForce / Physics.gravity.y * -2.0f;
                    }

                    var matchArc = rb.gameObject.AddComponent<MatchArc>();
                    matchArc.timeLimit = upForce / Physics.gravity.y * -2.0f - 0.5f;
                    matchArc.initalPosition = rb.position;
                    matchArc.initialVelocity = totalForce;
                    matchArc.acceleration = Physics.gravity;
                }
            }
        }

        private float calculateForce(float hDistance, float vDistance)
        {
            var g = Physics.gravity.y;
            var r = (g * hDistance * hDistance) / (2 * strength * strength);

            return -Mathf.Atan(
                (-hDistance - Mathf.Sqrt(hDistance * hDistance - 4 * r * (r + vDistance)))
                    / (r * 2.0f)
            );
        }
    }
}
