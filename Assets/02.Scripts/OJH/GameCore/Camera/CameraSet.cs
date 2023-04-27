using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraSet : MonoBehaviour
{
    [SerializeField]
    Volume volume;
    Vignette vignette;
    //Player 

    void Floormove(int value=0) => StartCoroutine(AutoFloorFading(value));

    private void Awake()
    {
        volume.profile.TryGet<Vignette>(out vignette);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fades(1,1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Fades(3, 0);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Floormove(1);
        }
    }

    //페이드 실행함수
    void Fades(float time,float endvalue)
    {
        Vector2 endvect = new Vector2(0.5f, endvalue);
        StartCoroutine(Setfadevect(0, vignette.center.value, endvect));
        StartCoroutine(Setfadeinten(time,vignette.intensity.value,endvalue));  
        StartCoroutine(Setfadevect(2,vignette.center.value, new Vector2(0.5f,0.5f)));
        StartCoroutine(Setfadeinten(time, vignette.intensity.value, 0,waitingtime:2f));
    }

    //층이동시 페이드 자동 완성
    public IEnumerator AutoFloorFading(int floor=0)
    {
        GameManager.Instance.RoomChanging = true;
        StartCoroutine(Setfadeinten(1.5f, vignette.intensity.value, 1));
        yield return StartCoroutine(Setfadevect(0, vignette.center.value, new Vector2(0.5f, 1)));
        vignette.center.value = new Vector2(Setvect(vignette.center.value.x), Setvect(vignette.center.value.y));
        //player.transform.position = GameManager.Instance.FloorPos(floor);
        StartCoroutine(Setfadeinten(1.5f, vignette.intensity.value, 0, waitingtime: 2f));
        StartCoroutine(Setfadevect(1.5f, vignette.center.value, new Vector2(0.5f, 0.5f)));
    }

    //층이동 할때 카메라 페이딩(pp사용, 빛효과)
    //settime => 재생시간/2, startvaule => 이코드 실행시의 vignette.intensity.value , endvalue => 변환하고자 하는값 
    //waitingtime => fade 실행까지의 시간
    IEnumerator Setfadeinten(float settime,float startvalue, float endvalue,float waitingtime = 0) 
    {
        yield return new WaitForSeconds(waitingtime);
        float nowtime=0;
        float setvalue = startvalue;
        while(setvalue != endvalue)
        {
            nowtime += 0.05f;
            setvalue = Mathf.Lerp(startvalue, endvalue, nowtime / settime);
            Mathf.Clamp(setvalue, 0, 1);
            vignette.intensity.value = setvalue;
            yield return new WaitForSeconds(0.05f);
        }
    }

    //페이드 풀릴때 풀리기 시작하는부분 조정
    // X좌표 수정할때 이상하면 부르기 (멘션/DM pjh)
    IEnumerator Setfadevect(float time, Vector2 startvalue, Vector2 endvalue)  
    {
        yield return new WaitForSeconds(time);
        Vector2 setvalue = startvalue;
        float nowtime=0;
        if (endvalue.x > 0.5f)
        {
            endvalue.x += 0.5f;
        }
        else if (endvalue.x < 0.5f)
        {
            endvalue.x -= 0.5f;
        }
        if (endvalue.y > 0.5f)
        {
            endvalue.y += 0.5f;
        }
        else if (endvalue.y < 0.3f)
        {
            endvalue.y -= 0.5f;
        }
        while (setvalue != endvalue)
        {
            nowtime += 0.1f;
            setvalue = new Vector2(Mathf.Lerp(startvalue.x, endvalue.x, (1 - Mathf.Pow(1 - nowtime, 3)) / 1), Mathf.Lerp(startvalue.y, endvalue.y, (1 - Mathf.Pow(1 - nowtime, 3)) / 1));
            vignette.center.value = setvalue;
            yield return new WaitForSeconds(0.1f);
        }
    }

    float Setvect(float value)
    {
        return value switch
        {
            >= 1 => -1.5f,
            <= 0 => 1.5f,
            _ => value
        };
    }
}
