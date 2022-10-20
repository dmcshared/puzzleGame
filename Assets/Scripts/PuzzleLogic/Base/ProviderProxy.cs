namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;

    public class ProviderProxy : Provider
    {

        public Provider originalProvider;
        public override bool isProviding()
        {
            return originalProvider.isProviding();
        }


        public new void addPassiveConsumer(PassiveConsumer consumer)
        {
            originalProvider.addPassiveConsumer(consumer);
        }

        public override void Consume()
        {
            originalProvider.Consume();
        }
    }
}