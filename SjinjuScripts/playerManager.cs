using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{

    public GameObject reticle;
    public GameObject reticle2;
    public GameObject cannon;
    public GameObject cannon2;
    public GameObject spawnedReticle;
    public GameObject missile;
    public GameObject eXP;
    public static GameObject explosionObject;
    public AudioSource sfxShooting;

    public float speed;
    public float missileSpeed = 4;
    public float coolDown;
    public int Gmode = 0; 
    public static int GMODE;
    public float xLimMax;
    public float xLimMin;
    public float yLimMax;
    public float yLimMin;

    private float timeAM;
    private float delayTime; 
    private float delayTime2;
    private Quaternion canAngCur;
    private Quaternion canAngCur2;

    private bool canFire2 = true;
    private bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        GMODE = Gmode;
        explosionObject = eXP;
        timeAM = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Gmode == 0){
            playerOnly();
            shooting();

            if(timeAM > (delayTime + coolDown)){
                canFire = true;
                reticle.GetComponent<SpriteRenderer>().enabled = true;
            }
            else{
                reticle.GetComponent<SpriteRenderer>().enabled = !reticle.GetComponent<SpriteRenderer>().enabled;
            }
        }
        if(Gmode == 1){
            twoPlayers();
            shooting2();

            if(timeAM > (delayTime + coolDown)){
                canFire = true;
                reticle.GetComponent<SpriteRenderer>().enabled = true;
            }
            else{
                reticle.GetComponent<SpriteRenderer>().enabled = !reticle.GetComponent<SpriteRenderer>().enabled;
            }


            if(timeAM > (delayTime2 + coolDown)){
                canFire2 = true;
                reticle2.GetComponent<SpriteRenderer>().enabled = true;
            }
            else{
                reticle2.GetComponent<SpriteRenderer>().enabled = !reticle2.GetComponent<SpriteRenderer>().enabled;
            }

        }
        timeAM = timeAM + Time.deltaTime;
    }

    private void shooting(){
        if((Input.GetKeyDown(KeyCode.Joystick1Button0) || (Input.GetKeyDown(KeyCode.B))) && (canFire)){
            float retX = Mathf.Clamp(reticle.GetComponent<Transform>().position.x, xLimMin, xLimMax);
            float retY = Mathf.Clamp(reticle.GetComponent<Transform>().position.y, yLimMin, yLimMax);
            float retZ = reticle.GetComponent<Transform>().position.z;
            Quaternion ang = Quaternion.Euler(0,0,0);
            
            Vector3 pos = new Vector3(retX, retY, retZ + 1);
            
            Instantiate(spawnedReticle, pos, ang);
            sfxShooting.Play(0);

            float cannonX = cannon.GetComponent<Transform>().position.x;
            float cannonY = cannon.GetComponent<Transform>().position.y;
            float cannonZ = cannon.GetComponent<Transform>().position.z;
            
            Vector3 missilePos = new Vector3(cannonX,cannonY,cannonZ+1);

            Instantiate(missile, missilePos, canAngCur);
            
            delayTime = timeAM;
            canFire = false;
        }

    }

    private void playerOnly(){
        
        //float Xval = Input.GetAxis("Vertical1");
        //float Yval = Input.GetAxis("Horizontal1");
        
        float Yval = Input.GetAxisRaw("Vertical");
        float Xval = Input.GetAxisRaw("Horizontal");


        Vector3 tempVect = new Vector3(Xval, Yval, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;

        reticle.GetComponent<Transform>().position += tempVect;
        
        float xCan = cannon.GetComponent<Transform>().position.x;
        float yCan = cannon.GetComponent<Transform>().position.y;
        float xRet = reticle.GetComponent<Transform>().position.x;
        float yRet = reticle.GetComponent<Transform>().position.y;

        float degree = Mathf.Atan2(yCan - yRet, xCan - xRet) * ((float)(180 / Mathf.PI)); 

        Quaternion angle = Quaternion.Euler(0,0,degree);

        canAngCur = angle;
        cannon.GetComponent<Transform>().rotation = angle;
    }

    private void twoPlayers(){
        float Yval = Input.GetAxisRaw("Vertical");
        float Xval = Input.GetAxisRaw("Horizontal");

        float Yval2 = Input.GetAxisRaw("Vertical1");
        float Xval2 = Input.GetAxisRaw("Horizontal1");

        Vector3 tempVect = new Vector3(Xval, Yval, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;

        Vector3 tempVect2 = new Vector3(Xval2, Yval2, 0);
        tempVect2 = tempVect2.normalized * speed * Time.deltaTime;

        reticle.GetComponent<Transform>().position += tempVect;
        reticle2.GetComponent<Transform>().position += tempVect2;

        float xCan = cannon.GetComponent<Transform>().position.x;
        float yCan = cannon.GetComponent<Transform>().position.y;
        float xRet = reticle.GetComponent<Transform>().position.x;
        float yRet = reticle.GetComponent<Transform>().position.y;

        float xCan2 = cannon2.GetComponent<Transform>().position.x;
        float yCan2 = cannon2.GetComponent<Transform>().position.y;
        float xRet2 = reticle2.GetComponent<Transform>().position.x;
        float yRet2 = reticle2.GetComponent<Transform>().position.y;

        float degree = Mathf.Atan2(yCan - yRet, xCan - xRet) * ((float)(180 / Mathf.PI)); 
        float degree2 = Mathf.Atan2(yCan2 - yRet2, xCan2 - xRet2) * ((float)(180 / Mathf.PI)); 
        
        Quaternion angle = Quaternion.Euler(0,0,degree);
        Quaternion angle2 = Quaternion.Euler(0,0,degree2);

        canAngCur = angle;
        canAngCur2 = angle2;

        cannon.GetComponent<Transform>().rotation = angle;
        cannon2.GetComponent<Transform>().rotation = angle2;
    }

    private void shooting2(){
        if((Input.GetKeyDown(KeyCode.Joystick1Button0) || (Input.GetKeyDown(KeyCode.B))) && (canFire)){
            float retX = reticle.GetComponent<Transform>().position.x;
            float retY = reticle.GetComponent<Transform>().position.y;
            float retZ = reticle.GetComponent<Transform>().position.z;
            Quaternion ang = Quaternion.Euler(0,0,0);
            
            Vector3 pos = new Vector3(retX, retY, retZ + 1);
            
            Instantiate(spawnedReticle, pos, ang);
            sfxShooting.Play(0);

            float cannonX = cannon.GetComponent<Transform>().position.x;
            float cannonY = cannon.GetComponent<Transform>().position.y;
            float cannonZ = cannon.GetComponent<Transform>().position.z;
            
            Vector3 missilePos = new Vector3(cannonX,cannonY,cannonZ+1);

            Instantiate(missile, missilePos, canAngCur);
            
            delayTime = timeAM;
            canFire = false;
        }

        if((Input.GetKeyDown(KeyCode.Joystick1Button7) || (Input.GetKeyDown(KeyCode.A))) && (canFire2)){
            float retX2 = reticle2.GetComponent<Transform>().position.x;
            float retY2 = reticle2.GetComponent<Transform>().position.y;
            float retZ2 = reticle2.GetComponent<Transform>().position.z;
            Quaternion ang2 = Quaternion.Euler(0,0,0);
            
            Vector3 pos2 = new Vector3(retX2, retY2, retZ2 + 1);
            
            Instantiate(spawnedReticle, pos2, ang2);
            sfxShooting.Play(0);

            float cannonX2 = cannon2.GetComponent<Transform>().position.x;
            float cannonY2 = cannon2.GetComponent<Transform>().position.y;
            float cannonZ2 = cannon2.GetComponent<Transform>().position.z;
            
            Vector3 missilePos2 = new Vector3(cannonX2,cannonY2,cannonZ2+1);

            Instantiate(missile, missilePos2, canAngCur2);
            
            delayTime2 = timeAM;
            canFire2 = false;
        }


    }


    public static void explosion(Vector3 pos){
        Quaternion an = Quaternion.Euler(0,0,0);
        Instantiate(explosionObject, pos, an);
    }

}
