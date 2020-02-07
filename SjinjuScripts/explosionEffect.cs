using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionEffect : MonoBehaviour
{
    public float expanisonTime;
    private float amTime;
    public float expanisonRate;
    public int shipPoints;
    public int bombPoints;

    public bool isENEMy;
    public GameObject EXPP;
    public GameObject enemyEXPP;
    public static AudioSource sfxEXP;
    public AudioSource sfxKill;
    private float Tint = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        amTime = 0.0f;
        sfxEXP.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        amTime += Time.deltaTime;

        

        
        if(amTime < (expanisonTime)){
            transform.localScale += new Vector3(expanisonRate,expanisonRate,expanisonRate);
        }
        else if(amTime >= (2 * expanisonTime)){
            transform.localScale -= new Vector3(expanisonRate,expanisonRate,expanisonRate);
        }
        else{
            Destroy(this.gameObject);
        }
        //if(checky){
        //    Tint += (( 50.0f / 255.0f ) * Time.deltaTime);
         //   Color tinty = new Color(1, Tint, 0,);
        //    EXPP.GetComponent<Renderer>().material.color = new Color(1, Tint, 0);
    
        //}

    }

    void OnTriggerEnter2D(Collider2D coll){
        if(!isENEMy){
        if(coll.gameObject.layer == 8){
            scoreBoard.ScoreValue(shipPoints);
            Destroy(coll.gameObject);
            gameManager.enemiesLeft -= 1;
            sfxKill.Play(0);
        }
        else if(coll.gameObject.layer == 10){
            
            float xVal = coll.gameObject.GetComponent<Transform>().position.x;
            float yVal = coll.gameObject.GetComponent<Transform>().position.y;
            float zVal = coll.gameObject.GetComponent<Transform>().position.z;

            Vector3 bombPos = new Vector3(xVal,yVal,zVal);
            Quaternion ang = Quaternion.Euler(0,0,0);
            
            Instantiate(enemyEXPP, bombPos, ang);
            
            scoreBoard.ScoreValue(bombPoints);
            Destroy(coll.gameObject);
            sfxKill.Play(0);
        }
        }
    }

}
