using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    [SerializeField] float speed = 5;

    Rigidbody2D rb2d;
    GameObject light;

    float x;
    float y;
    void Start()
    {
        GameManager.Instance.Player = this.gameObject;
        rb2d = GetComponent<Rigidbody2D>();
        light = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        rb2d.velocity = new Vector2(x, y).normalized * speed;

        if (x != 0 || y != 0)
            light.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -Mathf.Atan2(x, y) * Mathf.Rad2Deg));
    }
}
