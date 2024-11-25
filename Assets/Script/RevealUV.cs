using UnityEngine;

public class RevealUV : MonoBehaviour
{
    public MeshRenderer codeMesh;
    private MyCharacterController MyCharacter;

    private void Start()
    {
        MyCharacter = FindAnyObjectByType<MyCharacterController>();
    }

    private void Update()
    {
        if (MyCharacter.hasFlashlight)
        {
            codeMesh.material.SetVector("_LightPos", transform.position);
            codeMesh.material.SetVector("_LightDir", transform.forward);
            codeMesh.material.SetFloat("_LightAngle", Mathf.Deg2Rad * 30f); 
        }
    }
}
