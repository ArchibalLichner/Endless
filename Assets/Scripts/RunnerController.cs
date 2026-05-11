using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RunnerController : NetworkBehaviour {

    public GameObject playerObject;
    public bool _masWasSelected = false;
    public GameObject MapGen;

    [Header("Movement Variables")]
    public float MoveSpeed = 5f;
    public float MaxSpeed = 5f;
    public float JumpForce = 10f;
    public float fallMultiplier = 5f;
    public LayerMask GroundLayers;
    public MeshCollider ColliderVar;
    public GameObject Jimmy;
    public GameObject Carla;
    public float rotateHorizontal = 0;
    public float rotateVertical = 0;
    public float CamSensibility = 5;
    public bool crouching = false;


    [Header("Camera pos")]
    private Transform _mainCameraPos;
    private Vector3 CameraOffset;
    public GameObject player;

    /*[Header("Compass")]
    public GameObject indicator;
    private Vector3 _direction;
    private float _angle;
    public Transform ExitPoint;*/

    [Header("Power Ups")]
    public bool PowerUpActive;
    public int CurrentPowerUp;
    public float PowerUpTime = 15f;
    public float PowerUpTick = 0f;
    public Image PowerUpImg;
    public Sprite SpeedUp;
    public Sprite SpeedDn;
    public Sprite Explode;
    public Sprite MasterStop;
    public Sprite RevDir;
    public Sprite Invis;
    public Sprite FlipScreen;

    [Header("Traps")]
    public float sleepTime = 0;

    [Header("Health")]
    public int HP = 3;
    public Sprite HealthTokenOn;
    public Sprite HealthTokenOff;
    public Image HP1;
    public Image HP2;
    public Image HP3;

    public GameObject RotateButtonCont;
    public GameObject RotateButtonCW;
    public GameObject RotateButtonCCW;
    public GameObject RotateButtonCancel;

    public bool _mapGenFinished;
    public bool Caged = false;
    public Animator anim;

    public AudioSource AudioPas;
    public AudioSource AudioSaut;
    public AudioSource AudioMHit;
    public AudioSource AudioFHit;

    public Rigidbody playerRigidBody;

    private Vector3 movement;
    public bool sliding = false;

    void Start () {
        playerObject = transform.parent.gameObject;
        _masWasSelected = playerObject.GetComponent<PlayerObject>()._masWasSelected;
        if (!hasAuthority)
        {
            Debug.Log("has no authority");
            Destroy(this);
            return;
        }
        if (_masWasSelected)
        {
            Debug.Log("Is Master");
            Destroy(this);
            return;
        }

        RotateButtonCW = GameObject.Find("RotateCW");
        RotateButtonCCW = GameObject.Find("RotateCCW");
        RotateButtonCancel = GameObject.Find("RotateCan");
        MapGen = GameObject.Find("MapGenerator");
        HP1 = GameObject.Find("HP1").GetComponent<Image>();
        HP2 = GameObject.Find("HP2").GetComponent<Image>();
        HP3 = GameObject.Find("HP3").GetComponent<Image>();
        //PowerUpImg = GameObject.Find("PowerUpImg").GetComponent<Image>();
        RotateButtonCW.SetActive(false);
        RotateButtonCCW.SetActive(false);
        RotateButtonCancel.SetActive(false);

        //ExitPoint = GameObject.Find("ExitPoint").transform;

        //player rigid body
        playerRigidBody = this.GetComponent<Rigidbody>();

        //get collider
        //if (playerObject.GetComponent<PlayerObject>()._char1WasSelected || playerObject.GetComponent<PlayerObject>()._char3WasSelected)
        //{
            ColliderVar = this.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<MeshCollider>();
            //var PGO = Instantiate(Jimmy, this.transform.GetChild(0));
            //NetworkServer.SpawnWithClientAuthority(PGO, connectionToClient);
            anim = this.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>();
            //Destroy(this.transform.GetChild(0).transform.GetChild(1).gameObject);
        //}
        /*else if (playerObject.GetComponent<PlayerObject>()._char2WasSelected || playerObject.GetComponent<PlayerObject>()._char4WasSelected)
        {
            ColliderVar = this.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<MeshCollider>();
            //var PGO = Instantiate(Carla, this.transform.GetChild(0));
            //NetworkServer.SpawnWithClientAuthority(PGO, connectionToClient);
            anim = this.transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<Animator>();
            //Destroy(this.transform.GetChild(0).transform.GetChild(0).gameObject);
        }*/

        //camera positioning
        CameraOffset = new Vector3(0f, 0.5f, 0.25f);
        _mainCameraPos = Camera.main.transform;
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!hasAuthority)
        {
            Debug.Log("has no authority");
            return;
        }
        PowerUpTick += Time.deltaTime;
        
        //wait for map gen
        if (_mapGenFinished)
        {
            Destroy(GameObject.Find("LoadingScreen"));
            //player compass
            /****************rework needed********************/
            /*_direction = ExitPoint.position - transform.position;
            _angle = Mathf.Atan2(_direction.x, _direction.z)*Mathf.Rad2Deg;
            indicator.transform.eulerAngles = new Vector3(0,0,_angle);*/

            //player movement
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            rotateHorizontal += Input.GetAxis("Mouse X") * CamSensibility;

            this.transform.rotation = Quaternion.Euler(0, rotateHorizontal, 0);

            movement = new Vector3(moveHorizontal, 0, moveVertical);
            movement = Quaternion.Euler(0, rotateHorizontal, 0) * movement;

        /*if (Input.GetButton("Fire3"))
        {
                if (Caged)
                {
                    CmdCageHP();
                }
                anim.SetBool("CrouchPressed", true);
                anim.SetBool("IsCrouching", true);
                anim.SetBool("IsStanding", false);
            crouching = true;
            ColliderVar.gameObject.transform.localScale = new Vector3(0.5f,0.25f,0.5f);
            MaxSpeed *= 0.5f;
            MoveSpeed *= 0.5f;
            CameraOffset = new Vector3(0,-0.5f,0);
        }
        else
        {
            crouching = false;
                anim.SetBool("CrouchPressed", false);
                anim.SetBool("IsCrouching", false);
                anim.SetBool("IsStanding", true);
            ColliderVar.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            MaxSpeed *= 2f;
            MoveSpeed *= 2f;
            CameraOffset = new Vector3(0, 0.5f, 0);
        }*/

        if (moveHorizontal == 0 && moveVertical == 0)
        {
                playerRigidBody.velocity = new Vector3(0, playerRigidBody.velocity.y, 0);

        }
        else if((playerRigidBody.velocity.x + playerRigidBody.velocity.z) < MaxSpeed)
        {
                if (Caged)
                {
                    CmdCageHP();
                }
                playerRigidBody.AddForce(movement * MoveSpeed, ForceMode.Acceleration);
        }

            anim.SetFloat("Movement", Mathf.Abs(playerRigidBody.velocity.x + playerRigidBody.velocity.z));

        if (IsGrounded() && Input.GetButtonDown("Jump") && !sliding)
        {
                if (Caged)
                {
                    CmdCageHP();
                }
                anim.SetBool("Jumping", true);
                playerRigidBody.velocity += Vector3.up * JumpForce;
        }

        //powerups
        /*if (PowerUpActive)
        {
            if (CurrentPowerUp == 1)
            {
                //speed boost
                MaxSpeed *= 2;
                PowerUpImg.sprite = SpeedUp;
            }
            else if(CurrentPowerUp == 2)
            {
                //invisibility
                CmdInvis();
                if (playerObject.GetComponent<PlayerObject>()._char1WasSelected)
                {
                    var color = ColliderVar.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;
                    color.a = 0;
                        PowerUpImg.sprite = Invis;
                    }
                else
                {
                    var color = ColliderVar.gameObject.GetComponent<Renderer>().material.color;
                    color.a = 0;
                }
            }
            else if(CurrentPowerUp == 3)
            {
                //Master Stop
                CmdStopPowerUp();
                    PowerUpImg.sprite = MasterStop;
                }
            else if (CurrentPowerUp == 4)
            {
                //Hp up
                HP++;
                    PowerUpImg.sprite = HealthTokenOn;
                }

            //Powerup trap
            else if(CurrentPowerUp == 5)
            {
                //slow
                MaxSpeed *= 0.5f;
                    PowerUpImg.sprite = SpeedDn;
                }
            else if (CurrentPowerUp == 6)
            {
                //explosion
                HP--;
                    PowerUpImg.sprite = Explode;
                    Hit();
                }
            else if (CurrentPowerUp == 7)
            {
                //reverse controls
                movement *= -1;
                    PowerUpImg.sprite = RevDir;
                }
            else if (CurrentPowerUp == 8)
            {
                //180 vision
                Camera.main.projectionMatrix = Camera.main.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));
                    PowerUpImg.sprite = FlipScreen;
                }
            

            //tick
            if (PowerUpTick > PowerUpTime)
            {
                PowerUpActive = false;
                //reset all
                CmdResetPowerUps();
                CurrentPowerUp = 0;
                MaxSpeed = 5;
                Camera.main.projectionMatrix = Camera.main.projectionMatrix * Matrix4x4.Scale(new Vector3(1, 1, 1));
                if (playerObject.GetComponent<PlayerObject>()._char1WasSelected)
                {
                    var color = ColliderVar.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;
                    color.a = 1;
                }
                else
                {
                    var color = ColliderVar.gameObject.GetComponent<Renderer>().material.color;
                    color.a = 1;
                }
                    PowerUpImg.sprite = null;
            }

            if(PowerUpTick < sleepTime)
            {
                movement *= 0;
            }
        }*/

        if(HP > 3 || HP == 3)
            {
                HP = 3;
                HP1.sprite = HealthTokenOn;
                HP2.sprite = HealthTokenOn;
                HP3.sprite = HealthTokenOn;
            }
            else if (HP == 2)
            {
                HP1.sprite = HealthTokenOff;
                HP2.sprite = HealthTokenOn;
                HP3.sprite = HealthTokenOn;
            }
            else if (HP == 1)
            {
                HP1.sprite = HealthTokenOff;
                HP2.sprite = HealthTokenOff;
                HP3.sprite = HealthTokenOn;
            }
            else if (HP == 0)
            {
                HP1.sprite = HealthTokenOff;
                HP2.sprite = HealthTokenOff;
                HP3.sprite = HealthTokenOff;
                anim.SetBool("Ded", true);
            }

            //player camera
            MoveCamera();
        }
    }

    [Command]
    public void CmdInvis()
    {
        RpcInvis();
        if (playerObject.GetComponent<PlayerObject>()._char1WasSelected)
        {
            var color = ColliderVar.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;
            color.a = 0;
        }
        else
        {
            var color = ColliderVar.gameObject.GetComponent<Renderer>().material.color;
            color.a = 0;
        }
    }

    [ClientRpc]
    public void RpcInvis()
    {
        if (playerObject.GetComponent<PlayerObject>()._char1WasSelected)
        {
            var color = ColliderVar.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;
            color.a = 0;
        }
        else
        {
            var color = ColliderVar.gameObject.GetComponent<Renderer>().material.color;
            color.a = 0;
        }
    }

    [Command]
    public void CmdResetPowerUps()
    {
        MaxSpeed = 5;
        if (playerObject.GetComponent<PlayerObject>()._char1WasSelected)
        {
            var color = ColliderVar.gameObject.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color;
            color.a = 1;
        }
        else
        {
            var color = ColliderVar.gameObject.GetComponent<Renderer>().material.color;
            color.a = 1;
        }
    }

    [Command]
    public void CmdStopPowerUp()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().RpcStopPowerUp();
    }

    [Command]
    public void CmdCageHP()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().CageHP--;
    }

    private bool IsGrounded()
    {
        anim.SetBool("Jumping", false);
        return Physics.CheckCapsule(ColliderVar.bounds.center, new Vector3(ColliderVar.bounds.center.x, ColliderVar.bounds.min.y, ColliderVar.bounds.center.z), ColliderVar.skinWidth * 0.9f, GroundLayers);
    }

    public void Hit()
    {
        anim.SetBool("IsHit", true);
        HitEnd();
    }

    public void HitEnd()
    {
        anim.SetBool("IsHit", false);
    }

    void MoveCamera()
    {
        //position TBD
        _mainCameraPos.position = this.transform.localPosition;
        _mainCameraPos.rotation = this.transform.rotation;
        _mainCameraPos.Translate(CameraOffset);
        rotateVertical += Input.GetAxis("Mouse Y") * CamSensibility;
        _mainCameraPos.Rotate(Vector3.left, Mathf.Clamp(rotateVertical, -45, 45), Space.Self);
    }
}