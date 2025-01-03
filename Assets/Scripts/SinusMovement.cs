using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusMovement : MonoBehaviour
{
    public float frequency = 1f;     // The speed of the movement
    public float amplitude = 5f;   // The speed of rotation
    private float time;
    private Vector3 StartPos;


    void Start()
    {

        time = 0;
        StartPos= this.transform.position;

    }

    void Update()
    {

        // Increment time
        time += Time.deltaTime;

        float X = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * time);
        float Y = amplitude * Mathf.Cos(2 * Mathf.PI * frequency * time);
        float Z = 0;

        this.transform.position = StartPos + new Vector3(X, Y, Z);


    }

}
