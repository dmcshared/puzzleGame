namespace DaMastaCoda.PuzzleGame
{
    using UnityEngine;

    public class LerpTransform : Consumer
    {

        public GameObject restPosition;
        public GameObject activePosition;

        public float factor = 0.3f;


        private void Update()
        {
            if (isProviding())
            {
                transform.position = Vector3.Lerp(transform.position, activePosition.transform.position, factor);
                transform.localScale = Vector3.Lerp(transform.localScale, activePosition.transform.localScale, factor);
                transform.rotation = Quaternion.Lerp(transform.rotation, activePosition.transform.rotation, factor);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, restPosition.transform.position, factor);
                transform.localScale = Vector3.Lerp(transform.localScale, restPosition.transform.localScale, factor);
                transform.rotation = Quaternion.Lerp(transform.rotation, restPosition.transform.rotation, factor);

            }

        }
    }
}