
namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class DestroySelf : PassiveConsumer
    {

        public override void Consume()
        {

            Destroy(gameObject);
        }

        private void Update()
        {

        }
    }
}