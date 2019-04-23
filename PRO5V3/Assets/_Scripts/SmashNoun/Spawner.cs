using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventCallbacks
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        public Dictionary<int, string> wordSets = new Dictionary<int, string>();
        private int MAX_OBJECTS = 0;

        // Use this for initialization
        void Start()
        {

        }

        public GameObject UnitPrefab;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (MAX_OBJECTS < 3)
                {
                    SpawnUnit();
                    MAX_OBJECTS++;
                }
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                MAX_OBJECTS = 0;
            }
        }

        void SpawnUnit()
        {
            float x = Random.Range(-4f, 4f);
            float z = Random.Range(-4f, 4f);
            float y = Random.Range(1f, 3f);
            GameObject go = Instantiate(UnitPrefab, new Vector3(x, y, z), Quaternion.identity);
        }
    }
}