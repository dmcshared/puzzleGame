namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;

    public abstract class PassiveConsumer : Consumer
    {
        public abstract void Consume();

        private void Awake()
        {
            foreach (var provider in providers)
            {
                provider.addPassiveConsumer(
                    this
                    );
            }
        }

        private void OnDestroy()
        {

            foreach (var provider in providers)
            {
                provider.removePassiveConsumer(
                    this
                    );
            }
        }
    }
}