using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float startX;
    public float startY;
    public float startZ;

    PhotonView view;

    GameObject controller;


    public void Start()
    {
        PhotonNetwork.Instantiate("PlayerManager", Vector3.zero, Quaternion.identity);
    }

    // public void Start()
    // {
    //     Vector3 Position = new Vector3(startX, startY, startZ);
    //     controller = PhotonNetwork.Instantiate(playerPrefab.name, Position, Quaternion.identity);
    // }

   
}
