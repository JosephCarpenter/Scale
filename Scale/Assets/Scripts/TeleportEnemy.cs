using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnemy : MonoBehaviour
{
    public GameObject enemy;

    public float x;
    public float y;
    public float z;

    public GameObject text;
    public GameObject image;

    private bool hasTextPlayed = false;

    void Start() {
        text.SetActive(false);
        image.SetActive(false);
    }
    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other) {
        
        if (other.tag == "player") {
            Debug.Log("why");
            enemy.transform.position = new Vector3(x, y, z);
            Debug.Log("wlafkj");
            if (!hasTextPlayed) { 
                playText(5);
            }
        }
    }
    IEnumerator playText(int seconds) {

        Debug.Log("huh");
        text.SetActive(true);
        image.SetActive(true);
        yield return new WaitForSeconds(seconds);
        text.SetActive(false);
        image.SetActive(false);
        hasTextPlayed = true;
    }
}
