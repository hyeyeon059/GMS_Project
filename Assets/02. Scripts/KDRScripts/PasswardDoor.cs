using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswardDoor : MonoBehaviour
{
    private CircleCollider2D circle;

    [SerializeField]
    private GameObject _input;


    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        
    }


    public void Out()
    {
        circle.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            _input.SetActive(true);
        }
    }

    public void InputExit()
    {
        _input.SetActive(false);
    }
}
