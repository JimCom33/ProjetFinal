using UnityEngine;

public class Dote : MonoBehaviour, Iinteractable
{
    public void Interact()
    {
        FindAnyObjectByType<MyPlayer>().CollectDote();
        Destroy(gameObject);
    }
}
