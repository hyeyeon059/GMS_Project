using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class passward : MonoBehaviour
{

    [SerializeField] TMP_InputField password;
    int passwardwrite = 0;
    int right = 3028;
    void Start()
    {
        passwardwrite = int.Parse(password.text);
        Debug.Log("ok");
      
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
         {
            if (passwardwrite == right)
            {
                Debug.Log("open");
            }
            else Debug.Log("return");
        }
    }
}
