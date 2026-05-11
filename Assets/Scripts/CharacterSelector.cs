using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CharacterSelector : NetworkBehaviour {

    [SyncVar] public bool _char1WasSelected = false;
    [SyncVar] public bool _char2WasSelected = false;
    [SyncVar] public bool _char3WasSelected = false;
    [SyncVar] public bool _char4WasSelected = false;
    [SyncVar] public bool _masWasSelected = false;

    [SyncVar] public int player1is;
    [SyncVar] public int player2is;
    [SyncVar] public int player3is;
    [SyncVar] public int player4is;
    [SyncVar] public int player5is;

    [SyncVar] public int playersReady = 0;

    private float character;

    // Use this for initialization
    void Start() {
        

        for (int i = 1; i <= 5; i++)
        {
            CmdCharacterRandomizer(i);
        }
    }

    private void Update()
    {
        if(playersReady == 1)
        {
            SceneManager.LoadScene("Game");
        }
        
    }

    [Command]
    public void CmdCharacterRandomizer(int player)
    {
        if (player == 1)
        {
            _masWasSelected = true;
            player1is = 5;//master
            return;
        }
        //play animation
        character = Mathf.Round(Random.Range(1f, 4f));
        if (character == 1 && !_char1WasSelected)
        {
            //show player character
            _char1WasSelected = true;
            if (player == 2)
            {
                player2is = 1;
            }
            else if (player == 3)
            {
                player3is = 1;
            }
            else if (player == 4)
            {
                player4is = 1;
            }
            else if (player == 5)
            {
                player5is = 1;
            }
        }
        else if (character == 2 && !_char2WasSelected)
        {
            //show player character
            _char2WasSelected = true;
            if (player == 2)
            {
                player2is = 2;
            }
            else if (player == 3)
            {
                player3is = 2;
            }
            else if (player == 4)
            {
                player4is = 2;
            }
            else if (player == 5)
            {
                player5is = 2;
            }
        }
        else if (character == 3 && !_char3WasSelected)
        {
            //show player character
            _char3WasSelected = true;
            if (player == 2)
            {
                player2is = 3;
            }
            else if (player == 3)
            {
                player3is = 3;
            }
            else if (player == 4)
            {
                player4is = 3;
            }
            else if (player == 5)
            {
                player5is = 3;
            }
        }
        else if (character == 4 && !_char4WasSelected)
        {
            //show player character
            //ClientScene.FindLocalObject(player).GetComponent<PlayerObject>()._char4WasSelected = true;
            _char4WasSelected = true;
            if (player == 2)
            {
                player2is = 4;
            }
            else if (player == 3)
            {
                player3is = 4;
            }
            else if (player == 4)
            {
                player4is = 4;
            }
            else if (player == 5)
            {
                player5is = 4;
            }
        }
        else
        {
            CmdCharacterRandomizer(player);
        }
        RpcPlayerChar(player1is, player2is, player3is, player4is, player5is);
    }

    [ClientRpc]
    public void RpcPlayerChar(int player1, int player2, int player3, int player4, int player5)
    {
        player1is = player1;
        player2is = player2;
        player3is = player3;
        player4is = player4;
        player5is = player5;
        
    }

    public void StartGame()
    {
        playersReady++;
    }
}
