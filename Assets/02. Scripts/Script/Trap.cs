using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private AudioSource audioS;

    private void Awake()
    {
        audioS = FindObjectOfType<AudioSource>();
    }

    private void OnEnable()
    {
    }

    private void Start()
    {
        image.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            audioS.Play();
            image.color = Color.white;
            image.enabled = true;
            Invoke("Des", 2f);

            GameManager.Instance.bPlayerMove = false;
            Invoke("PlayerMove", 3f);
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

    private void PlayerMove()
    {
        GameManager.Instance.bPlayerMove = true;
    }
}
