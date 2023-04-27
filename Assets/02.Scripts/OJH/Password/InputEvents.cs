using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputEvents : MonoBehaviour
{
    TMP_InputField inputField;
    private void Awake()
    {
        inputField = GetComponent<TMP_InputField>();
    }

    public void EndEdit()
    {
        //3028
        string input = inputField.text;
        string answer = "3028";
        if(input == answer)
        {
            Debug.Log("문열기");
        }
        else 
        {
            Debug.Log($"틀린 비밀번호: {input}, {answer}");
        }
    }

    public void ResetValue()
    {
        inputField.text = null;
    }
}
