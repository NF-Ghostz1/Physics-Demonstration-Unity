using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{
    // Class Variables:
    public Vector3 Velocity;
    public VectorLib VecLib;
    public float mass;


    // Update is called once per frame
    void Update()
    {
        transform.position = VecLib.VectorAdd(transform.position, VecLib.ScalarMult(Velocity, Time.deltaTime)); // Adds velocity vector to the position vector of the ball
    }
}
