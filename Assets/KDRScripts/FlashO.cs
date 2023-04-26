using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashO : MonoBehaviour
{
    bool flashOn = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            flashOn = !flashOn;
            transform.GetChild(0).gameObject.SetActive(flashOn);
        }
    }
}
