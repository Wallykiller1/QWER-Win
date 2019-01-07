using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QWERWIN
{
    public class PickupObject : MonoBehaviour
    {

        [SerializeField]
        private float m_Distance = 20;

        void Update()
        {

        }

        private void OnMouseDrag()
        {
            if(Input.GetKey(KeyCode.Mouse1))
            {
                m_Distance = 15;
            }
            else
            {
                m_Distance = 25;
            }

            Vector3 _MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_Distance);
            Vector3 _ObjPos = Camera.main.ScreenToWorldPoint(_MousePos);

            transform.position = _ObjPos;
            transform.rotation = transform.rotation;
        }
    }
}

