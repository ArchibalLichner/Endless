using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerObject : NetworkBehaviour {

    public GameObject Controller;

    public bool _char1WasSelected = false;
    public bool _char2WasSelected = false;
    public bool _char3WasSelected = false;
    public bool _char4WasSelected = false;
    public bool _masWasSelected = false;
    public bool _winnerWinnerChickenDinner = false;
    public bool GameOver = false;
    public bool _mapGenFinished;
    public bool itsMe;

    public bool gotControler = false;

    public string IsInTile = "";

    public bool ready = false;

    public int PlayerIdInt;

    [SyncVar] private NetworkInstanceId _playerId;
    [SyncVar] private NetworkInstanceId parentNetId;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnStartLocalPlayer()
    {
        _playerId = this.netId;
        Debug.Log(_playerId);
        PlayerIdInt = unchecked((int)_playerId.Value);
        
        //this.name = "Player " + (PlayerIdInt - 1);
        CmdPlayerName();
    }

    [Command]
    public void CmdPlayerName()
    {
        _playerId = this.netId;
        PlayerIdInt = unchecked((int)_playerId.Value);
        this.name = "Player " + (PlayerIdInt - 1);
        RpcPlayerName();
    }

    [ClientRpc]
    public void RpcPlayerName()
    {
        _playerId = this.netId;
        PlayerIdInt = unchecked((int)_playerId.Value);
        this.name = "Player " + (PlayerIdInt - 1);
    }

    private void Update()
    {
        if (isLocalPlayer)
        {
            itsMe = true;
        }
        if (SceneManager.GetActiveScene().name == "CharacterSelect")
        {
            if(PlayerIdInt - 1 == 1)
            {
                _masWasSelected = true;
            }
            else if (PlayerIdInt - 1 == 2)
            {
                if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player2is == 1)
                {
                    _char1WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player2is == 2)
                {
                    _char2WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player2is == 3)
                {
                    _char3WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player2is == 4)
                {
                    _char4WasSelected = true;
                }
            }
            else if(PlayerIdInt - 1 == 3)
            {
                if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player3is == 1)
                {
                    _char1WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player3is == 2)
                {
                    _char2WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player3is == 3)
                {
                    _char3WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player3is == 4)
                {
                    _char4WasSelected = true;
                }
            }
            else if(PlayerIdInt - 1 == 4)
            {
                if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player4is == 1)
                {
                    _char1WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player4is == 2)
                {
                    _char2WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player4is == 3)
                {
                    _char3WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player4is == 4)
                {
                    _char4WasSelected = true;
                }
            }
            else if(PlayerIdInt - 1 == 5)
            {
                if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player5is == 1)
                {
                    _char1WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player5is == 2)
                {
                    _char2WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player5is == 3)
                {
                    _char3WasSelected = true;
                }
                else if (GameObject.Find("CharacterManager").GetComponent<CharacterSelector>().player5is == 4)
                {
                    _char4WasSelected = true;
                }
            }
            CmdPlayerName();
        }

        if (SceneManager.GetActiveScene().name == "Game" && !gotControler)
        {
            gotControler = true;
            GetController();
        }

        if (SceneManager.GetActiveScene().name == "Game" && !ready)
        {
            ready = true;
            if (isServer && GameObject.Find("MapGenerator").GetComponent<MapGenerator>().playersLoaded == 4)
            {
                StartCoroutine(WaitATick());
                return;
            }
            else if (isServer)
            {
                GameObject.Find("MapGenerator").GetComponent<MapGenerator>().playersLoaded++;
            }
        }

        if(isLocalPlayer && _mapGenFinished)
        {
            transform.GetChild(0).GetComponent<RunnerController>()._mapGenFinished = true;
        }
    }

    [Client]
    private void GetController()
    {
        if (!isLocalPlayer) { return; }
        if (_char1WasSelected)
        {
            CmdCreateController(new Vector3(50, 1, -50), Quaternion.Euler(0, 0, 0), this.gameObject);
        }
        if (_char2WasSelected)
        {
            CmdCreateController(new Vector3(45, 1, -45), Quaternion.Euler(0, 0, 0), this.gameObject);
        }
        if (_char3WasSelected)
        {
            CmdCreateController(new Vector3(55, 1, -55), Quaternion.Euler(0, 0, 0), this.gameObject);
        }
        if (_char4WasSelected)
        {
            CmdCreateController(new Vector3(55, 1, -45), Quaternion.Euler(0, 0, 0), this.gameObject);
        }
        if (_masWasSelected)
        {
            CmdCreateController(new Vector3(0, 100, 0), Quaternion.Euler(0, 0, 0), this.gameObject);
        }

    }

    [Command]
    public void CmdCreateController(Vector3 p, Quaternion r, GameObject g)
    {
        var _conGO = GameObject.Instantiate(Controller, p, r);
        _conGO.transform.parent = g.transform;
        NetworkServer.SpawnWithClientAuthority(_conGO, connectionToClient);
        RpcSyncController(_conGO.transform.localPosition, _conGO.transform.localRotation, _conGO, _conGO.transform.parent.gameObject);
    }

    [ClientRpc]
    public void RpcSyncController(Vector3 localPos, Quaternion localRot, GameObject conn, GameObject parent)
    {
        conn.transform.parent = parent.transform;
        conn.transform.localPosition = localPos;
        conn.transform.localRotation = localRot;
        if (!isLocalPlayer)
        {
            Destroy(this.transform.GetChild(0).gameObject.GetComponent<RunnerController>());
            Destroy(this.transform.GetChild(0).gameObject.GetComponent<MasterController>());
        }
    }

    public IEnumerator WaitATick()
    {
        //make sure all players ingame
        yield return 1;
        GameObject.Find("MapGenerator").GetComponent<MapGenerator>().playersLoaded++;
    }

}
