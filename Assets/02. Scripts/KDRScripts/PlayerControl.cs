using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = 5;

    Rigidbody2D rb2d;
    GameObject _light;
    GameObject lockPick;
    GameObject iDCard;

    public bool lockpickHave = false;
    public bool iDCardHave = false;

    Quaternion playerRot;

    float x;
    float y;

    float constX;
    float constY;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //_light = transform.GetChild(0).gameObject;
        lockPick = transform.GetChild(1).gameObject;
        iDCard = transform.GetChild(2).gameObject;
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

        if (x != 0 || y != 0)   //방향 유지
        {
            constX = x;
            constY = y;
        }
    }

    private void Rotation()
    {
        playerRot = Quaternion.Euler(new Vector3(0, 0, -Mathf.Atan2(constX, constY) * Mathf.Rad2Deg));
        //_light.transform.rotation = playerRot;
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
                TextBock tb;
                if (hitInfo.transform.gameObject.TryGetComponent<TextBock>(out tb) && !TextManager.Instance.OnText)
                {
                    TextManager.Instance.PopText(tb.Name, tb.Texts);
                }

                switch (hitInfo.transform.tag)
                {
                    case "LockPick":
                        lockpickHave = true;
                        lockPick.gameObject.SetActive(lockpickHave);
                        break;
                    case "IDCard":
                        iDCardHave = true;
                        iDCard.gameObject.SetActive(iDCardHave);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
