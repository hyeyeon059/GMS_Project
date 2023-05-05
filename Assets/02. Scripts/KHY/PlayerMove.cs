using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private GameObject flash;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        flash = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v);
        rb.velocity = dir* moveSpeed;

        if (h != 0 || v != 0)
            flash.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -Mathf.Atan2(h, v) * Mathf.Rad2Deg));

        animator.SetBool("IsIdle", dir.x+dir.y==0);
        animator.SetFloat("PosX",dir.x);
        animator.SetFloat("PosY",dir.y);
    }
}