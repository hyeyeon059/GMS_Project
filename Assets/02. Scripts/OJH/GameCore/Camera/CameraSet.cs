using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraSet : MonoBehaviour
{
    [SerializeField]
    Volume volume;
    Vignette vignette;
    private void Awake()
    {
        volume.profile.TryGet<Vignette>(out vignette);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Fades(3,1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Fades(3, 0);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            AutoFloorFading();
        }
    }

    //페이드 실행함수
    void Fades(float time,float endvalue)
    {
        Vector2 endvect = new Vector2(0.5f, endvalue);
        StartCoroutine(Setfadevect(0, vignette.center.value, endvect));
        StartCoroutine(Setfadeinten(time,vignette.intensity.value,endvalue));
        StartCoroutine(Setfadevect(6,vignette.center.value, new Vector2(0.5f,0.5f)));
        StartCoroutine(Setfadeinten(time, vignette.intensity.value, 0,waitingtime:6f));
    }

    //층이동시 페이드 자동 완성
    void AutoFloorFading()
    {
        vignette.rounded.value = true;
        StartCoroutine(Setfadevect(3,vignette.center.value, new Vector2(0.5f, 1f)));
        StartCoroutine(Setfadeinten(3, vignette.intensity.value, 1,5));
        StartCoroutine(Setfadevect(9, vignette.center.value, new Vector2(0.5f, 0.5f)));
    }

    //층이동 할때 카메라 페이딩(pp사용, 빛효과)     //모드 == 5 일때는 그냥 자동저장된것 불러오기
    IEnumerator Setfadeinten(float settime,float startvalue, float endvalue,int mode = 0,float waitingtime = 0) 
    {
        yield return new WaitForSeconds(waitingtime);
        float nowtime=0;
        float setvalue = startvalue,smoothvalue = vignette.smoothness.value
                        ,nextsmooth = -0.05f;
        if (endvalue == 0)
            nextsmooth = 0.05f / settime;
        if (mode == 5)
            vignette.center.value = new Vector2(0.5f, 0.5f);
        while(setvalue != endvalue)
        {
            nowtime += 0.05f;
            setvalue = Mathf.Lerp(startvalue, endvalue, nowtime / settime);
            Mathf.Clamp(setvalue, 0, 1);
            vignette.intensity.value = setvalue;
            yield return new WaitForSeconds(0.05f);
        }
        if (mode == 5)
        {
            yield return new WaitForSeconds(9f);
            StartCoroutine(Setfadeinten(3,vignette.intensity.value, 0));
        }
    }

    //페이드 풀릴때 풀리기 시작하는부분 조정
    // X좌표 수정할때 이상하면 부르기 (멘션/DM pjh)
    IEnumerator Setfadevect(float time, Vector2 startvalue, Vector2 endvalue)  
    {
        vignette.center.value = new Vector2(vignette.center.value.x, vignette.center.value.y*-1);
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
            nowtime += 0.05f;
            setvalue = new Vector2(Mathf.Lerp(startvalue.x, endvalue.x, (1 - Mathf.Pow(1 - nowtime, 3)) / 1), Mathf.Lerp(startvalue.y, endvalue.y, (1 - Mathf.Pow(1 - nowtime, 3)) / 1));
            vignette.center.value = setvalue;
            yield return new WaitForSeconds(0.1f);
        }
        //vignette.center.value = new Vector2(setvalue.x , -setvalue.y);
    }
}
