using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class passward : MonoBehaviour
{

    [SerializeField] TMP_InputField password;

    public Image key;
   [SerializeField] string text = "Saint";
    [SerializeField] string number1 = "3028";
    bool wrong = false;
  
    void Start()
    {
       
    }

   
    void Update()
    {
        NUMBERS();
        SAINT();
        Key();
    }
    public void NUMBERS()
    {
        if(number1 ==password .text)
        {
            Debug.Log("될까");
        }
        else
        {
            //Debug.Log("no");
        }

    }
    public void SAINT()
    {
        if(text==password.text)
          {
             box.instance.Out();
              //Debug.Log("ok");
          }
        else
        {
           // Debug.Log("No");
        }
    }
    public void Key()
    {
        key.enabled = true;
        Debug.Log("통과");
    }
}
