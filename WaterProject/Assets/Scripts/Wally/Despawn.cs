using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QWERWIN
{
    public class Despawn : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.tag == "Player")
            {
                collision.gameObject.SetActive(false);
            }
        }
    }
}

