using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadPuzzel : MonoBehaviour
{
    public int[] code;

    int currentIndex;
    private bool isFinished;
    public Light greenLight;
    public Light redLight;
    public GameObject key;


    private void Start()
    {
        key.SetActive(false);
    }
    internal void OnPress(int number)
    {
        if (code[currentIndex] == number)
        {
            if (isFinished)
            {
                return;
            }

            //currentIndex++;
            if (++currentIndex == code.Length)
            {
                isFinished = true;
                greenLight.enabled = true;
                key.SetActive(true);
            }
        }
        else
        {
            currentIndex = 0;
            redLight.enabled = true;
            Invoke("DisableLight", 1f);
        }
    }
    void DisableLight()
    {
        redLight.enabled = false;
    }
}
