using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MasterController : NetworkBehaviour {

    public GameObject playerObject;
    public bool _masWasSelected = false;
    public GameObject player;
    public Camera cam;
    public bool _mapGenFinished;

    [Header("Trap Timer")]
    public bool TrapsReady;
    public float Timer = 0;
    public float TrapTimer = 1f;
    public float TrapReadyTime;

    [Header("pieges (rotation)")]
    public GameObject RotateTrap;
    public GameObject TileHit;
    public bool RotateTrapHeld = false;
    public GameObject RotateButtonCont;
    public GameObject RotateButtonCW;
    public GameObject RotateButtonCCW;
    public GameObject RotateButtonCancel;

    [Header("pieges (cage)")]
    public GameObject CageTrap;
    public bool CageTrapHeld = false;
    public GameObject CageObject;

    [Header("pieges (scie)")]
    public GameObject SawTrap;
    public bool SawTrapHeld;
    public GameObject SawObject;

    [Header("pieges (gaz)")]
    public GameObject GasTrap;
    public bool GasTrapHeld;
    public GameObject GasObject;

    [Header("pieges (power up)")]
    public GameObject PowerupTrap;
    public bool PowerupTrapHeld;
    public GameObject PowerupObject;

    [Header("pieges (piege a loup)")]
    public GameObject BearTrap;
    public bool BearTrapHeld;
    public GameObject BearTrapObject;

    /*[Header("pieges (glisse)")]
    public GameObject SlideTrap;
    public bool SlideTrapHeld;
    public GameObject SlideTrapObject;*/

    [Header("UI")]
    public GameObject PowerUpItem;
    public GameObject HPMSG;
    public GameObject HP1;
    public GameObject HP2;
    public GameObject HP3;

    public bool TrapActive = false;

    private Transform _mainCameraPos;
    private float mousePosX;
    private float mousePosZ;

    void Start()
    {
        playerObject = transform.parent.gameObject;
        cam = Camera.main;
        //pieges
        RotateTrap = GameObject.Find("RotateTrap");
        RotateButtonCont = GameObject.Find("Rotate Buttons");
        RotateButtonCW = GameObject.Find("RotateCW");
        RotateButtonCCW = GameObject.Find("RotateCCW");
        RotateButtonCancel = GameObject.Find("RotateCan");

        CageTrap = GameObject.Find("CageTrap");
        //CageObject = GameObject.Find("CageObject");

        SawTrap = GameObject.Find("Saw Trap");
        //SawObject = GameObject.Find("SawObject");

        GasTrap = GameObject.Find("Gas Trap");
        //GasObject = GameObject.Find("GasTrap");

        PowerupTrap = GameObject.Find("Powerup Trap");
        //PowerupObject = GameObject.Find("PowerupTrap");

        BearTrap = GameObject.Find("Bear Trap");
        //BearTrapObject = GameObject.Find("BearTrap");

        //SlideTrap = GameObject.Find("Slide Trap");

        PowerUpItem = GameObject.Find("PowerUpImg");
        HPMSG = GameObject.Find("HP");
        HP1 = GameObject.Find("HP1");
        HP2 = GameObject.Find("HP2");
        HP3 = GameObject.Find("HP3");

        _masWasSelected = playerObject.GetComponent<PlayerObject>()._masWasSelected;
        if (hasAuthority)
        {
            Destroy(this);
            return;
        }
        if (!_masWasSelected)
        {
            Destroy(this);
            return;
        }
        RotateButtonCW.SetActive(false);
        RotateButtonCCW.SetActive(false);
        RotateButtonCancel.SetActive(false);
        Debug.Log("destroy runner go");
        player = transform.Find("Runners").gameObject;
        Destroy(player);
        this.GetComponent<Rigidbody>().useGravity = false;
        _mainCameraPos = Camera.main.transform;
    }

    private void Update()
    {
        Timer += Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate () {
        //wait for map gen
        if (_mapGenFinished)
        {
            Destroy(GameObject.Find("LoadingScreen"));
            if(HPMSG != null)
            {
                //PowerUpItem.SetActive(false);
                HPMSG.SetActive(false);
                HP1.SetActive(false);
                HP2.SetActive(false);
                HP3.SetActive(false);
            }

            MoveCamera();
            //if trap timer is ok
            if (!TrapsReady && Timer > TrapReadyTime)
            {
                TrapsReady = true;
            }

            //mouse input
            mousePosX = Input.GetAxis("Mouse X");
            mousePosZ = Input.GetAxis("Mouse Y");
            if (Input.GetMouseButtonDown(0))
            {
                if (TrapsReady)
                {
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform objectHit = hit.transform;
                        if (objectHit == RotateTrap.transform || objectHit == RotateTrap.transform.GetChild(0))
                        {
                            TrapsReady = false;
                            //lift trap
                            RotateTrapHeld = true;
                            
                        }
                        /*if (objectHit == CageTrap.transform || objectHit == CageTrap.transform.GetChild(0))
                        {
                            TrapsReady = false;
                            //lift trap
                            CageTrapHeld = true;
                            
                        }
                        if(objectHit == SawTrap.transform || objectHit == SawTrap.transform.GetChild(0))
                        {
                            TrapsReady = false;
                            //lift trap
                            SawTrapHeld = true;
                        }
                        if(objectHit == GasTrap.transform || objectHit == GasTrap.transform.GetChild(0))
                        {
                            TrapsReady = false;
                            //lift trap
                            GasTrapHeld = true;
                        }
                        if(objectHit == PowerupTrap.transform || objectHit == PowerupTrap.transform.GetChild(0))
                        {
                            TrapsReady = false;
                            //lift trap
                            PowerupTrapHeld = true;
                        }
                        if(objectHit == BearTrap.transform || objectHit == BearTrap.transform.GetChild(0))
                        {
                            TrapsReady = false;
                            //lift trap
                            BearTrapHeld = true;
                        }*/
                        /*if(objectHit == SlideTrap.transform || objectHit == SlideTrap.transform.GetChild(0))
                        {
                            TrapsReady = false;
                            //lift trap
                            SlideTrapHeld = true;
                        }*/
                    }
                    
                }
                if (RotateTrapHeld)
                {
                    RotateTrap.transform.position = new Vector3(mousePosX, 10f, mousePosZ);
                }
                if (CageTrapHeld)
                {
                    CageTrap.transform.position = new Vector3(mousePosX, 10f, mousePosZ);
                }
                if (SawTrapHeld)
                {
                    SawTrap.transform.position = new Vector3(mousePosX, 10f, mousePosZ);
                }
                if (GasTrapHeld)
                {
                    GasTrap.transform.position = new Vector3(mousePosX, 10f, mousePosZ);
                }
                if (PowerupTrapHeld)
                {
                    PowerupTrap.transform.position = new Vector3(mousePosX, 10f, mousePosZ);
                }
                if (BearTrapHeld)
                {
                    BearTrap.transform.position = new Vector3(mousePosX, 10f, mousePosZ);
                }
                /*if (SlideTrapHeld)
                {
                    SlideTrap.transform.position = new Vector3(mousePosX, 10f, mousePosZ);
                }*/
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (RotateTrapHeld) {
                    RotateTrapHeld = false;

                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform objectHit = hit.transform;
                        if (objectHit.tag == "Tile" && objectHit.GetComponent<TileCheck>().PlayerInTile == false)
                        {
                            TrapActive = true;
                            Debug.Log("Hit " + objectHit.name);
                            if (transform.parent.parent != null && objectHit.parent.parent.name != "MapGenerator")
                            {
                                Debug.Log("Hit 2");
                                TileHit = objectHit.parent.parent.gameObject;
                            }
                            else if (transform.parent != null && objectHit.parent.name != "MapGenerator")
                            {
                                Debug.Log("Hit 3");
                                TileHit = objectHit.parent.gameObject;
                            }
                            else
                            {
                                Debug.Log("Hit 4");
                                TileHit = objectHit.gameObject;
                            }
                            TileHit.transform.position = new Vector3(TileHit.transform.position.x, 40f, TileHit.transform.position.z);

                            RotateButtonCW.SetActive(true);
                            RotateButtonCCW.SetActive(true);
                            RotateButtonCancel.SetActive(true);
                        }
                        else
                        {
                            //return to base pos
                            RotateTrap.transform.position = new Vector3(0f, 3, 85f);
                        }
                    }
                }
                /*if (CageTrapHeld)
                {
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform objectHit = hit.transform;
                        if (objectHit.tag == "tile")
                        {
                            CmdSpawnCage(objectHit.position);
                            //cage exits
                            //CageObject.transform.position = new Vector3(objectHit.transform.position.x, 5, objectHit.transform.position.z);
                        }
                        else
                        {
                            //return to base pos
                            CageTrap.transform.position = new Vector3(-40f, 0, 105f);
                        }
                    }
                }*/

                /*if (SawTrapHeld)
                {
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform objectHit = hit.transform;
                        if (objectHit.tag == "tile")
                        {
                            CmdSpawnSaw(objectHit.position);
                            //saw exits
                            //SawObject.transform.position = new Vector3(objectHit.transform.position.x, 5, objectHit.transform.position.z);
                        }
                        else
                        {
                            //return to base pos
                            SawTrap.transform.position = new Vector3(-15f, 0, 85f);
                        }
                    }
                }*/

                /*if (GasTrapHeld)
                {
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform objectHit = hit.transform;
                        if (objectHit.tag == "tile")
                        {
                            var gas = Instantiate(GasObject, objectHit.position, Quaternion.identity);
                            //gas.transform.Translate(0, 0, 0);
                            NetworkServer.Spawn(gas);
                            //saw exits
                            //GasObject.transform.position = new Vector3(objectHit.transform.position.x, 5, objectHit.transform.position.z);
                        }
                        else
                        {
                            //return to base pos
                            GasTrap.transform.position = new Vector3(-15f, 0, 105f);
                        }
                    }
                }*/

                /*if (PowerupTrapHeld)
                {
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform objectHit = hit.transform;
                        if (objectHit.tag == "tile")
                        {
                            var PU = Instantiate(PowerupObject, objectHit.position, Quaternion.identity);
                            PU.transform.Translate(0, 1, 0);
                            NetworkServer.Spawn(PU);
                            //saw exits
                            //PowerupObject.transform.position = new Vector3(objectHit.transform.position.x, 5, objectHit.transform.position.z);
                        }
                        else
                        {
                            //return to base pos
                            PowerupTrap.transform.position = new Vector3(10f, 0, 105f);
                        }
                    }
                }*/

                /*if (BearTrapHeld)
                {
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform objectHit = hit.transform;
                        if (objectHit.tag == "tile")
                        {
                            CmdSpawnBear(objectHit.position);
                            //saw exits
                            //BearTrapObject.transform.position = new Vector3(objectHit.transform.position.x, 5, objectHit.transform.position.z);
                        }
                        else
                        {
                            //return to base pos
                            BearTrap.transform.position = new Vector3(10f, 0, 85f);
                        }
                    }
                }*/

                /*if (SlideTrapHeld)
                {
                    RaycastHit hit;
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Transform objectHit = hit.transform;
                        if (objectHit.gameObject.layer == 10)
                        {
                            var slide = Instantiate(SlideTrapObject, objectHit.position, Quaternion.identity);
                            slide.transform.Translate(0, 0, 0);
                            int rotate = Random.Range(1, 3);
                            if(rotate == 1)
                            {
                                slide.transform.Rotate(0, 90, 0);
                            }
                            else if(rotate == 2)
                            {
                                slide.transform.Rotate(0, 0, 0);
                            }
                            NetworkServer.Spawn(slide);
                            //slide exits
                        }
                        else
                        {
                            //return to base pos
                            SlideTrap.transform.position = new Vector3(35f, 0, 85f);
                        }
                    }
                }*/

            }
        }
    }

    [Command]
    public void CmdSpawnCage(Vector3 p)
    {
        var cage = Instantiate(CageObject, p, Quaternion.identity);
        cage.transform.Translate(0, 5, 0);
        NetworkServer.Spawn(cage);
    }

    [Command]
    public void CmdSpawnSaw(Vector3 p)
    {
        var saw = Instantiate(SawObject, p, Quaternion.identity);
        saw.transform.Translate(0, 2, 0);
        NetworkServer.Spawn(saw);
    }

    [Command]
    public void CmdSpawnBear(Vector3 p)
    {
        var BT = Instantiate(BearTrapObject, p, Quaternion.identity);
        BT.transform.Translate(0, 0, 0);
        NetworkServer.Spawn(BT);
    }

    void MoveCamera()
    {
        //position TBD
        _mainCameraPos.position = new Vector3(-2f, 100f, 15f);
        _mainCameraPos.rotation = Quaternion.Euler(90f, 0f, 90f); 
    }
}