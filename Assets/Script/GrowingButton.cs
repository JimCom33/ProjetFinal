using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingButton : MonoBehaviour, Iinteractable
{
    public void Interact()
    {
        transform.localScale *= 1.1f;
    }
}
