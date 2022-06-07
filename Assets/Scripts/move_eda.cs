using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;   

public class move_eda : MonoBehaviourPunCallbacks, IDamageable
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    [SerializeField] Camera playerCamera;
    [SerializeField] AudioListener audioListener;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    private SpawnPlayers playerManager;
    
    
    [SerializeField] private Transform player;
    //[SerializeField] private Transform Spawnpoint;
    

    [SerializeField] private Item[] items;
    int ItemIndex;
    int previousItemIndex;

    public float maxHealth;
    float currentHealth;
    
    PhotonView view;
    
    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        view = GetComponent<PhotonView>();
        currentHealth = maxHealth;
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (view.IsMine)
        {
            EquipItem(0);
        }
        else
        {
            playerCamera.enabled = false;
            audioListener.enabled = false;
        }
    }

    void Update()
    {
        if (!view.IsMine)
            return;
        else
        {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            // Press Left Shift to run
            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }


            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            // Move the controller
            characterController.Move(moveDirection * Time.deltaTime);


            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }

            if (Input.GetMouseButtonDown(0))
                items[ItemIndex].Use();
            

        }
        
    }

    void EquipItem(int _index)
    {
        ItemIndex = _index;
        
        items[ItemIndex].itemGameObject.SetActive(true);
        
        if (previousItemIndex != -1)
            items[ItemIndex].itemGameObject.SetActive(false);

        previousItemIndex = ItemIndex;

    }

    public void TakeDamage(float damage)
    {
        Debug.Log("took damage" + damage);
        //view.RPC("RPC_TakeDamage", RpcTarget.All, damage);
    }

    [PunRPC]
    void RPC_TakeDamage(float damage)
    {
        if (!view.IsMine)
            return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            player.transform.position = new Vector3(0,3,0);
        }

    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    
}
