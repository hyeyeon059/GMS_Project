using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option2 : MonoBehaviour
{
    public GameObject ESC;
    public GameObject optionPanel2;
    public void OpenandClose2()
    {
        optionPanel2.SetActive(true);
        ESC.SetActive(false);
    }
}
