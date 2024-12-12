using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float timeLimit = 1200f; // 20 minutes en secondes
    private float timeRemaining;
    private bool isTimerActive = false;


    void Update()
    {
        if (isTimerActive)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                EndGame();
            }           
        }
    }

    public void StartTimer()
    {
        if (!isTimerActive)
        {
            isTimerActive = true;
            timeRemaining = timeLimit;
        }
    }

    public void EndGame()
    {
        isTimerActive = false;
        Debug.Log("Temps écoulé ! Le jeu se termine.");
        // Ajoutez ici ce qui doit se passer lorsque le jeu se termine
        // Exemple : Charger une scène de Game Over
        SceneManager.LoadScene("GameOverScene");
    }
}
