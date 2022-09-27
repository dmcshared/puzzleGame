using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaMastaCoda
{
    public class Randomize : MonoBehaviour
    {
        public float rotationLimit = 90.0f;
        public Vector3 rotationAxis = new Vector3(0.0f, 1.0f, 0.0f);


        // Start is called before the first frame update
        void Start()
        {
            transform.RotateAround(transform.position, rotationAxis, Random.Range(-rotationLimit, rotationLimit));
        }

    }
}