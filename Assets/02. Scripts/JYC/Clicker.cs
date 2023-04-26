using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    static int click = 13;

    [SerializeField] AudioSource audio;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        audio.Play();

        click--;
        if (click == 0)
        {
            Destroy(gameObject);
        }
    }
}
