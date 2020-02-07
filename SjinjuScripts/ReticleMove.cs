using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleMove : MonoBehaviour
{
    public float speed;

    void Update()
    {
        float Yval = Input.GetAxisRaw("Vertical");
        float Xval = Input.GetAxisRaw("Horizontal");


        Vector3 tempVect = new Vector3(Xval, Yval, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;

        GetComponent<Transform>().position += tempVect;
    }
}
