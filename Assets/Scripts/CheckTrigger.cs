using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckTrigger : NetworkBehaviour {

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Tile")
        {
            //other.gameObject.GetComponent<TileCheck>().PlayerInTile = true;
            this.gameObject.transform.parent.gameObject.GetComponent<PlayerObject>().IsInTile = other.gameObject.name;
        }
        else if(other.gameObject.tag == "END")
        {
            RpcIsDone();
        }
        else
        {
            this.gameObject.transform.parent.gameObject.GetComponent<PlayerObject>().IsInTile = "";
        }
    }

    [ClientRpc]
    public void RpcIsDone()
    {
        if(this.transform.parent.gameObject.name == "Player 2")
        {
            this.transform.parent.gameObject.GetComponent<PlayerObject>()._winnerWinnerChickenDinner = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().Player2IsDone = true;
            GameObject.Find("Timer").GetComponent<TimerScript>().Player2IsDone = true;
        }
         else if (this.transform.parent.gameObject.name == "Player 3")
        {
            this.transform.parent.gameObject.GetComponent<PlayerObject>()._winnerWinnerChickenDinner = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().Player3IsDone = true;
            GameObject.Find("Timer").GetComponent<TimerScript>().Player2IsDone = true;
        }
        else if(this.transform.parent.gameObject.name == "Player 4")
        {
            this.transform.parent.gameObject.GetComponent<PlayerObject>()._winnerWinnerChickenDinner = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().Player4IsDone = true;
            GameObject.Find("Timer").GetComponent<TimerScript>().Player2IsDone = true;
        }
        else if(this.transform.parent.gameObject.name == "Player 5")
        {
            this.transform.parent.gameObject.GetComponent<PlayerObject>()._winnerWinnerChickenDinner = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().Player5IsDone = true;
            GameObject.Find("Timer").GetComponent<TimerScript>().Player2IsDone = true;
        }

    }
}
