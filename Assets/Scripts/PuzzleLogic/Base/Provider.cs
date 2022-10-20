namespace DaMastaCoda.PuzzleGame
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class Provider : MonoBehaviour
    {
        private HashSet<PassiveConsumer> passiveConsumers;

        private void Start()
        {
            // passiveConsumers = new HashSet<PassiveConsumer>();

        }

        public void addPassiveConsumer(PassiveConsumer consumer)
        {
            if (passiveConsumers == null)
                passiveConsumers = new HashSet<PassiveConsumer>();
            passiveConsumers.Add(consumer);
        }

        public void removePassiveConsumer(PassiveConsumer consumer)
        {
            if (passiveConsumers == null)
                return;
            passiveConsumers.Remove(consumer);
        }

        public abstract bool isProviding();
        public virtual void Consume()
        {
            if (passiveConsumers == null)
                passiveConsumers = new HashSet<PassiveConsumer>();

            foreach (var consumer in passiveConsumers)
            {
                consumer.Consume();
            }
        }
    }
}