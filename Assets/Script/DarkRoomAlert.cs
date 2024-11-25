using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoomAlert : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponent<MyCharacterController>();
        if (character != null && !character.hasFlashlight)
        {
            FindAnyObjectByType<SubtitleText>().ShowText("Il fait trop noir... faudrait trouver une source de lumiere.");
        }
    }
}
