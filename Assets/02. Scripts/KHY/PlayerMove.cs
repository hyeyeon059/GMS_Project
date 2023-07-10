using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float constX;
    private float constY;
    private float moveSpeed = 5f;
    private bool lockpickHave = false;
    private bool iDCardHave = false;

    private Rigidbody2D rb;
    private GameObject flash;
    private GameObject lockPick;
    private Animator animator;

    Quaternion playerRot;

    private void Awake()
    {
        flash = transform.GetChild(0).gameObject;
        lockPick = transform.GetChild(1).gameObject;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.Instance.bPlayerMove)
        {
            PlayerMovement();
            Rotation();
            InteractionRay();
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("IsIdle", true);
            animator.SetFloat("PosX", 0);
            animator.SetFloat("PosY", 0);
        }
    }

    private void PlayerMovement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v).normalized;
        rb.velocity = dir* moveSpeed;

        if (h != 0 || v != 0)   //방향 유지
        {
            constX = h;
            constY = v;
        }

        animator.SetBool("IsIdle", dir.x == 0 && dir.y == 0);
        animator.SetFloat("PosX", constX);
        animator.SetFloat("PosY", constY);
    }

    private void Rotation()
    {
        playerRot = Quaternion.Euler(new Vector3(0, 0, -Mathf.Atan2(constX, constY) * Mathf.Rad2Deg));
        flash.transform.rotation = playerRot;
    }

    private void InteractionRay()
    {
        Debug.DrawRay(transform.position, new Vector2(constX, constY), Color.red);

        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit2D hitInfo =
                Physics2D.Raycast(transform.position, new Vector2(constX, constY), 1, 1 << LayerMask.NameToLayer("Interaction"));
            if (hitInfo.transform != null)
            {
                DistanceCheck dc;
                TextBock tb;
                if (hitInfo.transform.gameObject.TryGetComponent<DistanceCheck>(out dc) && !TextManagerAction.Instance.OnText)
                {
                    dc.Event?.Invoke();
                }
                else if (hitInfo.transform.gameObject.TryGetComponent<TextBock>(out tb) && !TextManagerAction.Instance.OnText)
                {
                    TextManagerAction.Instance.PopText(tb.Name, tb.Texts, tb.Item, (int)tb.ItemType, tb.transform.position);
                    if (tb.Item != null)
                    {
                        tb.gameObject.SetActive(false);
                    }
                }

                switch (hitInfo.transform.tag)
                {
                    case "LockPick":
                        lockpickHave = true;
                        lockPick.gameObject.SetActive(lockpickHave);
                        break;
                    case "IDCard":
                        iDCardHave = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
    /*private void InteractionRay()
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
    }*/
}