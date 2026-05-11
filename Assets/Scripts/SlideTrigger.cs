using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTrigger : MonoBehaviour {

    private Vector3 direction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            direction = other.gameObject.transform.TransformDirection(Vector3.forward);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<RunnerController>().sliding = true;
            other.gameObject.GetComponent<RunnerController>().playerRigidBody.velocity = direction * 5;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<RunnerController>().sliding = false;
    }
}
