using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Pistol : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public float bullets = 10f;
    public Transform bulletTxt;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public AudioSource GunSound;
    public AudioSource ReloadSound;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }


    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetButtonDown("Fire1") && bullets > 0)
            {
                Shoot();
                bulletTxt.GetComponent<Text>().text = bullets.ToString();
            }

            if (Input.GetButtonDown("RKey"))
            {
                ReloadSound.Play();
                // yield return new WaitForSeconds(0.1f);
                bullets = 10f;
                bulletTxt.GetComponent<Text>().text = bullets.ToString();
            }
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        GunSound.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
        bullets -= 1;
    }
}
