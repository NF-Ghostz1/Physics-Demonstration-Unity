using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLib : MonoBehaviour
{
    public Vector3 VectorAdd(Vector3 vec1, Vector3 vec2) // Addition function
    {
        Vector3 vecTemp;
        vecTemp.x = vec1.x + vec2.x;
        vecTemp.y = vec1.y + vec2.y;
        vecTemp.z = vec1.z + vec2.z;
        return vecTemp;
    }

    public Vector3 VectorSub(Vector3 vec1, Vector3 vec2) // Subtraction function
    {
        Vector3 vecTemp;
        vecTemp.x = vec1.x - vec2.x;
        vecTemp.y = vec1.y - vec2.y;
        vecTemp.z = vec1.z - vec2.z;
        return vecTemp;
    }

    public float VecDotP(Vector3 vec1, Vector3 vec2) // Dot Product function
    {
        float floatTemp = (vec1.x * vec2.x) + (vec1.y * vec2.y) + (vec1.z * vec2.z);
        return floatTemp;
    }

    public float VecMag(Vector3 vec1) // Magnitude Function
    {
        return Mathf.Sqrt(Mathf.Pow(vec1.x,2) + Mathf.Pow(vec1.y,2) + Mathf.Pow(vec1.z,2));
    }

    public Vector3 ScalarMult(Vector3 vec1, float num) //Scalar Multiple function
    {
        vec1.x = vec1.x * num;
        vec1.y = vec1.y * num;
        vec1.z = vec1.z * num;
        return vec1;
    }

    public Vector3 UnitVec(Vector3 vec1) // unit vector function
    {
        float mag = VecMag(vec1);
        vec1.x = vec1.x / mag;
        vec1.y = vec1.y / mag;
        vec1.z = vec1.z / mag;
        return vec1;
    }

    public Vector3 UnitDirVec(Vector3 vec1, Vector3 vec2) // unit direction vector function
    {
        Vector3 tempVec = VectorSub(vec1, vec2);
        return UnitVec(tempVec);
    }

    public Vector3 ZeroVec() // 3D zero Vector function
    {
        Vector3 vecTemp;
        vecTemp.x = 0;
        vecTemp.y = 0;
        vecTemp.z = 0;
        return vecTemp;
    }

    public bool RadiusCheck(Vector3 vec1, Vector3 vec2, float rad1, float rad2)  //checks position of both ball 1 and ball 2, and gets the scale value of both x positions/2
    {
        Vector3 vecTemp = VectorSub(vec1, vec2);
        if(VecMag(vecTemp) < rad1 + rad2)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
