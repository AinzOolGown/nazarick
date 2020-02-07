using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileManager : MonoBehaviour
{
    public float missileSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * missileSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D coll){
        Debug.Log("COL");
        if(coll.gameObject.layer == 9){
            Destroy(coll.gameObject);
            Vector3 pos = transform.position;
            playerManager.explosion(pos);
            Destroy(this.gameObject);
            Destroy(gameObject);
            Destroy(this);
        }
    }
}
