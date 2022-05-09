using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Random = System.Random;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float startX;
    public float startY;
    public float startZ;
    

    public void Start()
    {
        Vector3 Position = new Vector3(startX, startY, startZ);
        PhotonNetwork.Instantiate(playerPrefab.name, Position, Quaternion.identity);
    }
     
}
