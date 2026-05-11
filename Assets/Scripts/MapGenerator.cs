using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class MapGenerator : NetworkBehaviour {

    [Header("Constant Tiles")]
    public GameObject StartPoint;
    public GameObject EndPoint;
    public GameObject StartPointInstance;
    public GameObject EndPointInstance;

    [Header("Possible Tiles")]
    public GameObject TileType1;
    public GameObject TileType2;
    public GameObject TileType3;
    public GameObject TileType4;
    public GameObject TileType5;
    public GameObject TileType6;
    public GameObject TileType7;
    public GameObject TileType8;
    public GameObject TileType9;
    public GameObject TileType10;
    public GameObject TileType11;
    public GameObject TileType12;
    public GameObject TileType13;
    public GameObject TileType14;
    public GameObject TileType15;

    [SyncVar]public bool MapGenFinished;

    [SyncVar] public int playersLoaded = 0;

    public NavMeshSurface Labrynth;
    public NavMeshSurface LabrynthSafety;

    private Vector3[] _tileCoords = { new Vector3 (25f, 0.51f, -50f), new Vector3(0f, 0.51f, -50f), new Vector3(-25f, 0.51f, -50f), new Vector3(-50f, 0.51f, -50f),
    new Vector3(50f, 0.51f, -25f), new Vector3(25f, 0.51f, -25f), new Vector3(0f, 0.51f, -25f), new Vector3(-25f, 0.51f, -25f), new Vector3(-50f, 0.51f, -25f),
    new Vector3(50f, 0.51f, 0f), new Vector3(25f, 0.51f, 0f), new Vector3(0f, 0.51f, 0f), new Vector3(-25f, 0.51f, 0f), new Vector3(-50f, 0.51f, 0f),
    new Vector3(50f, 0.51f, 25f), new Vector3(25f, 0.51f, 25f), new Vector3(0f, 0.51f, 25f), new Vector3(-25f, 0.51f, 25f), new Vector3(-50f, 0.51f, 25f),
    new Vector3(50f, 0.51f, 50f), new Vector3(25f, 0.51f, 50f), new Vector3(0f, 0.51f, 50f), new Vector3(-25f, 0.51f, 50f) };
    [SyncVar] int _nextTile;

    private GameObject _go;
    private int i = 0;

    private void Start()
    {
        StartPointInstance = StartPoint;
        EndPointInstance = EndPoint;
        LabrynthSafety.BuildNavMesh();
        MapGenFinished = false;
    }

    private void Update()
    {
        if (!MapGenFinished && playersLoaded == 5)
        {
            i = 0;
            CmdInitMapGen();
        }
    }

    [Command]
    public void CmdInitMapGen()
    {
        Debug.Log("InitMapGen");
        if (isServer == false)
        {
            return;
        }
        Debug.Log("isServer");
        MapGenFinished = true;

        foreach (Vector3 tile in _tileCoords)
        {
            i++;
            //randomize tile
            _nextTile = Random.Range(1, 28);
            //place tile at coords
            if (_nextTile == 1)
            {
                _go = Instantiate(TileType1, new Vector3 (tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType1, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if(_nextTile == 2)
            {
                _go = Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 3)
            {
                _go = Instantiate(TileType3, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 4)
            {
                _go = Instantiate(TileType4, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 5)
            {
                _go = Instantiate(TileType5, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 6)
            {
                _go = Instantiate(TileType6, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 7)
            {
                _go = Instantiate(TileType7, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 8)
            {
                _go = Instantiate(TileType8, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 9)
            {
                _go = Instantiate(TileType9, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 10)
            {
                _go = Instantiate(TileType10, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 11)
            {
                _go = Instantiate(TileType11, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 12)
            {
                _go = Instantiate(TileType12, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 13)
            {
                _go = Instantiate(TileType13, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 14)
            {
                _go = Instantiate(TileType14, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 15)
            {
                _go = Instantiate(TileType15, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 16)
            {
                _go = Instantiate(TileType10, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 90, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 17)
            {
                _go = Instantiate(TileType11, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 90, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 18)
            {
                _go = Instantiate(TileType12, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 90, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 19)
            {
                _go = Instantiate(TileType13, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 90, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 20)
            {
                _go = Instantiate(TileType14, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 90, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 21)
            {
                _go = Instantiate(TileType15, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 90, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 22)
            {
                _go = Instantiate(TileType10, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 23)
            {
                _go = Instantiate(TileType11, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 24)
            {
                _go = Instantiate(TileType12, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 25)
            {
                _go = Instantiate(TileType13, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 26)
            {
                _go = Instantiate(TileType14, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }
            else if (_nextTile == 27)
            {
                _go = Instantiate(TileType15, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
                _go.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Instantiate(TileType2, new Vector3(tile.x, tile.y, tile.z), Quaternion.identity, this.transform);
            }

            NetworkServer.Spawn(_go);
            _go.name = "Tile #" + i;
        }

        PathChecker();
    }

    void PathChecker()
    {
        Labrynth.BuildNavMesh();
        //check if unobstructed path between runner & exit exists
        NavMeshPath navpath = new NavMeshPath();
        NavMesh.CalculatePath(new Vector3(50, 0.51f, -50), new Vector3(-50, 0.51f, 50), NavMesh.AllAreas, navpath);

        if (navpath.status == NavMeshPathStatus.PathComplete)
        {
            RpcMapGenFinished();
        }
        else
        {
            Debug.Log("invalid");

            //delete old map
            while (transform.childCount > 0)
            {
                Transform child = transform.GetChild(0);
                child.parent = null;
                Destroy(child.gameObject);
            }
            if(transform.childCount == 0)
            {
                Debug.Log("Reset Mesh");

                Labrynth.BuildNavMesh();
                MapGenFinished = false;
            }
        }
    }

    [ClientRpc]
    public void RpcMapGenFinished()
    {
        MapGenFinished = true;
        GameObject.Find("GameManager").GetComponent<GameManager>()._mapGenFinished = true;
        if (isServer)
        {
            GameObject.Find("Player 1").transform.GetChild(0).gameObject.GetComponent<MasterController>()._mapGenFinished = true;
        }
    }
}
