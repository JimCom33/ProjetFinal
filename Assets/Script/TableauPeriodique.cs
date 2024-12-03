using UnityEngine;
using UnityEngine.UI;

public class TableauPeriodique : MonoBehaviour, Iinteractable
{

    public Camera camera;
    public GraphicRaycaster raycaster;

    public void Interact()
    {
        FindAnyObjectByType<MyPlayer>().SetSecondaryCamera(camera,raycaster);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
