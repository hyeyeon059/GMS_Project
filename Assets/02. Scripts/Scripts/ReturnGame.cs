using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGame : MonoBehaviour
{
    public GameObject ESCPanel;
    private bool active;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void returnGame()
    {
            ESCPanel.gameObject.SetActive(false);
            active = false;

        Time.timeScale = 1;
        Debug.Log("return");
    }
}
