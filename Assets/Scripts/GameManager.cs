using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    [Header("Game Objects")]
    public NavMeshSurface Labrynth;
    public GameObject StartPoint;
    public GameObject EndPoint;

    [Header("Timer")]
    public float Timer = 300f;
    public Text MasterTimeChecker;

    [Header("Trap Management")]
    public int RotateCount;
    public float TrapTimer = 1f;
    public float TrapTick = 0;
    public GameObject TileHit;
    public GameObject CageObject;
    public GameObject CageGot;
    public bool cageExists;
    public int CageHP = 120;
    public bool CageGotRunner;

    [Header("Players Done")]
    public bool Player2IsDone = false;
    public bool Player3IsDone = false;
    public bool Player4IsDone = false;
    public bool Player5IsDone = false;

    public bool _mapGenFinished;
    public float PowerUpNmb = 0;
    public GameObject PowerUpObject;

    //client communication is done here

    // Update is called once per frame
    void FixedUpdate () {
        TrapTick += Time.deltaTime;
        //wait for map gen
        if (_mapGenFinished)
        {
            //timer
            Timer -= Time.deltaTime;
            MasterTimeChecker.text = Timer.ToString("F");

            if(Timer <= 0f) {
                //goto results (master win (runners at end win))
                GameObject.Find("Player 1").GetComponent<PlayerObject>()._winnerWinnerChickenDinner = true;
            }


            //powerups/traps
            if(RotateCount == 4 || RotateCount == -4)
            {
                RotateCount = 0;
            }

            if (cageExists && !CageGotRunner)
            {
                CageToGround();
            }
            else if (CageGotRunner)
            {
                CageObject = GameObject.Find("Cage(Clone)");
            }
            else if (CageGotRunner && CageHP <= 0)
            {
                Destroy(CageObject);
                cageExists = false;
            }

            if (PowerUpNmb < 10)
            {
                //random position
                var poweruprand = Random.Range(1 , 24);
                if(poweruprand == 1)
                {
                    GameObject tile = GameObject.Find("Tile #1");
                    Vector3 position;
                    if(tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 2)
                {
                    GameObject tile = GameObject.Find("Tile #2");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 3)
                {
                    GameObject tile = GameObject.Find("Tile #3");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 4)
                {
                    GameObject tile = GameObject.Find("Tile #4");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if(tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 5)
                {
                    GameObject tile = GameObject.Find("Tile #5");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 6)
                {
                    GameObject tile = GameObject.Find("Tile #6");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 7)
                {
                    GameObject tile = GameObject.Find("Tile #7");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 8)
                {
                    GameObject tile = GameObject.Find("Tile #8");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 9)
                {
                    GameObject tile = GameObject.Find("Tile #9");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 10)
                {
                    GameObject tile = GameObject.Find("Tile #10");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 11)
                {
                    GameObject tile = GameObject.Find("Tile #11");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 12)
                {
                    GameObject tile = GameObject.Find("Tile #12");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 13)
                {
                    GameObject tile = GameObject.Find("Tile #13");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 14)
                {
                    GameObject tile = GameObject.Find("Tile #14");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 15)
                {
                    GameObject tile = GameObject.Find("Tile #15");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 16)
                {
                    GameObject tile = GameObject.Find("Tile #16");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 17)
                {
                    GameObject tile = GameObject.Find("Tile #17");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 18)
                {
                    GameObject tile = GameObject.Find("Tile #18");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 19)
                {
                    GameObject tile = GameObject.Find("Tile #19");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 20)
                {
                    GameObject tile = GameObject.Find("Tile #20");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 21)
                {
                    GameObject tile = GameObject.Find("Tile #21");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 22)
                {
                    GameObject tile = GameObject.Find("Tile #22");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
                if (poweruprand == 23)
                {
                    GameObject tile = GameObject.Find("Tile #23");
                    Vector3 position;
                    if (tile.GetComponent<TileCheck>().tileType == "Tile 1")
                    {
                        position = tile.transform.position + new Vector3(3.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 1 (1)")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 2 (1)")
                    {
                        position = tile.transform.position + new Vector3(-2f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 2.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 3 (1)")
                    {
                        position = tile.transform.position + new Vector3(-1f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 4 (1)")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, -1);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 5")
                    {
                        position = tile.transform.position + new Vector3(0, 0, 3.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 6")
                    {
                        position = tile.transform.position + new Vector3(-0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 7")
                    {
                        position = tile.transform.position + new Vector3(2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 8")
                    {
                        position = tile.transform.position + new Vector3(0.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 9")
                    {
                        position = tile.transform.position + new Vector3(-2.5f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 10")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0.5f);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                    else if (tile.GetComponent<TileCheck>().tileType == "Tile 11")
                    {
                        position = tile.transform.position + new Vector3(0f, 0, 0);
                        //spawn object
                        SpawnPowerUp(position);
                    }
                }
            }

        }
    }

    public void RotateTileCW()
    {
        RotateCount++;
        TileHit = GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().TileHit;
        var pivot = new Vector3(TileHit.transform.position.x, 0, TileHit.transform.position.z);
            TileHit.transform.RotateAround(pivot, Vector3.up, 90); 
    }

    public void RotateTileCCW()
    {
        RotateCount--;
        TileHit = GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().TileHit;
        var pivot = new Vector3(TileHit.transform.position.x, 0, TileHit.transform.position.z);
        TileHit.transform.RotateAround(pivot, Vector3.up, -90);
    }

    public void RotateTileCancel()
    {
        TileHit = GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().TileHit;
        if (RotateCount != 0)
        {
            GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().TrapActive = false;
            GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().TrapReadyTime = TrapTick + TrapTimer;
        }
        GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().RotateButtonCW.SetActive(false);
        GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().RotateButtonCCW.SetActive(false);
        GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().RotateButtonCancel.SetActive(false);
        GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().RotateTrap.transform.position = new Vector3(0f, 3, 85f);
        GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().TileHit.transform.position = new Vector3(TileHit.transform.position.x, 0.5f, TileHit.transform.position.z);
    }

    public IEnumerator CageToGround()
    {
        yield return new WaitForSeconds(5);
        if (!CageGotRunner)
        {
            Destroy(GameObject.Find("Cage(Clone)"));
            cageExists = false;
        }
    }

    

    [ClientRpc]
    public void RpcStopPowerUp()
    {
        GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().TrapActive = false;
        GameObject.Find("Player 1").transform.GetChild(0).GetComponent<MasterController>().TrapReadyTime = TrapTick + TrapTimer;
    }

    public void SpawnPowerUp(Vector3 p)
    {
        PowerUpNmb++;
        var powerup = GameObject.Instantiate(PowerUpObject, p + new Vector3(0,1,0), Quaternion.identity);
        NetworkServer.Spawn(powerup);
    }
}
