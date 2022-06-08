using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;

public class Famas : Gun
{
    [SerializeField] Camera cam;

    // public AudioSource GunSound;
    // public AudioSource ReloadSound;
    // public ParticleSystem muzzleFlash;

    public override void Use()
    {
        shoot();
    }

    void shoot()
    {
        // muzzleFlash.Play();
        // GunSound.Play();
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        ray.origin = cam.transform.position;
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.gameObject.GetComponent<IDamageable>()?.TakeDamage(((GunInfo)itemInfo).damage);
        }
    }
}
