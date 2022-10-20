using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaMastaCoda.PuzzleGame
{
    public class Universal : MonoBehaviour
    {

        public static Universal Instance;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(this);
            }
        }
    }
}