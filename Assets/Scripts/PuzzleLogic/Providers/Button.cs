namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;

    public class Button : Provider
    {
        public Collider buttonCollider;
        public int collisionCount = 0;


        private void Start()
        {
            if (!buttonCollider) buttonCollider = GetComponent<Collider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            collisionCount++;
            if (collisionCount == 1)
            {
                Consume();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            collisionCount--;
        }

        public override bool isProviding()
        {
            return collisionCount > 0;
        }
    }
}