using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerExit : MonoBehaviour
{
    [SerializeField]
    GameObject[] Clicker;

    public void Exit()
    {
        GameManager.Instance.bPlayerMove = true;
        foreach (GameObject go in Clicker)
        {
            go.SetActive(!(go.activeInHierarchy));
        }
    }
}
