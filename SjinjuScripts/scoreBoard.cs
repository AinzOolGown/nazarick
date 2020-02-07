using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class scoreBoard : MonoBehaviour
{
    public static int scoreValue = 0;

    public static void ScoreValue(int val)
    {
        scoreValue = scoreValue + val;
        Debug.Log(scoreValue);

        //if(scoreValue >= highScore)
        //{
            //highScore = scoreValue;
        //}
    }

    private void Update()
    {
        if (scoreValue > PlayerPrefs.GetInt("highScore") && (playerManager.GMODE == 0)) {
            PlayerPrefs.SetInt("highScore", scoreValue);
        }
        else if (scoreValue > PlayerPrefs.GetInt("highScore2") && (playerManager.GMODE == 1)){
            PlayerPrefs.SetInt("highScore2", scoreValue);
        }


        if (Input.GetKeyDown("escape")) {
            PlayerPrefs.SetInt("level", 0);
            scoreValue = 0;
            SceneManager.LoadScene(0);
        }
    }

    void OnGUI()
    {
        GUIStyle gs = new GUIStyle();
        gs.richText = true;
        gs.wordWrap = true;
        gs.normal.textColor = Color.white;

        Rect rect1 = new Rect(10, 10, 300, 200);
        GUI.Label(rect1, "<size=45>Score: " + scoreValue + "</size>", gs);
        Rect rect2 = new Rect(275, 10, 300, 200);
        GUI.Label(rect2, "<size=45>Hits Left: " + gameManager.lives + "</size>", gs);
        Rect rect3 = new Rect(550, 10, 300, 200);

        if(playerManager.GMODE == 0){
            GUI.Label(rect3, "<size=45>High Score: " + PlayerPrefs.GetInt("highScore") + "</size>", gs);
        }
        else{
            GUI.Label(rect3, "<size=45>High Score: " + PlayerPrefs.GetInt("highScore2") + "</size>", gs);

        }
        

        Rect rect4 = new Rect(900, 10, 300, 200);
        GUI.Label(rect4, "<size=45>Level: " + PlayerPrefs.GetInt("level") + "</size>", gs);

        Rect rect5 = new Rect(1100, 10, 300, 200);
        GUI.Label(rect5, "<size=45>Enemies Left: " + gameManager.enemiesLeft + "</size>", gs);

    }
}