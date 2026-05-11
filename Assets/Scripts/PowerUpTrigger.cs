using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().PowerUpNmb--;
            other.gameObject.GetComponent<RunnerController>().CurrentPowerUp = Random.Range(1, 5);
            other.gameObject.GetComponent<RunnerController>().PowerUpTime = other.gameObject.GetComponent<RunnerController>().PowerUpTick + 15f;
            other.gameObject.GetComponent<RunnerController>().PowerUpActive = true;
            Destroy(this.gameObject);
        }
    }
}
