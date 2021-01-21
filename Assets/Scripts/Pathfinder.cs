using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    //Class Variables:
    float distance;
    public GameObject[] paths;
    int target = 0;
    Vector3 Vel;
    Vector3 VecTemp;
    public VectorLib VecLib;
    public float speed;
    public float Tolerence;


    // Update is called once per frame
    void Update()
    {
        distance = VecLib.VecMag(VecLib.VectorSub(transform.position, paths[target].transform.position)); // finds the distance between the square and the waypoint.
        if (distance < Tolerence) // if the distance is less that the tolerance then the target changes
        {
            target++;
            if (target >= paths.Length) // if there is no other targets the cube goes back to the first target.
            {
                target = 0;
            }
        }
        VecTemp = VecLib.UnitDirVec(paths[target].transform.position, transform.position); // holds the unit vector between the waypoint and the square
        Vel = VecLib.ScalarMult(VecTemp, speed * Time.deltaTime); // makes the velocity the unit vector * speed
        transform.position = VecLib.VectorAdd(transform.position, Vel); // adds velocity to the position of the cube (allows to move).
    }
}
