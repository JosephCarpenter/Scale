using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningTextScroll : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {
        text1.SetActive(false);
        text2.SetActive(false);
        image.SetActive(false);
        StartCoroutine(playText(5));
    }

    IEnumerator playText(int seconds) {

        text1.SetActive(true);
        image.SetActive(true);
        yield return new WaitForSeconds(seconds);
        text1.SetActive(false);
        yield return new WaitForSeconds(1);
        text2.SetActive(true);
        yield return new WaitForSeconds(seconds);
        text2.SetActive(false);
        image.SetActive(false);

    }

}
