using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public int enemyShips;
    public float timeDelay;
    public int enemySpeed;
    public float bombSpeed;
    public int playerLives;
    public float enemyBombRate;
    public GameObject FLASY;
    public GameObject enemyShip;
    public GameObject backGround;
    

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;
    public GameObject spawn5;
    public GameObject spawn6;
    
    public static bool flashCheck;
    public static int enemiesLeft;
    public static int lives;

    public AudioSource sfxBomb;
    public AudioSource bombEXP;
    public static AudioSource sfxBombDrop;

    private float amTime = 0;
    private float waitTime;
    public static int level = 1;
    private float flashDelay;
    private float fusy;
    // Start is called before the first frame update
    void Awake()
    {
        FLASY.GetComponent<SpriteRenderer>().enabled = false;
        sfxBombDrop = sfxBomb;
        explosionEffect.sfxEXP = bombEXP;
        lives = playerLives;
        Debug.Log("Level: " + PlayerPrefs.GetInt("level"));
        level = PlayerPrefs.GetInt("level");

        if (level < 1) {
            PlayerPrefs.SetInt("level", 1);
            level = 1;
        }
        
        waitTime = timeDelay;
        enemyShips = enemyShips + (level - 1);
        enemyManager.shipSpeed = enemySpeed + ((level-1) * .25f);
        bombManager.bombSpeed = bombSpeed +((level-1) * .15f);
        enemyManager.bombRate = enemyBombRate - (float)((level-1) * .15f);

        if (enemyManager.bombRate > 1) {
            enemyManager.bombRate = 1;
        }
        
        enemiesLeft = enemyShips;

        Debug.Log("enemyShips: "+enemyShips);
        Debug.Log("Enemy speed: "+enemyManager.shipSpeed);
        Debug.Log("Bomb speed: "+bombManager.bombSpeed);

        float gTint = ( ( 255.0f - (15.0f * ((float)level-1.0f) ) ) / 255.0f );

        if(gTint < .5f){
            gTint = .5f;
        }

        backGround.GetComponent<Renderer>().material.color = new Color(1, gTint, gTint);

    }



    // Update is called once per frame
    void Update()
    {
        amTime += Time.deltaTime;

        if (flashCheck){
            flashDelay = amTime + 1;
            flashCheck = false;
            fusy = amTime + .1f;
        }

        if(amTime < flashDelay){
            if(amTime > fusy){
                FLASY.GetComponent<SpriteRenderer>().enabled = !FLASY.GetComponent<SpriteRenderer>().enabled;
                fusy += .1f;
            }
            
        }
        else{
            FLASY.GetComponent<SpriteRenderer>().enabled = false;
        }

        
        if((amTime > waitTime) && (enemyShips > 0)){
            
            waitTime = waitTime + timeDelay;
            enemyShips -= 1;
            Quaternion ang = Quaternion.Euler(0,0,0);
            float num = Random.Range(1,4);
            
            
            
            if(num == 1){
                Instantiate(enemyShip, spawn1.GetComponent<Transform>().position, ang);
            }
            else if(num == 2){
                Instantiate(enemyShip, spawn2.GetComponent<Transform>().position, ang);
            }
            else if(num == 3){
                Instantiate(enemyShip, spawn3.GetComponent<Transform>().position, ang);
            }


            if(playerManager.GMODE == 1){
                enemyShips -= 1;
                Quaternion ang2 = Quaternion.Euler(0,0,0);
                float num2 = Random.Range(1,4);

                if(num2 == 1){
                    Instantiate(enemyShip, spawn4.GetComponent<Transform>().position, ang2);
                }
                else if(num2 == 2){
                    Instantiate(enemyShip, spawn5.GetComponent<Transform>().position, ang2);
                }
                else if(num2 == 3){
                    Instantiate(enemyShip, spawn6.GetComponent<Transform>().position, ang2);
                }

            }

        }


        


        



        if(enemiesLeft <= 0){
            int levCount = level + 1;
            PlayerPrefs.SetInt("level", levCount);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        if (lives <= 0) {
            scoreBoard.scoreValue = 0;

            PlayerPrefs.SetInt("level", 0);

            if(playerManager.GMODE == 0){
                SceneManager.LoadScene("1PGameOverScreen");
            }
            else if(playerManager.GMODE == 1){
                SceneManager.LoadScene("2PGameOverScreen");
            }

            
        }
        
    }
}
