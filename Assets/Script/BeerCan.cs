using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BeerCan : MonoBehaviour, Iinteractable
{
    public GameObject fakeWall;
    bool isDrank;
    
    public void Interact()
    {
        if (isDrank)
        {
            return;
        }

        ApplyDrunkEffect(true);
        Invoke(nameof(SoberUp), 5f);
    }

    private void ApplyDrunkEffect(bool isOn)
    {
        fakeWall.SetActive(!isOn);

        isDrank = isOn;

        var volume = FindAnyObjectByType<Volume>();
        if (volume.profile.TryGet(out ChromaticAberration chromaticAberration))
        {
            chromaticAberration.active = isOn;
        }

        if (volume.profile.TryGet(out LensDistortion lensDistortion))
        {
            lensDistortion.active = isOn;
        }

    }

    void SoberUp()
    {
        ApplyDrunkEffect(false);
    }
}
