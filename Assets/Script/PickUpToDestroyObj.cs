using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpToDestroyObj : MonoBehaviour, Iinteractable
{
    public GameObject otherObjToDestroy;
    public void Interact()
    {
        Destroy(otherObjToDestroy);
        Destroy(gameObject);
    }
}
