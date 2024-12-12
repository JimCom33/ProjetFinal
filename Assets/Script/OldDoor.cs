using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldDoor : MonoBehaviour, Iinteractable
{
    public GameObject door;
    public void Interact()
    {
        if (FindAnyObjectByType<MyPlayer>().HasOldKey)
        {
            GetComponent<Animator>().SetTrigger("OpenUp");
        }
        else
        {
            FindAnyObjectByType<SubtitleText>().ShowText("La porte est verouille", 5f);
        }
    }

}
