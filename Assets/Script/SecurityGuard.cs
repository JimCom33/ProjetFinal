using System;
using UnityEngine;
using UnityEngine.UI;

public class SecurityGuard : MonoBehaviour, Iinteractable
{

    private bool isInteracting = false;

    public Animator animator;

    public OldKey oldKey;

    public GameObject antiDote;

    private string[] dialogueLines = new string[] 
    {
        "J'ai ete empoisonné par le savant fou. (Click droit pour passer)",
        "Vous devez a tout pris trouver avec quoi il ma empoisonné et concocter l'antidote. (Click droit pour passer)",
        "Je suis le seul a avoir la clé pour sortir de ce batiment. (Click droit pour passer)",
        "Si vous ne me sauvez pas la vie... vous y serez pris a tout jamais. (Click droit pour passer)",
        "Depechez vous, il me reste moins de 20 minutes avant de mourir. (Click droit pour passer)"
    };
    private int currentLineIndex = 0;
    public void Interact()
    {
        TimeManager timerManager = FindAnyObjectByType<TimeManager>();

        timerManager.StartTimer();
    

    currentLineIndex = 0;
        isInteracting = true;
        ShowNextDialogue();

        if (FindAnyObjectByType<MyPlayer>().HasAntiDote)
        {
            FindAnyObjectByType<SubtitleText>().ShowText("Merci infiniment vous m'avez sauvez la vie. Voici la clé vous pouvez maintenant partir.", 10f);
            oldKey.gameObject.SetActive(true);
            antiDote.SetActive(false);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.Play("Laying");
    }

    // Update is called once per frame
    void Update()
    {
        if (isInteracting)
        {
            if (Input.GetMouseButtonDown(1))
            {
                ShowNextDialogue();
            }
        }
    }

    private void ShowNextDialogue()
    {
        if (currentLineIndex < dialogueLines.Length)
        {
            FindAnyObjectByType<SubtitleText>().ShowText(dialogueLines[currentLineIndex]);
            currentLineIndex++;
        }
        else
        {
            isInteracting = false;
            FindAnyObjectByType<SubtitleText>().ShowText("", 2f);
        }
    }
}
