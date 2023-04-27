using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashclick : MonoBehaviour
{
    static int click = 1;
    [SerializeField] AudioSource audio;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        click--;
        if (click == 0)
        {
            Destroy(gameObject);
            audio.Play();
        }
    }
}
