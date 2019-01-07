using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QWERWIN
{
    public class People : MonoBehaviour
    {
        [SerializeField]
        private float m_MoveSpeed;

        [SerializeField]
        private GameManager m_GameManager;

        private Rigidbody m_Rbody;

        private Vector3 m_Force;

        [SerializeField]
        private int m_Side;
        public int Side
        {
            get { return m_Side; }
            set { m_Side = value; }
        }


        private float m_Timer;

        void Start()
        {
            m_Rbody = gameObject.GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            m_Timer = Random.Range(1f,10f);
        }

        // Update is called once per frame
        void Update()
        {
            m_Timer -= Time.deltaTime;

            transform.Translate(m_MoveSpeed * Time.deltaTime, 0, 0);

            if (m_Side == 1)
            {
                if (m_Timer <= 0)
                    Throw();
            }
            if (m_Side == 2)
            {

                if (m_Timer <= 0)
                    Throw();
            }
        }
        void Throw()
        {
            if(m_Side == 1)
            {
                m_GameManager.ThrowBottle(gameObject, 1);
            }
            if(m_Side == 2)
            {
                m_GameManager.ThrowBottle(gameObject, 2);
            }
        }
    }
}

