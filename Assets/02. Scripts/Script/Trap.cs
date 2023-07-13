using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    private Image image;

    private AudioSource audioS;

    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        image.enabled = true;
        image.color = Color.white;
    }

    private void Start()
    {
        image.enabled = false;
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioS.Play();
            image.enabled = true;
            Invoke("Des", 2f);
        }
    }

    private void Des()
    {
        StartCoroutine("FadeOut", 2);
    }
    
    IEnumerator FadeOut(float time)
    {
        float current = 0f;
        float persent = 0f;
        while (persent < 1f)
        {
            current += Time.deltaTime;
            persent = current / time;
            image.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), persent);

            yield return null;
        }
        image.enabled = false;
    }
}
