using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour // A public class called PaddleScript 
{

    private Animator anim; // The Animator is a private variable and is called anim

	// Use this for initialization
	void Start () // A method called Start
    {
        anim = GetComponent<Animator>(); // Get the animator component
	}
	
	// Update is called once per frame
	void Update () // A method called Update
    {
        if (Input.GetKey(KeyCode.DownArrow)) // Check if down arrow is pressed
        {
            // Modify parameter we created earlier
            anim.SetBool("isOpened", true);
        }
        else // If the button isn't pressed
        {
            // Set that parameter to false
            anim.SetBool("isOpened", false);
        }
	}
}
