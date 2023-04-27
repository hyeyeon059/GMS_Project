using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int NowFloor { get; set; }
    public List<GameObject> FloorPos = new List<GameObject>();

    public bool RoomChanging = false;
    public bool CanPlayerMove = true;
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
