using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadButton : MonoBehaviour, Iinteractable
{
    public int number;

    public void Interact()
    {
        FindAnyObjectByType<KeyPadPuzzel>().OnPress(number);
        Debug.Log("Clicked on number :" + number);
    }
}
