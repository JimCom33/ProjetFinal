using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PickUpFlashLight : MonoBehaviour, Iinteractable
{
    public void Interact()
    {
        var camera = FindAnyObjectByType<ExampleCharacterCamera>();
        camera.GetComponentInChildren<Light>().intensity = 20f;

        FindAnyObjectByType<MyCharacterController>().hasFlashlight = true;
        Destroy(gameObject);
    }

    
}
