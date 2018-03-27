using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ScreenWrap : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        // Camera
        private Bounds camBounds;
        private float camWidth;
        private float camHeight;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void UpdateCameraBounds()
        {
            // Calculate camera bounds
            Camera cam = Camera.main;
            camHeight = 2f * cam.orthographicSize;
            camWidth = camHeight * cam.aspect;
            camBounds = new Bounds(cam.transform.position, new Vector2(camWidth, camHeight));
        }

        // Update is called once per frame
        void LateUpdate()
        {
            // Update dimensions of camera bounds before checking stuff
            UpdateCameraBounds();
            // Store position and size in a shorter variable name
            Vector3 pos = transform.position;
            Vector3 size = spriteRenderer.bounds.size;
            // Calculate the sprite's half width and half height
            float halfWidth = size.x / 2f;
            float halfHeight = size.y / 2f;
            // Check left
            if (pos.x + halfWidth < camBounds.min.x)
            {
                pos.x = camBounds.max.x + halfWidth;
            }
            // Check right
            if (pos.x - halfWidth > camBounds.max.x)
            {
                pos.x = camBounds.min.x - halfWidth;
            }
            // Check up
            if (pos.y + halfHeight < camBounds.min.y)
            {
                pos.y = camBounds.max.y + halfHeight;
            }
            // Check down
            if (pos.y - halfHeight > camBounds.max.y)
            {
                pos.y = camBounds.min.y - halfWidth;
            }
            // Apply position
            transform.position = pos;
        }
    }
}