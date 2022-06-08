using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    public float startX = -180;
    public float startY = 16;
    public float startZ = 298;

    GameObject player;

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

    GameObject CreateController()
    {
        Vector3 Position = new Vector3(startX, startY, startZ);
        player = PhotonNetwork.Instantiate("Player", Position,Quaternion.identity);
        return player;
    }
}
