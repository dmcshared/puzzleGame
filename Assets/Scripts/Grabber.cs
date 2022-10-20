namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;

    public class Grabber : MonoBehaviour
    {
        public Rigidbody grabbed = null;

        private void Update()
        {
            if (grabbed == null && Input.GetKey(KeyCode.E))
            {
                var grabbableCandidates = Physics.OverlapSphere(transform.position, transform.localScale.x);
                foreach (var grabbableCandidate in grabbableCandidates)
                {
                    grabbed = grabbableCandidate.GetComponent<Rigidbody>();
                    if (!(grabbed == null)) break;
                }
            }
            if (!(grabbed == null) && !Input.GetKey(KeyCode.E))
            {
                grabbed = null;
            }
        }

        private void FixedUpdate()
        {

            if (!(grabbed == null))
            {
                // Apply spring force
                grabbed.AddForce((transform.position - grabbed.position) * 100.0f, ForceMode.Acceleration);
                grabbed.AddForce((grabbed.velocity) * -4.0f, ForceMode.Acceleration);
            }

        }

    }
}