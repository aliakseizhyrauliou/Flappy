using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assembly_CSharp
{
    public class Pipes : MonoBehaviour
    {
        public float spped = 5f;
        public float leftEdge;

        private void Start()
        {
            leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        }

        private void Update()
        {
            transform.position += Vector3.left * spped * Time.deltaTime;

            if (transform.position.x < leftEdge) 
            {
                Destroy(gameObject);
            }
        }
    }
}
