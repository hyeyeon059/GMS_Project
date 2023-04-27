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
            Debug.Log("������");
        }
        else 
        {
            Debug.Log($"Ʋ�� ��й�ȣ: {input}, {answer}");
        }
    }

    public void ResetValue()
    {
        inputField.text = null;
    }
}
