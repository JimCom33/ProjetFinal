using UnityEngine;

public class VendingMachine : MonoBehaviour, Iinteractable
{
    private BeerCan beerCan;

    public AudioSource can;
    public void Interact()
    {
        beerCan.gameObject.SetActive(true);
        can.Play();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beerCan = FindAnyObjectByType<BeerCan>();
        beerCan.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
