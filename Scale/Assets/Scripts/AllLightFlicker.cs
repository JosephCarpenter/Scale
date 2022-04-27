using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllLightFlicker : MonoBehaviour
{
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 1f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;

    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueue;

    float lastSum = 0;

    private bool teleport = false;

    private GameObject[] redLights;
    private GameObject[] OverHeadLights;
    private GameObject[] spotLights;
    private GameObject directional;

    /// <summary>
    /// Reset the randomness and start again. You usually don't need to call
    /// this, deactivating/reactivating is usually fine but if you want a strict
    /// restart you can do.
    /// </summary>
    public void Reset() {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start() {
        smoothQueue = new Queue<float>(smoothing);
        redLights = GameObject.FindGameObjectsWithTag("redLight");
        OverHeadLights = GameObject.FindGameObjectsWithTag("overHeadLight");
        spotLights = GameObject.FindGameObjectsWithTag("spotLight");
        directional = GameObject.FindGameObjectWithTag("directional");

    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "player") {

            StartCoroutine(spooky(1));

        }
    }

    void Update() {
        if (teleport) {

            // pop off an item if too big
            while (smoothQueue.Count >= smoothing) {
                lastSum -= smoothQueue.Dequeue();
            }

            // Generate random new item, calculate new average
            float newVal = Random.Range(minIntensity, maxIntensity);
            smoothQueue.Enqueue(newVal);
            lastSum += newVal;

            // Calculate new smoothed average
            foreach (GameObject lamps in redLights) {
                lamps.GetComponent<Light>().intensity = lastSum / (float)smoothQueue.Count;
            } 
            
            foreach (GameObject lamps in OverHeadLights) {
                lamps.GetComponent<Light>().intensity = lastSum / (float)smoothQueue.Count;
            }

            foreach (GameObject lamps in spotLights) {
                lamps.GetComponent<Light>().intensity = lastSum / (float)smoothQueue.Count;
            }
        }
    }

    IEnumerator spooky(int seconds) {
        teleport = true;
        yield return new WaitForSeconds(seconds);
        teleport = false;

        foreach (GameObject lamps in redLights) {
            lamps.GetComponent<Light>().intensity = 25;
        } 
            
        foreach (GameObject lamps in OverHeadLights) {
            lamps.GetComponent<Light>().intensity = 75;
        }

        foreach (GameObject lamps in spotLights) {
            lamps.GetComponent<Light>().intensity = 1000;
        }
    }

}
