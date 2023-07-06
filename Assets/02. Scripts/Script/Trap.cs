using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    private AudioSource audioS;
    

    private void Start()
    {
        spriteRenderer.enabled = false;

        audioS = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioS.Play();
            spriteRenderer.enabled = true;
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
            spriteRenderer.color = Color.Lerp(new Color(1, 1, 1, 1), new Color(1, 1, 1, 0), persent);

            yield return null;
        }
        spriteRenderer.enabled = false;

    }
}
