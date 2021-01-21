using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Class Variables:
    public Vector3 Velocity;
    public Vector3 Acceleration;
    public VectorLib Veclib;
    public float groundHeight;
    public float Coefficient;
    public float Tolerence;

    // Update is called once per frame
    void Update()
    {
        transform.position = Veclib.VectorAdd(transform.position, Veclib.ScalarMult(Velocity, Time.deltaTime)); // adding the velocity to the position of the ball
        Velocity = Veclib.VectorAdd(Velocity, Veclib.ScalarMult(Acceleration, Time.deltaTime)); // changing the velocity
        if (transform.position.y < groundHeight)
        {
            Velocity.y = Mathf.Abs(Velocity.y) * Coefficient; //velocity after collision (coefficient of restitution)
            if (Velocity.y < Tolerence)
            {
                Velocity.y = 0; // makes it stop bouncing
            }
        }
    }
}
