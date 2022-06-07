using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

<<<<<<< Updated upstream
public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    public float startX = -180;
    public float startY = 16;
    public float startZ = 298;
    
=======
public class playerManager : MonoBehaviour
{
    
    PhotonView PV;

>>>>>>> Stashed changes
    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    void CreateController()
    {
<<<<<<< Updated upstream
        Vector3 Position = new Vector3(startX, startY, startZ);
        PhotonNetwork.Instantiate("Player", Position,Quaternion.identity);
=======
        
>>>>>>> Stashed changes
    }
}
