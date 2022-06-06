using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Transform m_PortalOut;

    private void OnTriggerEnter(Collider collided)
    {
        collided.gameObject.transform.position = m_PortalOut.position;
    }
}
