using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class passward : MonoBehaviour
{

    [SerializeField] TMP_InputField password;
    
    
   [SerializeField] string text = "Saint";
    bool wrong = false;
  
    void Start()
    {
       
    }

   
    void Update()
    {
        if(text==password.text)
          {
             box.instance.Out();
              Debug.Log("ok");
          }
        else
        {
            Debug.Log("no");
        }
    }
}
