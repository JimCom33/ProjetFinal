using UnityEngine;

public class ElevatorButton : MonoBehaviour, Iinteractable
{
    public int floorNumber;

    public void Interact()
    {
        Debug.Log("Hit");

        FindAnyObjectByType<Elevator>().GotoFloor(floorNumber);
    }
}
