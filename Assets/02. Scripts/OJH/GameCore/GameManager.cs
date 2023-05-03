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

    [Header("Empty Object�� ����� �������� �̾����� ������ ���´�")]
    public List<GameObject> FloorPos = new List<GameObject>();
    public List<int> inventoryItem = new List<int>();

    public bool RoomChanging = false;   //���̵��� ���ִ� ����
    public bool bPlayerMove = true;     //�÷��̾ �����ϼ��ִ��� üũ���ִ� ����

    public GameObject Player;           //�÷��̾� ���� 


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
