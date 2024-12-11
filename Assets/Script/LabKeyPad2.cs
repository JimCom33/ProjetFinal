using UnityEngine;

public class LabKeyPad2 : MonoBehaviour
{
    public int[] code2;
    



    int currentIndex2;

    private bool isFinished;
    public Light greenLight;
    public Light redLight;
    public GameObject dote;



    private void Start()
    {

    }
    internal void OnPress(int number)
    {
        if (code2[currentIndex2] == number && currentIndex2 < code2.Length)
        {
            if (isFinished)
            {
                return;
            }

            //currentIndex++;
            if (++currentIndex2 == code2.Length)
            {
                isFinished = true;
                greenLight.enabled = true;
                FindAnyObjectByType<SubtitleText>().ShowText("Vous avez trouvez dote!");
                dote.SetActive(true);
                currentIndex2 = 0;
            }
        }
        else
        {
            currentIndex2 = 0;
            redLight.enabled = true;
            Invoke("DisableLight", 1f);
        }
    }
    void DisableLight()
    {
        redLight.enabled = false;
    }
}
