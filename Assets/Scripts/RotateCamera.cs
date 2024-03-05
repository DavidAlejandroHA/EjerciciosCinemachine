using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    public Transform objetivo; // The object to rotate around
    public float velocidad = 50.0f; // Speed of rotation
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    void Update()
    {
        if (objetivo != null)
        {
            // Rotate around the target at the specified speed
            transform.RotateAround(objetivo.position, Vector3.up, velocidad * Time.deltaTime);
        }
    }
}
