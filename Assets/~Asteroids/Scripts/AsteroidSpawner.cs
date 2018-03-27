using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidSpawner : MonoBehaviour
    {
        public GameObject[] prefabs;
        public float minSpeed = 1f;
        public float maxSpeed = 5f;
        public float spawnRate = 1f;

        private float spawnTimer = 0f;

        // Camera
        private Bounds camBounds;
        private float camWidth;
        private float camHeight;

        // Use this for initialization
        void Start()
        {
            // Calculate camera bounds
            Camera cam = Camera.main;
            camHeight = 2f * cam.orthographicSize;
            camWidth = camHeight * cam.aspect;
            camBounds = new Bounds(cam.transform.position, new Vector2(camWidth, camHeight));
        }

        // Update is called once per frame
        void Update()
        {
            //Count up the timer
            spawnTimer += Time.deltaTime;
            if (spawnTimer > spawnRate)
            {
                // Spawn the new asteroid
                Spawn();
                // Reset the timer
                spawnTimer = 0;
            }
        }
        void Spawn()
        {
            #region Generate Random Position
            Vector3 position = Vector3.zero;
            float halfWidth = camWidth * 0.5f;
            float halfHeight = camHeight * 0.5f;

            // top/botttom (true)
            if (Random.Range(0, 2) > 0)
            {
                position.x = Random.Range(-halfWidth, halfWidth);

                // spawn at top (true) or bottom (false)
                if (Random.Range(0, 2) > 0)
                {
                    position.y = halfHeight;
                }
                else
                {
                    position.y = -halfHeight;
                }
            }
            else //or left/ right(false)
            {
                // spawn at left (true) or right (false)
                if (Random.Range(0, 2) > 0)
                {
                    position.x = halfWidth;
                }
                else
                {
                    position.x = -halfWidth;
                }
            }

            SpawnAtPosition(position);
        }
        #endregion

        public void SpawnAtPosition(Vector3 position)
        {
            // Select random asteroid
            int randIndex = Random.Range(0, prefabs.Length);
            GameObject asteroid = Instantiate(prefabs[randIndex], transform.position, transform.rotation);
            asteroid.transform.position = position;

            Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();
            float randomSpeed = Random.Range(minSpeed, maxSpeed);
            Vector2 randomDir = Random.onUnitSphere;
            rigid.AddForce(randomDir * randomSpeed, ForceMode2D.Impulse);
        }
    }
}



