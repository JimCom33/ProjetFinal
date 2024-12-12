using UnityEngine;

public class Anti : MonoBehaviour, Iinteractable
{
    public void Interact()
    {
        FindAnyObjectByType<MyPlayer>().CollectAnti();
        Destroy(gameObject);
    }
}
