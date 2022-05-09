using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchScript : MonoBehaviour
{
    CapsuleCollider playerCol;
    float originalHeight;
    public float reduceHeight;
    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        originalHeight = playerCol.height;
    }

    // Update is called once per frame
    void Update()
    {
        // Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GoUp();
        }
    }

    void Crouch()
    {
        playerCol.height = reduceHeight;
    }

    void GoUp()
    {
        playerCol.height = originalHeight;
    }
}
