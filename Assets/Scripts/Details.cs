using UnityEngine;

namespace DaMastaCoda
{
    public class Details : MonoBehaviour
    {
        public GameObject[] detailPrefabs;

        public Transform topLeftPoint;
        public Transform topRightPoint;
        public Transform bottomLeftPoint;
        public Transform bottomRightPoint;

        public int count = 100;

        private void Start()
        {
            for (var i = 0; i < count; i++)
            {
                Detail();
            }
        }

        void Detail()
        {
            var position = Vector3.Lerp(
                Vector3.Lerp(
                    topLeftPoint.position,
                    topRightPoint.position,
                    Random.Range(0.0f, 1.0f)
                ),
                Vector3.Lerp(
                    bottomLeftPoint.position,
                    bottomRightPoint.position,
                    Random.Range(0.0f, 1.0f)
                ),
                Random.Range(0.0f, 1.0f)
            );

            var obj = detailPrefabs[Random.Range(0, detailPrefabs.Length)];

            var newObj = Instantiate(obj, position, obj.transform.rotation);
            newObj.transform.SetParent(transform);
            newObj.transform.RotateAround(position, Vector3.up, Random.Range(-180.0f, 180.0f));
            newObj.transform.localScale = transform.localScale;
            // newObj.transform.RotateAround(position, Vector3.right, Random.Range(-20.0f, 20.0f));
            // newObj.transform.RotateAround(position, Vector3.up, Random.Range(-180.0f, 180.0f));
        }
    }
}