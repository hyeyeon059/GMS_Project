using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 5;

    Rigidbody2D rb2d;
    GameObject _light;
    GameObject lockPick;

    bool lockpickHave = false;

    Quaternion playerRot;

    float x;
    float y;

    float constX;
    float constY;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        _light = transform.GetChild(0).gameObject;
        lockPick = transform.GetChild(1).gameObject;
    }

    void Update()
    {
        Move();
        Rotation();
        InteractionRay();
    }

    private void Move()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        rb2d.velocity = new Vector2(x, y).normalized * speed;

        if (x != 0 || y != 0)   //���� ����
        {
            constX = x;
            constY = y;
        }
    }

    private void Rotation()
    {
        playerRot = Quaternion.Euler(new Vector3(0, 0, -Mathf.Atan2(constX, constY) * Mathf.Rad2Deg));
        _light.transform.rotation = playerRot;
    }

    private void InteractionRay()
    {
        Debug.DrawRay(transform.position, new Vector2(constX, constY), Color.red);
        if (Physics2D.Raycast(transform.position, new Vector2(constX, constY), 1, 1 << LayerMask.NameToLayer("Box")))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                lockpickHave = true;
                lockPick.gameObject.SetActive(lockpickHave);
            }
        }
    }
}