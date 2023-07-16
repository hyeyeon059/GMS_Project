using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Text : MonoBehaviour
    
{
    string[] text = {"다음 뉴스입니다.", "마약을 이용해 사람들을 속여 금품을 갈취한 사이비종교가 경찰에 체포됬습니다",
        " 숲 속 별장에 감금되었던 주xx씨의 탈출로 그 실체가 들어났는데요", "교주를 비롯한 간부들은 약을 이용해 집단 환각을 일으켜","신도들에게 기행을 저지른 사실이 밝혀 졌습니다" ,
        " 생존자인 주xx씨는 현재 병원에서 치료를 받고 있으며", "생명에는 지장이 없는 것으로 밝혀졌습니다", "다음 뉴스 입니다...."};

 
    private void Awake()
    {
        
    }
    void Start()
    {
        TextManager.Instance.PopText("뉴스",text);             
    }
    private void Update()
    {

       


    }



}
