using UnityEngine;

public class CloseDoor : MonoBehaviour
{

    public GameObject Door;

    public AudioSource closeDoor;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        Animator animator = Door.GetComponent<Animator>();

        animator.SetTrigger("Open");

        closeDoor.Play();
    }
}
