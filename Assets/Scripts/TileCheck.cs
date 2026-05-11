using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TileCheck : NetworkBehaviour {

    [SyncVar] public bool PlayerInTile;

    public string tileType;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;
    private float tick = 0;

    private void Start()
    {
        player2 = GameObject.Find("Player 2");
        player3 = GameObject.Find("Player 3");
        player4 = GameObject.Find("Player 4");
        player5 = GameObject.Find("Player 5");
    }

    private void Update()
    {
        tick += Time.deltaTime;
        if (tick > 2)
        {
            if(isServer)
            { 
            RpcTimerStart();
            }
            
                player2.GetComponent<PlayerObject>()._mapGenFinished = true;
            
                player3.GetComponent<PlayerObject>()._mapGenFinished = true;
            
                player4.GetComponent<PlayerObject>()._mapGenFinished = true;
            
                player5.GetComponent<PlayerObject>()._mapGenFinished = true;
            
        }
        
        if (player2.GetComponent<PlayerObject>().IsInTile == this.gameObject.name || player3.GetComponent<PlayerObject>().IsInTile == this.gameObject.name || player4.GetComponent<PlayerObject>().IsInTile == this.gameObject.name || player5.GetComponent<PlayerObject>().IsInTile == this.gameObject.name)
        {
            PlayerInTile = true;
            if (!isServer)
            {
                return;
            }
            RpcPlayerInTile();
        }
        else
        {
            PlayerInTile = false;
            if (!isServer)
            {
                return;
            }
            RpcPlayerNotInTile();
        }
    }

    [ClientRpc]
    public void RpcPlayerInTile()
    {
        PlayerInTile = true;
    }

    [ClientRpc]
    public void RpcPlayerNotInTile()
    {
        PlayerInTile = false;
    }

    [ClientRpc]
    public void RpcTimerStart()
    {
        GameObject.Find("Timer").GetComponent<TimerScript>()._mapGenFinished = true;
    }
}