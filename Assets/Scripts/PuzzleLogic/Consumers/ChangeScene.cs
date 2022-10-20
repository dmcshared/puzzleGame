namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class ChangeScene : PassiveConsumer
    {
        [Scene]
        public string targetScene;

        public override void Consume()
        {
            Debug.Log("hi");
            SceneManager.LoadScene(targetScene);
        }

        private void Update()
        {

        }
    }
}