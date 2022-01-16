using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public static bool gameEnded;
    public GameObject restartButton;

   // void Update()
   // {
        //if (gameEnded)
        //if (Input.GetKeyDown(KeyCode.Escape))
       // {
         //   restartButton.SetActive(true);
           // Time.timeScale = 0f;
       // }
    //}
        public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
