using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Breakout
{ 
    public class Ball : MonoBehaviour
    {
        public float speed = 5f; // Speed that the ball travels

        private Vector3 velocity; // Velocity of the ball (Direction X Speed)
	    
        // Fires off ball in a given direction
        public void Fire(Vector3 direction)
        {
            // Calculates velocity
            velocity = direction * speed;
        }

        // Detect collisions
        void OnCollisionsEnter2D(Collision2D other)
        {
            // Grab contact point of collision
            ContactPoint2D contact = other.contacts[0];
            // Calculate the reflection point of the ball using velocity & contact normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            // Calculate new velocity from reflection multiply by the same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;
        }

        private void Update()
        {
            // Moves ball using velocity &deltaTime
            transform.position += velocity * Time.deltaTime;
        }	
	}
}
