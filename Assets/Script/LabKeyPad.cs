using UnityEngine;

public class LabKeyPad : MonoBehaviour
{
    public int[] code;

    

    int currentIndex1;
    
    private bool isFinished;
    public Light greenLight;
    public Light redLight;
    public GameObject anti;
    



    private void Start()
    {
        
    }
    internal void OnPress(int number)
    {
        if (code[currentIndex1] == number && currentIndex1 < code.Length)
        {
            if (isFinished)
            {
                return;
            }

            //currentIndex++;
            if (++currentIndex1 == code.Length)
            {
                isFinished = true;
                greenLight.enabled = true;
                FindAnyObjectByType<SubtitleText>().ShowText("Vous avez trouvez anti!");
                anti.SetActive(true);
                currentIndex1 = 0;
            }
        }
        else
        {
            currentIndex1 = 0;
            redLight.enabled = true;
            Invoke("DisableLight", 1f);
        }
    }
    void DisableLight()
    {
        redLight.enabled = false;
    }
}
