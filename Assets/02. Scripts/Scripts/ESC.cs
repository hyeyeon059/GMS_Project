using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC : MonoBehaviour
{
    public GameObject ESCPanel;
    private bool active1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ESCPanel.gameObject.SetActive(true);
            active1 = true;

            Time.timeScale = 0;
            Debug.Log("ESC");
        }

    }
}
