using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public GameObject m_PortalOut;

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = m_PortalOut.transform.position;
    }
}
