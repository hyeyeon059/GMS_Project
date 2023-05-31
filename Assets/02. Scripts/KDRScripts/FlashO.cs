using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashO : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.flashOn = !GameManager.Instance.flashOn;
            transform.GetChild(0).gameObject.SetActive(GameManager.Instance.flashOn);
        }
    }
}
