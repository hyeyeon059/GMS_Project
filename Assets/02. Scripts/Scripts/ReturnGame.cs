using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGame : MonoBehaviour
{
    public GameObject ESCPanel;
    public void returnGame()
    {
        ESCPanel.gameObject.SetActive(false);

        Time.timeScale = 1;
        Debug.Log("return");
    }
}
