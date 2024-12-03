using UnityEngine;

public class DeskDoor : MonoBehaviour, Iinteractable
{

    public GameObject deskDoor;
    public void Interact()
    {

        if (FindAnyObjectByType<MyPlayer>().UnlockedDeskDoor)
        Debug.Log("interact door");
        GetComponent<Animator>().SetTrigger("Open");
    }

    public void OpenDoor()
    {
        GetComponent<Animator>().SetTrigger("Open");
    }
  
}
