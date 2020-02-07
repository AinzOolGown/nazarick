using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManager : MonoBehaviour
{
    public GameObject enemyShip;
    public GameObject enemyBomb;
    private AudioSource sfxBomb;

    public static float shipSpeed;

    public float xMaxLim;
    public float xMinLim;

    public static float bombRate;

    private float bombingRate;
    private float thisSpeed;
    private bool check1 = false;
    private bool check2 = false;

    private float amTime = 0;
    private float randomInterval;
    private float yWobble = .3f;
    private float wobbleDel = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        sfxBomb = gameManager.sfxBombDrop;
        randomInterval = Random.Range(-(bombingRate / 10),(bombingRate / 10));
        float randomSpeed = Random.Range(-(shipSpeed/10),(shipSpeed/10));
        bombingRate = bombRate;
        shipSpeed = shipSpeed * -1;
        thisSpeed = shipSpeed + randomSpeed;
    }

    private void enemyShipMovement(){
        
        float xShip = GetComponent<Transform>().position.x;
        float yShip = GetComponent<Transform>().position.y;
        float zShip = GetComponent<Transform>().position.z;

        
        if(xShip > xMaxLim && !check1){
            if (thisSpeed > 0)
            {
                thisSpeed = thisSpeed * -1;
            }
            
            check1 = true;
            check2 = false;
        }
        if(xShip < xMinLim && !check2){
            if (thisSpeed < 0) {
                thisSpeed = thisSpeed * -1;
            }
            check1 = false;
            check2 = true;
        }
        
        if(wobbleDel < amTime){
            yWobble *= -1;
            wobbleDel += 1.0f;
        }

        Vector3 temp = new Vector3(thisSpeed * Time.deltaTime, (Time.deltaTime * yWobble), 0);
        
        Quaternion ang = Quaternion.Euler(0,0,0);

        GetComponent<Transform>().position += temp;
    } 

    private void bombing(){
        if(amTime > bombingRate && ((GetComponent<Transform>().position.x > xMinLim) && (GetComponent<Transform>().position.x < xMaxLim)))
        {
            
            bombingRate += bombingRate + randomInterval;

            if(bombingRate < (bombRate / .8f)){
                bombingRate = bombRate / .8f;
            }

            Quaternion angle = Quaternion.Euler(0,0,0);
            Instantiate(enemyBomb, GetComponent<Transform>().position, angle);
            sfxBomb.Play(0);
        }
        else if(amTime > bombingRate && ((GetComponent<Transform>().position.x > xMinLim))){
            amTime -= Time.deltaTime;
        }
    }


    // Update is called once per frame
    void Update()
    {
        amTime = amTime + Time.deltaTime;
        enemyShipMovement();
        bombing();

        Vector3 lTemp = GetComponent<Transform>().localScale;
        
        if(thisSpeed > 0 && lTemp.x < 0){
            lTemp.x *= -1;
        }
        else if(thisSpeed < 0 && lTemp.x > 0){
            lTemp.x *= -1;
        }
        GetComponent<Transform>().localScale = lTemp;
            



    }
}
