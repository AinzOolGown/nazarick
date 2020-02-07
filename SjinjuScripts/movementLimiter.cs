using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementLimiter : MonoBehaviour
{
    public float xLimMax;
    public float xLimMin;
    public float yLimMax;
    public float yLimMin;

    private float xVAL;
    private float yVAL;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xVAL = GetComponent<Transform>().position.x;
        yVAL = GetComponent<Transform>().position.y;
        xVAL = Mathf.Clamp(GetComponent<Transform>().position.x, xLimMin, xLimMax);
        yVAL = Mathf.Clamp(GetComponent<Transform>().position.y, yLimMin, yLimMax);
        Vector3 newPos = new Vector3(xVAL, yVAL, GetComponent<Transform>().position.z);
        Quaternion ang = Quaternion.Euler(0,0,0);

        GetComponent<Transform>().position = newPos;

    }
}
