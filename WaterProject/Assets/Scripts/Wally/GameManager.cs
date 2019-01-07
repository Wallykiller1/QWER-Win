using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pooling;

namespace QWERWIN
{
    public class GameManager : MonoBehaviour
    {

        [SerializeField]
        private List<PoolingObject> m_PoolObjects;

        [SerializeField]
        private List<GameObject> m_People;
        public List<GameObject> People
        {
            get { return m_People; }
        }
        [SerializeField]
        private List<GameObject> m_Bottle;
        public List<GameObject> Bottle
        {
            get { return m_Bottle; }
        }

        [SerializeField]
        private List<Transform> m_Spawns;
        public List<Transform> Spawns
        {
            get { return m_Spawns; }
        }

        [SerializeField]
        private float m_Timer;

        GameObject m_PoolName;

        void Start()
        {
            m_People = new List<GameObject>();
            m_Bottle = new List<GameObject>();

            for (int p = 0; p < m_PoolObjects.Count; p++)
            {
                m_PoolName = GameObject.Find("Pool" + " " + m_PoolObjects[p].ObjectType.name);
                if (m_PoolName == null)
                {
                    m_PoolName = new GameObject("Pool" + " " + m_PoolObjects[p].ObjectType.name);
                }


                for (int i = 0; i < m_PoolObjects[0].Amount; i++)
                {
                    {
                        GameObject obj = (GameObject)Instantiate(m_PoolObjects[p].ObjectType);
                        obj.transform.parent = m_PoolName.transform;
                        obj.SetActive(false);
                        m_People.Add(obj);
                    }
                }
                for (int i = 0; i < m_PoolObjects[1].Amount; i++)
                {
                    {
                        GameObject obj = (GameObject)Instantiate(m_PoolObjects[p].ObjectType);
                        obj.transform.parent = m_PoolName.transform;
                        obj.SetActive(false);
                        m_Bottle.Add(obj);
                    }
                }
                
            }
        }

        // Update is called once per frame
        void Update()
        {
            m_Timer -= Time.deltaTime;
            if(m_Timer <= 0)
            {
                SpawnHumans();
                m_Timer = Random.Range(2f, 10f);
            }
        }

        void SpawnHumans()
        {
            int _Random = Random.Range(0, m_Spawns.Count);
            for (int i = 0; i < m_People.Count; i++)
            {
                if (!m_People[i].activeInHierarchy)
                {
                    m_People[i].transform.position = m_Spawns[_Random].transform.position;
                    if (m_Spawns[_Random].transform.rotation.y == 180f)
                    {
                        m_People[i].GetComponent<People>().Side = 1;
                        m_People[i].transform.rotation = Quaternion.Euler(0, 180, 0);
                    }
                    else
                    {
                        m_People[i].GetComponent<People>().Side = 2;
                    }
                    m_People[i].SetActive(true);
                    break;
                    
                }
            }
        }

        public void ThrowBottle(GameObject _Object, int _Side)
        {
            for (int i = 0; i < m_Bottle.Count; i++)
            {
                if (!m_Bottle[i].activeInHierarchy)
                {
                    m_Bottle[i].transform.position = _Object.transform.position;
                    m_Bottle[i].transform.rotation = _Object.transform.rotation;
                    m_Bottle[i].SetActive(true);
                    break;

                }
            }
        }





    }

}
