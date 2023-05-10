using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public  GameObject  hint;
    void Start()
    {
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision .gameObject .tag =="Square")
        {
            Debug.Log("hello");
            //if (Input.GetKeyDown(KeyCode.F))
            //{
            //    Destroy(gameObject);
            //}
        }
    }

}
