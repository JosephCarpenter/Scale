using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject[] pauseMenu;
    bool isUp;

    void Start() {
        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");

        foreach (GameObject temp in pauseMenu) {
            temp.SetActive(false);

        }
        isUp = false;
    }

    public void returnToGame() {
        foreach (GameObject temp in pauseMenu) {
            temp.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isUp = false;
    }

    void Update() {
        if (Input.GetKeyUp("escape")) {
            if (isUp) {
                isUp = true;
                foreach (GameObject temp in pauseMenu) {
                    temp.SetActive(false);
                }
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else {
                foreach (GameObject temp in pauseMenu) {
                    temp.SetActive(true);
                }
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                isUp = false;
            }
        }
    }

    public void returnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
