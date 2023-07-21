using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESC : MonoBehaviour
{
    public GameObject ESCPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ESCPanel.gameObject.SetActive(true);

            Time.timeScale = 0;
        }

    }
}
