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
        Clicker[0].SetActive(true);
        Clicker[1].SetActive(false);
        Clicker[2].SetActive(true);
        Clicker[3].SetActive(false);
    }
}