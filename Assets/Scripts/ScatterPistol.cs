using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScatterPistol : MonoBehaviour
{
    //FX
    public ParticleSystem particles;

    //Raycast variables
    public LayerMask mask;
    public Transform rayOrigin;
    public float distance;

    private bool rayActivate = false;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartScattering());
        grabInteractable.deactivated.AddListener(x => StopScattering());
    }

    public void StartScattering()
    {
        AudioManager.instance.Play("Pistol");
        particles.Play();
        rayActivate = true;
    }

    public void StopScattering()
    {
        AudioManager.instance.Stop("Pistol");
        particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        rayActivate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(rayActivate)
            RaycastCheck();
    }

    void RaycastCheck()
    {
        bool hasHit = Physics.Raycast(rayOrigin.position, rayOrigin.forward, out RaycastHit hit, distance, mask);

        if (hasHit)
        {
            hit.transform.gameObject.SendMessage("Break", SendMessageOptions.DontRequireReceiver);
        }
    }
}
