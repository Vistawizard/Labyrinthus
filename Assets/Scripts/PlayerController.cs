using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PlayerController : MonoBehaviourPunCallbacks, IDamageable
{
    
    [SerializeField] GameObject cameraHolder;

    [SerializeField] Image HealthBarImage;
    [SerializeField] GameObject ui;
    
    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    
    [SerializeField] Item[] items;
    
    public GameObject lightSource;
    public bool isOn = false;
    public bool failsafe = false;
    
    int itemIndex;
    int previousItemIndex = -1;
    
    float verticalLookRotation;
    bool grounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    public ParticleSystem muzzleFlash;
    
    Rigidbody rb;

    PhotonView PV;

    const float MaxHealth = 100f;
    public float currenthealth = MaxHealth;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {

        if (PV.IsMine)
        {
            // foreach (var item in items)
            // {
            //     item.itemGameObject.
            // }
            EquipItem(0);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(ui);
        }
    }

    void Update()
    {
        if (!PV.IsMine)
            return;
        Look();
        Move();
        Jump();
        
<<<<<<< Updated upstream
        if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            
=======
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
>>>>>>> Stashed changes
            if(itemIndex >= items.Length - 1)
            {
                EquipItem(0);
            }
            else
            {
                EquipItem(itemIndex + 1);
            }
        }
<<<<<<< Updated upstream
        else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            
=======
        else if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
>>>>>>> Stashed changes
            if(itemIndex <= 0)
            {
                EquipItem(items.Length - 1);
            }
            else
            {
                EquipItem(itemIndex - 1);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            items[itemIndex].Use();
            muzzleFlash.Play();
        }
        if (Input.GetButtonDown("FKey"))
        {
            if (isOn == false)
            {
                lightSource.SetActive(true);
                isOn = true;
            }
            else
            {
                isOn = false;
                lightSource.SetActive(false);
            }
        }
    }

    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity);
        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }
    
    void Move()
    {
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }
    
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }
    
    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }

    void EquipItem(int _index)
    {
        
        if(_index == previousItemIndex)
            return;

        itemIndex = _index;

        items[itemIndex].itemGameObject.SetActive(true);

        if(previousItemIndex != -1)
        {
            items[previousItemIndex].itemGameObject.SetActive(false);
        }

        previousItemIndex = itemIndex;
    }

    public void TakeDamage(float damage)
    {
        PV.RPC("RPC_TakeDamage", RpcTarget.All, damage);
        
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!PV.IsMine)
            return;

        if (currenthealth <= 0)
        {
            transform.position = new Vector3(-180, 16, 298);
            currenthealth = 100;
        }
        
        currenthealth -= damage;

        HealthBarImage.fillAmount = currenthealth / MaxHealth;
    }
}
