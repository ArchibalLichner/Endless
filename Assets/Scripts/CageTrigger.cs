using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageTrigger : MonoBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().CageGotRunner = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().CageGot = other.gameObject;
        }
    }
}
