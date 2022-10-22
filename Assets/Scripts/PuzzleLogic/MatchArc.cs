using UnityEngine;

namespace DaMastaCoda.PuzzleGame
{
    public class MatchArc : UnityEngine.MonoBehaviour
    {
        Rigidbody rb;
        public Vector3 initalPosition;
        public Vector3 initialVelocity;
        public Vector3 acceleration;

        public float timeLimit;

        public float time = 0.0f;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            time = 0.0f;
        }

        private void FixedUpdate()
        {
            if (timeLimit < 0)
            {
                Destroy(this);
            }

            timeLimit -= Time.fixedDeltaTime;
            time += Time.fixedDeltaTime;

            rb.velocity = initialVelocity + acceleration * time;
            rb.position =
                initalPosition + initialVelocity * time + 0.5f * acceleration * time * time;
        }
    }
}
