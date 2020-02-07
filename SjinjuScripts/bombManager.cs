using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombManager : MonoBehaviour
{
    public GameObject enemyBomb;
    public GameObject bombEXP;
    public static float bombSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(0,-bombSpeed * Time.deltaTime, 0);
        enemyBomb.GetComponent<Transform>().position += temp;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Bomb Coll");
        if (coll.gameObject.layer == 11)
        {
            gameManager.lives -= 1;
            gameManager.flashCheck = true;
            float xpos = GetComponent<Transform>().position.x;
            float ypos = GetComponent<Transform>().position.y;
            float zpos = GetComponent<Transform>().position.z;

            Vector3 bombPos = new Vector3(xpos,ypos,zpos);
            Quaternion ang = Quaternion.Euler(0,0,0);

            Instantiate(bombEXP, bombPos, ang);
            Destroy(gameObject);
        }
    }
}
