using UnityEngine;

public class LabKeyPadButton : MonoBehaviour, Iinteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int number;

    public void Interact()
    {
        FindAnyObjectByType<LabKeyPad>().OnPress(number);
        FindAnyObjectByType<LabKeyPad2>().OnPress(number);
        Debug.Log("Clicked on number :" + number);
    }
}
