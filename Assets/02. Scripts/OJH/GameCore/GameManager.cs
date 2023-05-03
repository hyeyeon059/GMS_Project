using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

enum Item
{
    Flash=1,
};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int NowFloor { get; set; }

    [Header("Empty Object를 만들고 각층끼리 이어지는 지점에 놓는다")]
    public List<GameObject> FloorPos = new List<GameObject>();
    public List<int> inventoryItem = new List<int>();

    public bool RoomChanging = false;   //방이동때 켜주는 변수
    public bool bPlayerMove = true;     //플레이어가 움직일수있는지 체크해주는 변수

    public GameObject Player;           //플레이어 관련 


    public void Delay(float delay,Action action) => StartCoroutine(SetDelay(delay, action));


    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("2gamemanager");
        Instance = this;
    }

    public void FloorChange()
    {

    }

    public IEnumerator SetDelay(float delay,Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
