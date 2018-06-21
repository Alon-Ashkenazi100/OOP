using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketScript : MonoBehaviour // A public class called BucketScript
{
    public float movementSpeed = 10.0f; // A public float called movementSpeed with a value of 10.0f

    private Rigidbody2D rigid2D; // A private Rigidbody2D called rigid2D
    private Renderer[] renderers; // A private Renderer called renderers

    // Use this for initialization
    void Start() // A method called Start
    {
        rigid2D = GetComponent<Rigidbody2D>(); // rigid2D is equal to GetComponent<Rigidbody2D>, to obtain it as a single variable
        renderers = GetComponentsInChildren<Renderer>(); // renderers is equal to GetComponentsInChildren<Renderer>, to obtrain it as an array
        // GetComponentsInChildren is used to call a function, used for getting multiple components from its children that are of type ‘Renderer’
    }

    // Update is called once per frame
    void Update() // A method called Update
    {
        HandlePosition();
        HandleBoundary();
    }
    // Handles bucket position
    void HandlePosition() // A method called HandlePosition
    {
        rigid2D.velocity = Vector3.left * movementSpeed;
    }   
    // Handles the screen boundaries for game object
    void HandleBoundary()
    {
        Vector3 transformPos = transform.position;
        // Get the viewport position of where the bucket is
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transformPos);
        // Is the GameObject visible from the camera on the left hand side of it?
        if (IsVisible() == false && viewportPos.x < 0)
        {
            Destroy(gameObject); // Then destroy the GameObject
        }
    }
        // Checks whether or not any renderer attached to this GameObject
        // and it's children is visible
        bool IsVisible() // A boolean called IsVisible
        {
            foreach (var renderer in renderers) // Using a foreach statement with the variable renderer in renderers
            {
                if (renderer.isVisible) // An if statement of renderer.IsVisible
                {
                    return true; // If ture, then return true
                }
            }
            return false; // If false, then return false

            // Using the renderers array by looping through and checking if any one of them is visible,
            // that way it can destroy the GameObject if that is partly the caes.
            // The other case is if the Bucket flies off to the left of the screen.
        }
    }
