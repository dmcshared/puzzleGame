
namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class AddPoint : PassiveConsumer
    {

        public override void Consume()
        {
            Universal.Instance.GetComponent<PointManager>().AddPoint();
        }

        private void Update()
        {

        }
    }
}