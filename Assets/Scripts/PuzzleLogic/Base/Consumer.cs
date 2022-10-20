namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;

    public abstract class Consumer : MonoBehaviour
    {
        public Provider[] providers;

        protected bool isProviding()
        {
            foreach (var provider in providers)
            {
                if (provider.isProviding()) return true;
            }
            return false;
        }
    }
}