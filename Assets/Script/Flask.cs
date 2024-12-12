using System.Collections;
using UnityEngine;

public class Flask : MonoBehaviour, Iinteractable
{
    private bool hasAnti = false;

    private bool hasDote = false;

    private bool canCollect = false;

    public void Interact()
    {
        if(FindAnyObjectByType<MyPlayer>().HasAnti)
        {
            hasAnti = true;

            FindAnyObjectByType<MyPlayer>().DropAnti();
        }

        if (FindAnyObjectByType<MyPlayer>().HasDote)
        {
            hasDote = true;

            FindAnyObjectByType<MyPlayer>().DropDote();
        }

        if (hasAnti && hasDote)
        {
            Debug.Log("collect");

            StartCoroutine(WaitToCollect());

            if (canCollect)
            {
                FindAnyObjectByType<MyPlayer>().CollectAntiDote();

                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (hasAnti && hasDote)
        {
            FindAnyObjectByType<SubtitleText>().ShowText("Vous avez concontez l'ANTIDOTE! Récuperer la.", 3f);
        }
    }

    private IEnumerator WaitToCollect()
    {
        yield return new WaitForSeconds(3);

        canCollect = true;
    }



}
