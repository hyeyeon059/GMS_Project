using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

enum Item
{
    Flash=1,
};

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int NowFloor { get; set; }

    //[Header("Empty Object�� ����� collider�� floormove ��ũ��Ʈ�� �ְ�\n �� ������Ʈ�� �� ������ ���´�. (�𸣰����� pjh���� DM)")]
    public List<FloorMove> FloorPos = new List<FloorMove>();

    public List<int> inventoryItem = new List<int>();
    public int usingItem;               //�տ� �� ������

    public bool RoomChanging = false;   //���̵��� ���ִ� ����
    public bool bPlayerMove = true;     //�÷��̾ �����ϼ��ִ��� üũ���ִ� ����
    public bool flashOn = false;

    public GameObject Player;           //�÷��̾� ���� 

    public KeyCode InteractionKey = KeyCode.F;

    public void Delay(float delay,Action action) => StartCoroutine(SetDelay(delay, action));

    public void Flashing()
    {
        flashOn = !flashOn;
        CameraSet cs = GameObject.FindObjectOfType<CameraSet>().GetComponent<CameraSet>();
        if (flashOn) cs.Flashon();
        else if (!flashOn) cs.Flashoff();
    }

    private void Awake()
    {
        FloorPos.AddRange(transform.gameObject.GetComponentsInChildren<FloorMove>());
        if (Instance != null)
            Debug.LogError("2gamemanager");
        Instance = this;
        if (Player == null)
            Player = GameObject.FindAnyObjectByType<PlayerMove>().gameObject;
    }

    public IEnumerator SetDelay(float delay,Action action)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}
