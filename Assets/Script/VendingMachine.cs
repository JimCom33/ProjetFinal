using UnityEngine;

public class VendingMachine : MonoBehaviour, Iinteractable
{
    private BeerCan beerCan;

    public void Interact()
    {
        beerCan.gameObject.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beerCan = FindAnyObjectByType<BeerCan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
