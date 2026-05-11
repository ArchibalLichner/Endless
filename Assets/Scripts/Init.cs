using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Init : MonoBehaviour {

    public bool StartServer = false;
    public bool OnServer = false;

    // Use this for initialization
    void Start()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnLevelWasLoaded(int level)
    {
        Debug.Log("Spawn Objects");
        NetworkServer.SpawnObjects();
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "CharacterSelect" && !OnServer)
        {
            //connect clients to server now
            //Master
            //Debug.Log("Start as Player 1");
            //GameObject.Find("NetworkManager").GetComponent<NetworkManager>().StartHost();
            //StartServer = true;
            //players
            //Debug.Log("Start as Client");
            //NetworkManager.singleton.networkAddress= "10.1.10.136";
            //NetworkManager.singleton.StartClient();
            OnServer = true;
        }
    }
}
