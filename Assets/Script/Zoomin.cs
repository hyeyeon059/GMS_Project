using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomin : MonoBehaviour
{
    [SerializeField] GameObject B;
    void Start()
    {
       
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            B.gameObject.SetActive(!B.gameObject.activeSelf);
        }
    }
}
