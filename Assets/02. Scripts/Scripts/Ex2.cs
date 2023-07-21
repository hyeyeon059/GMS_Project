using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex2 : MonoBehaviour
{
    public GameObject ESC;
    public GameObject ExPanel2;
    public void OpenandClose()
    {
        if (ExPanel2.activeSelf)
        {
            ExPanel2.SetActive(false);
            ESC.SetActive(true);
        }
        else
        {
            ExPanel2.SetActive(true);
            ESC.SetActive(false);
        }
    }
}
