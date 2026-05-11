using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.Video;

public class Results : NetworkBehaviour {

    public GameObject NetworkManagerGameObject;
    public GameObject client1;
    public GameObject client2;
    public GameObject client3;
    public GameObject client4;
    public GameObject client5;
    public VideoPlayer VictoryScreen;
    public VideoPlayer VicMas;
    public VideoPlayer DefMas;
    public VideoPlayer VicRun;
    public VideoPlayer DefRun;
    private bool playing = false;

    // Use this for initialization
    void Start () {
        NetworkManagerGameObject = GameObject.Find("NetworkManager");

        client1 = GameObject.Find("Player 1");
        client2 = GameObject.Find("Player 2");
        client3 = GameObject.Find("Player 3");
        client4 = GameObject.Find("Player 4");
        client5 = GameObject.Find("Player 5");
        if (!playing)
        {
            if (client1.GetComponent<PlayerObject>().itsMe)
            {
                if (client1.GetComponent<PlayerObject>()._winnerWinnerChickenDinner)
                {
                    VicMas.Play();
                }
                else
                {
                    DefMas.Play();
                }
            }
            else if (client2.GetComponent<PlayerObject>().itsMe)
            {
                if (client2.GetComponent<PlayerObject>()._winnerWinnerChickenDinner)
                {
                    VicRun.Play();
                }
                else
                {
                    DefRun.Play();
                }
            }
            else if (client3.GetComponent<PlayerObject>().itsMe)
            {
                if (client3.GetComponent<PlayerObject>()._winnerWinnerChickenDinner)
                {
                    VicRun.Play();
                }
                else
                {
                    DefRun.Play();
                }
            }
            else if (client4.GetComponent<PlayerObject>().itsMe)
            {
                if (client4.GetComponent<PlayerObject>()._winnerWinnerChickenDinner)
                {
                    VicRun.Play();
                }
                else
                {
                    DefRun.Play();
                }
            }
            else if (client5.GetComponent<PlayerObject>().itsMe)
            {
                if (client5.GetComponent<PlayerObject>()._winnerWinnerChickenDinner)
                {
                    VicRun.Play();
                }
                else
                {
                    DefRun.Play();
                }
            }

            playing = true;
        }
	}
	
	public void ResetGame()
    {
        Destroy(NetworkManagerGameObject);
        NetworkManager.Shutdown();

        SceneManager.LoadScene("Init");
    }
}
