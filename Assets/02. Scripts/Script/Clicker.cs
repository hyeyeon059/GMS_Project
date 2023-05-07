using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public static int click = 10;
    public int Click = click;

    [SerializeField] 
    AudioSource audio;

    [SerializeField]
    GameObject endClick;
    
    public void Init()
    {
        click = 10;
    }

    private void OnEnable()
    {
        click = 10;
    }

    private void OnMouseDown()
    {
        //audio.Play();

        click--;
        if (click == 0)
        {
            this.gameObject.SetActive(false);
            endClick.SetActive(true);
        }
        Click = click;
    }
}
