using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightScript : MonoBehaviour
{
    public bool isOn = false;
    public GameObject lightSource;
    public AudioSource clickOn;
    public AudioSource clickOff;
    public bool failsafe = false;


    void Update()
    {
        if (Input.GetButtonDown("FKey"))
        {
            if (isOn == false && failsafe == false)
            {
                failsafe = true;
                lightSource.SetActive(true);
                clickOn.Play();
                isOn = true;
                StartCoroutine(FailSafe());
            }
            if (isOn == true && failsafe == false)
            {
                failsafe = true;
                lightSource.SetActive(false);
                clickOff.Play();
                isOn = false;
                StartCoroutine(FailSafe());
            }
        }
    }

    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failsafe = false;
    }
}
