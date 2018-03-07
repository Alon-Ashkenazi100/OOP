using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Moving : MonoBehaviour
    {
        #region Variables
        public float acceleration = 5f;
        public float rotationSpeed = 5f;
        public float maxVelocity = 3f;

        private Rigidbody2D rigid;
        #endregion

        #region Methods/Functions
        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            LimitVelocity();
        }

        // Capping the velocity when it goes too high
        void LimitVelocity()
        {
            // Made a copy of rigid.velocity
            Vector3 vel = rigid.velocity;
            // Checking copy to see if it's too high
            if (vel.magnitude > maxVelocity)
            {
                // Capping velocity down to maxVelocity
                vel = vel.normalized * maxVelocity;
            }
            // Applies the copied variable to velocity
            rigid.velocity = vel;
        }

        public void Accelerate(Vector3 direction)
        {
            rigid.AddForce(direction * acceleration);
        }

        public void Rotate(float angleOffset)
        {
            rigid.rotation -= angleOffset * rotationSpeed * Time.deltaTime;
        }

        // Rotates the player left
        public void RotateLeft()
        {
            rigid.rotation += rotationSpeed * Time.deltaTime;
        }
        // Rotates the player right
        public void RotateRight()
        {
            rigid.rotation -= rotationSpeed * Time.deltaTime;
        }
        #endregion
    }
}