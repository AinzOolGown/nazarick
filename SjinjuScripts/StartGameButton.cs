using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    private float check;

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            SceneManager.LoadScene("1PMode");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            SceneManager.LoadScene("2PMode");
        }
        if(Input.GetKeyDown(KeyCode.B)){
            SceneManager.LoadScene("TutorialScene");
        }

        if(sceneName == "StartScene"){
            if(Input.GetKeyDown("escape")){
                Application.Quit();
            }
        }
        else{
            if(Input.GetKeyDown("escape")){
                SceneManager.LoadScene("StartScene");
            }
        }

        if(Input.GetKeyDown(KeyCode.H)){
            SceneManager.LoadScene("CreditsScene");
        }
    
    }

   
}