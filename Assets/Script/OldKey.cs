using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldKey : MonoBehaviour, Iinteractable
{
    public void Interact()
    {
        FindAnyObjectByType<MyPlayer>().CollectOldKey();
        Destroy(gameObject);
    }

}
