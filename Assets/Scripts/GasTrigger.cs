using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<RunnerController>().sleepTime = other.gameObject.GetComponent<RunnerController>().PowerUpTick + 15f;
        }
    }
}
