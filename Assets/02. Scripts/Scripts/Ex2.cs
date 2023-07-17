using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex2 : MonoBehaviour
{
    public GameObject ExPanel2;
    private bool active2;
    public void OpenandClose()
    {
        if (active2 == false)
        {
            ExPanel2.gameObject.SetActive(true);
            active2 = true;
        }
        else
        {
            ExPanel2.gameObject.SetActive(false);
            active2 = false;
        }
    }
}
