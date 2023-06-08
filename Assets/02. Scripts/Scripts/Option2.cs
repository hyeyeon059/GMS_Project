using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option2 : MonoBehaviour
{
    public GameObject optionPanel2;
    private bool active;
    public void OpenandClose2()
    {
        if (active == false)
        {
            optionPanel2.gameObject.SetActive(true);
            active = true;
        }
        else
        {
            optionPanel2.gameObject.SetActive(false);
            active = false;
        }

    }
}
