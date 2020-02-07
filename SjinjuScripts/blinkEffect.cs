using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinkEffect : MonoBehaviour
{
    public float delay;
    private float amTime = 0;
    private float neDel;
    // Start is called before the first frame update
    void Start()
    {
        neDel = delay;
    }

    // Update is called once per frame
    void Update()
    {
        amTime += Time.deltaTime;

        if(amTime > neDel){
            GetComponent<SpriteRenderer>().enabled = !(GetComponent<SpriteRenderer>().enabled);
            neDel += delay;
        }

        

    }
}
