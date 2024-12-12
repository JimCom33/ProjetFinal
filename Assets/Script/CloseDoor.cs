using UnityEngine;

public class CloseDoor : MonoBehaviour
{

    public GameObject Door;

    public AudioSource closeDoor;

    private bool beenPlayed = false;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Animator animator = Door.GetComponent<Animator>();

        animator.SetTrigger("Open");

        if (!beenPlayed)
        {
            closeDoor.Play();
            beenPlayed = true;
        }
       
    }
}
