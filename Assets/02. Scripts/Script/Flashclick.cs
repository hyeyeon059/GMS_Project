using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashclick : MonoBehaviour
{
    static int click = 1;
    [SerializeField] AudioSource audio;

    private void OnMouseDown()
    {

            Destroy(gameObject);
            audio.Play();
    }
}
