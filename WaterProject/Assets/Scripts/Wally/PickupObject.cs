using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QWERWIN
{
    public class PickupObject : MonoBehaviour
    {

        private float m_Distance = 10;

        private void OnMouseDrag()
        {
            Vector3 _MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_Distance);
            Vector3 _ObjPos = Camera.main.ScreenToWorldPoint(_MousePos);

            transform.position = _ObjPos;
            transform.rotation = transform.rotation;
        }
    }
}

