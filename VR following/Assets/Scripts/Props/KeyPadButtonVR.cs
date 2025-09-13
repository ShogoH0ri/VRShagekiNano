using NavKeypad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadButtonVR : MonoBehaviour
{
    [SerializeField]
    private string value;
    [SerializeField] 
    private Keypad keypad;

    void Button()
    {
        keypad.AddInput(value);
    }
}
