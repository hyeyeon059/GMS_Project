using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDistance : MonoBehaviour
{
    [SerializeField]
    int ItemInfo;

    private void FixedUpdate()
    {
        if (GameManager.Instance.bPlayerMove)
        {
            if(Vector2.Distance(GameManager.Instance.Player.transform.position,this.transform.position) < 2f)
            {
                Debug.Log("F¸¦ ´­·¯ get");

                if (Input.GetKeyDown(KeyCode.F))
                {
                    GameManager.Instance.inventoryItem.Add(ItemInfo);
                    this.gameObject.SetActive(false);
                }
            }
        }   
    }
}
