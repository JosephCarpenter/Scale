using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
     public GameObject textGameObject;
     

     public bool isEnd = true;

     void Start () {


          if (isEnd){
               Cursor.lockState = CursorLockMode.None;
               Cursor.visible = true;
          }
     }

    void Update () {
           if (Input.GetKey("escape")) {
                 QuitGame();
          }
    }

    public void PlayAgain() {
        SceneManager.LoadScene("BackUpScenePreUpgrade");
    }

    public void QuitGame() {
        SceneManager.LoadScene("MainMenu");
    }
}
