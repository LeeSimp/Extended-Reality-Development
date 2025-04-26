using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumberPad : MonoBehaviour
{
    public string sequence;
    public TextMeshProUGUI inputDisplayText;
    private string currentInput = "";
    public DoorHandle doorHandle;
    public GameObject lockBar;

    public void ReceiveNumber(int number)
    {
        currentInput += number.ToString();
        UpdateDisplay();

        if (currentInput.Length == sequence.Length)
        {
            CheckCode();
        }
    }

    private void UpdateDisplay()
    {
        if (inputDisplayText != null)
            inputDisplayText.text = currentInput;
    }

    private void CheckCode()
    {
        if (currentInput == sequence)
        {
            UnlockDoor();
        }
        else
        {
            ResetPad();
        }
    }

    private void UnlockDoor()
    {
        inputDisplayText.text = "Unlocked!";
        if (doorHandle != null)
        {
            doorHandle.UnlockDoor(); 
        }
        if(lockBar != null)
        {
            lockBar.SetActive(false);
        }
    }

    private void ResetPad()
    {
        currentInput = "";
        UpdateDisplay();
    }
}
