using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    public class Bullet : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D col)
        {
            
            // If we hit an asteroid
            if (col.name.Contains("Asteroid"))
            {

                // Destroy the asteroid
                Destroy(col.gameObject);
                //
                Destroy(this.gameObject);
            }
        }
    }
}