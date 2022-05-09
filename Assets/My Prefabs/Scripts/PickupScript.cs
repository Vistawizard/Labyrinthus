using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public float distance = 10f;
    public Transform equipPos;
    GameObject currentWeapon;

    bool canGrab;
    void Update()
    {
        CheckGrab();

        if(canGrab)
        {
            if(Input.GetKeyDown(KeyCode.E))
            PickUp();
        }
    }
    private void CheckGrab()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            Debug.Log("I can grab it!");
            currentWeapon = hit.transform.gameObject;
            canGrab = true;
        }
        else
            canGrab = false;
    }

    private void PickUp()
    {
        currentWeapon.transform.position = equipPos.position;
        currentWeapon.transform.parent = equipPos;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;

        Debug.Log("Picked it up");
    }
}
