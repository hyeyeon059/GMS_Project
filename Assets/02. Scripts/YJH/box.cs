using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public static box instance = null;
    CircleCollider2D circle;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        
    }
    public void Out()
    {
        circle.enabled = false;
    }

 
}
