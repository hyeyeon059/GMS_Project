using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    string[] text = {"이 빌어먹을 곳에서 드디어 탈출이다", "(주머니에서 usb를 꺼낸다)",
        " 이 usb로 신고 해야지", " 평생 콩밥이나 먹으라지. 그 썩을 놈들","그러고 보니 벌써 해가..." ,
        " 지금이 몇시지?", "아... 출근 할 시간이네", "젠장. 결국 쉬지도 못했잖아.", "그 ㅅㄲ들 싹 고소해버려야지"};
    void Start()
    {
        TextManager.Instance.PopText("주인공",text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
