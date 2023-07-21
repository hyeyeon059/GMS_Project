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

    //[Header("Empty Object를 만들고 collider와 floormove 스크립트를 넣고\n 그 오브젝트를 각 지점에 놓는다. (모르겠으면 pjh²로 DM)")]
    public List<FloorMove> FloorPos = new List<FloorMove>();

    public List<int> inventoryItem = new List<int>();
    public int usingItem;               //손에 든 아이템

    public bool RoomChanging = false;   //방이동때 켜주는 변수
    public bool bPlayerMove = true;     //플레이어가 움직일수있는지 체크해주는 변수
    public bool flashOn = false;

    public GameObject Player;           //플레이어 관련 

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
