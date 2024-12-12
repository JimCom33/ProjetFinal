using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    public GameObject endGamePanel; // R�f�rence au panneau d'�cran de fin

    void Start()
    {
        // D�sactive le panneau au d�but
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false);
        }
    }

    public void ShowEndGameScreen()
    {
        // Affiche le panneau d'�cran de fin
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(true);
            Time.timeScale = 0f; // Met le jeu en pause
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitter le jeu...");
        Application.Quit();
        // Note : Quit ne fonctionne que dans une build. Dans l'�diteur, utilisez Debug.Break()
    }
}
