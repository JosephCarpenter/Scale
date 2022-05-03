using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.tag == "player") {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
