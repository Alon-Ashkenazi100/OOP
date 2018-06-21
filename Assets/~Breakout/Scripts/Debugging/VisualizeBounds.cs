using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class NewBehaviourScript : MonoBehaviour
{
    private Renderer rend;

    void OnDrawGizmos()
    {
        rend = GetComponent<Renderer>();
        Gizmos.DrawWireCube(rend.bounds.center, rend.bounds.size);
    }
}
