using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] AudioMixerGroup masterVolumeGroup;
    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] GameObject fade;

    public static bool IsPaused { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (fade.activeInHierarchy)
            {
                fade.SetActive(false);
                Time.timeScale = 1.0f;
                IsPaused = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                IsPaused = true;
                fade.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.Confined;
            }

            //fade.SetActive(!fade.activeInHierarchy);
            //Time.timeScale = fade.activeInHierarchy ? 0 : 1;
        }
    }

    public void OnMasterVolumeChange()
    {
        masterVolumeGroup.audioMixer.SetFloat("Volume", masterVolumeSlider.value);
    }
}
