using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Floormove());
    }

    IEnumerator Floormove()
    {
        GameManager.Instance.RoomChanging = true;
        GameManager.Instance.bPlayerMove = false;
        int i = 0, j = 0;
        Vector3 vect = Vector3.zero;
        foreach (FloorMove t in GameManager.Instance.FloorPos)
        {
            if (t.transform.position == this.transform.position)
            {
                j = i == 0 ? 1 : i % 2 == 1 ? -1 : 1;  //0과 1을  -1과 1로 바꿔주는것

                //vect = j > 0 ? Vector3.up * 2 : Vector3.down * 2;
                vect = Vector3.up * 0.7f;
                GameManager.Instance.NowFloor = i-1;
                break;
            }
            else
            {
                i++;
            }
        }

        yield return new WaitForSeconds(0.75f);

        GameManager.Instance.Player.transform.position = GameManager.Instance.FloorPos[i + j].transform.position + vect;
    }
}
