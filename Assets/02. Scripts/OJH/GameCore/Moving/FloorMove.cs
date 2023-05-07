using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMove : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        int i=0,j=0;
        Vector3 vect = Vector3.zero;
        foreach(GameObject t in GameManager.Instance.FloorPos)
        {
            if(t.transform.position == this.transform.position)
            {
                j = i == 0 ? 1 : i % 2 == 1 ? -1 : 1;  //0과 1을  -1과 1로 바꿔주는것

                vect = j > 0 ? Vector3.up*2 : Vector3.down*2;
                break;
            }
            else
            {
                i++;
            }
        }

        GameManager.Instance.Player.transform.position = GameManager.Instance.FloorPos[i+j].transform.position + vect;
    }

}
