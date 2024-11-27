using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCafeteria : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var character = other.GetComponent<MyCharacterController>();
        if (character != null && !character.hasFlashlight)
        {
            FindAnyObjectByType<SubtitleText>().ShowText("Aider moi svp... je vais bientot mourir.");
        }
    }

    public void DisableForSeconds()
    {
        StartCoroutine(DisableTemporarily());
    }

    private IEnumerator DisableTemporarily()
    {
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(60);
        this.gameObject.SetActive(true);
    }
}
