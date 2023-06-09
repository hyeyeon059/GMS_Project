using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashclick : MonoBehaviour
{
    static int click = 1;
    [SerializeField] AudioSource _audio;

    private void OnMouseDown()
    {

            Destroy(gameObject);
            _audio.Play();
    }
}
