using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    // Start is called before the first frame update
    void Start()
    {

        canvas2.SetActive(false);

        StartCoroutine(begin());
    }

    IEnumerator begin() {
        yield return new WaitForSeconds(40);
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        yield return new WaitForSeconds(3);
        canvas2.SetActive(false);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("dan's scene");
    }

    void Update() {
        if (Input.GetKeyUp("escape")) {
            SceneManager.LoadScene("dan's scene");
        }
    }

}
