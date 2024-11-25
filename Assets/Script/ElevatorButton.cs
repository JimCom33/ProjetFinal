using UnityEngine;

public class ElevatorButton : MonoBehaviour, Iinteractable
{
    public int floorNumber;

    public void Interact()
    {
        FindAnyObjectByType<Elevator>().GotoFloor(floorNumber);
    }
}
