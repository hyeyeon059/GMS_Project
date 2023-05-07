using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DistanceCheck : MonoBehaviour
{
    [SerializeField]
    int ItemInfo;


    [SerializeField]
    AudioSource audioSource;
    
    [SerializeField]
    UnityEvent Event;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.bPlayerMove)
        {
            if(Vector2.Distance(GameManager.Instance.Player.transform.position,this.transform.position) < 2.5f)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Event?.Invoke();
                }
            }
        }   
    }

    public void GetItem()
    {
        GameManager.Instance.inventoryItem.Add(ItemInfo);
        this.gameObject.SetActive(false);
    }

    public void Clicker()
    {
        this.gameObject.SetActive(true);

    }

    public void OnMouseDown()
    {
        audioSource.Play();
        GetItem();
    }
}

