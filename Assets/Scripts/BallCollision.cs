using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    //Class variables:
    public Vector3 Velocity;
    public VectorLib VecLib;
    public Ball2 ball2;
    private bool Collision;
    public float mass;
    private float m;
    private float equationp1;
    private Vector3 Vecsub1;
    private Vector3 Targetdistance;

    // Update is called once per frame
    void Update()
    {
        transform.position = VecLib.VectorAdd(transform.position, VecLib.ScalarMult(Velocity, Time.deltaTime)); // Adds velocity vector to the position vector of the ball
        Collision = VecLib.RadiusCheck(transform.position, ball2.transform.position, transform.localScale.x/2, ball2.transform.localScale.x/2); // collision check
        if(Collision == true)
        {
            Collisionball();
        }
    }

    void Collisionball()
    {
        Targetdistance = VecLib.VectorSub(ball2.transform.position, transform.position);
        if (VecLib.VecDotP(Targetdistance, Velocity) >= 0)
        {
            //equation 1 for conservation of momentum
            m = 2 * ball2.mass / mass + ball2.mass;
            equationp1 = VecLib.VecDotP(VecLib.VectorSub(Velocity, ball2.Velocity), VecLib.VectorSub(transform.position, ball2.transform.position)) / Mathf.Pow(VecLib.VecMag(VecLib.VectorSub(transform.position, ball2.transform.position)), 2);
            Vecsub1 = VecLib.VectorSub(transform.position, ball2.transform.position);
            Velocity = VecLib.VectorSub(Velocity, VecLib.ScalarMult(Vecsub1, m * equationp1));
        }

        Targetdistance = VecLib.VectorSub(transform.position, ball2.transform.position);
        if (VecLib.VecDotP(Targetdistance, ball2.Velocity) >= 0)
        {
            //equation 2 for conservation of momentum
            m = 2 * mass / mass + ball2.mass;
            equationp1 = VecLib.VecDotP(VecLib.VectorSub(ball2.Velocity, Velocity), VecLib.VectorSub(ball2.transform.position, transform.position)) / Mathf.Pow(VecLib.VecMag(VecLib.VectorSub(ball2.transform.position, transform.position)), 2);
            Vecsub1 = VecLib.VectorSub(ball2.transform.position, transform.position);
            ball2.Velocity = VecLib.VectorSub(ball2.Velocity, VecLib.ScalarMult(Vecsub1, m * equationp1));
        }
    }
}
