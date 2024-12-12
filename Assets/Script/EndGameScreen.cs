using UnityEngine;

public class EndGameScreen : MonoBehaviour
{
    public GameObject endGamePanel; // Référence au panneau d'écran de fin

    void Start()
    {
        // Désactive le panneau au début
        if (endGamePanel != null)
        {
            endGamePanel.SetActive(false);
        }
    }

    public void ShowEndGameScreen()
    {
        // Affiche le panneau d'écran de fin
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
        // Note : Quit ne fonctionne que dans une build. Dans l'éditeur, utilisez Debug.Break()
    }
}
