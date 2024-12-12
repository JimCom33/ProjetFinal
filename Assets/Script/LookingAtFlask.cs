using UnityEngine;

public class LookingAtFlask : MonoBehaviour
{
    public GameObject targetObject; // L'objet sp�cifique � d�tecter
    public float detectionRange = 10f; // Distance maximale pour le raycast
    

    private bool isLookingAtObject = false;

    private void Update()
    {
        // Lancer un raycast depuis la cam�ra
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, detectionRange))
        {
            // V�rifiez si l'objet d�tect� est l'objet cible
            if (hit.collider.gameObject == targetObject)
            {
                if (!isLookingAtObject && FindAnyObjectByType<MyPlayer>().HasAnti || FindAnyObjectByType<MyPlayer>().HasDote)
                {
                    isLookingAtObject = true;
                    OnLookAtObject(); // Appeler l'action
                }
            }
            else if (isLookingAtObject)
            {
                isLookingAtObject = false;
                
            }
        }
        else if (isLookingAtObject)
        {
            isLookingAtObject = false;
            
        }
    }

    private void OnLookAtObject()
    {
        Debug.Log($"Vous regardez l'objet cible : {targetObject.name}");
        // Action � effectuer uniquement si `hasAntiDote` est vrai
        if (FindAnyObjectByType<MyPlayer>().HasAnti || FindAnyObjectByType<MyPlayer>().HasDote)
        {
            FindAnyObjectByType<SubtitleText>().ShowText("Vous pouvez ajouter",5f);
        }
    }
}

