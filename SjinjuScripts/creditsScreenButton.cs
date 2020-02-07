using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class creditsScreenButton : MonoBehaviour
{
    private bool check2;

    void Update()
    {
    if((Input.GetKeyDown(KeyCode.Joystick1Button0) || (Input.GetKeyDown(KeyCode.Z))) && check2)
        {
            SceneManager.LoadScene("CreditsScene");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collided with credits");

        check2 = true;
    }
}