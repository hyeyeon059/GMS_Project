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

    public void Floormove(int value=0) => StartCoroutine(AutoFloorFading(value));
    public void Flashon() => vignette.intensity.value -= 0.25f;
    public void Flashoff() => vignette.intensity.value += 0.25f;


    private void Awake()
    {
        volume.profile.TryGet<Vignette>(out vignette);
    }

    private void Update()
    {
        if(GameManager.Instance.RoomChanging)
        {
            Floormove(GameManager.Instance.NowFloor);
            GameManager.Instance.RoomChanging = false;
        }
    }

    //���̵� �����Լ�
    void Fades(float time,float endvalue)
    {
        Vector2 endvect = new Vector2(0.5f, endvalue);
        StartCoroutine(Setfadevect(0, vignette.center.value, endvect));
        StartCoroutine(Setfadeinten(time,vignette.intensity.value,endvalue));  
        StartCoroutine(Setfadevect(2,vignette.center.value, new Vector2(0.5f,0.5f)));
        StartCoroutine(Setfadeinten(time, vignette.intensity.value, 0,waitingtime:2f));
    }

    //���̵��� ���̵� �ڵ� �ϼ�
    public IEnumerator AutoFloorFading(int floor=0)
    {
        float endValue=0;
        endValue = floor == 0 ? 0.5f : 0;   //���Ͽ����� �ֺ� �����ִ�����
        vignette.color.value = new Color(0, 0, 0);
        GameManager.Instance.RoomChanging = true;
        StartCoroutine(Setfadeinten(1.5f, vignette.intensity.value, 1));
        yield return StartCoroutine(Setfadevect(0, vignette.center.value, new Vector2(0.5f, 1)));
        vignette.center.value = new Vector2(Setvect(vignette.center.value.x), Setvect(vignette.center.value.y));
        //player.transform.position = GameManager.Instance.FloorPos(floor);
        if (floor == 0) SetfadeColor(1.5f);
        StartCoroutine(Setfadeinten(1.5f, vignette.intensity.value, endValue, waitingtime: 2f));
        yield return StartCoroutine(Setfadevect(1.5f, vignette.center.value, new Vector2(0.5f, 0.5f)));
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.bPlayerMove = true;
    }

    IEnumerator SetfadeColor(float settime)
    {
        float nowtime = 0;
        float cEach;
        while (nowtime != settime)
        {
            nowtime += 0.1f;
            cEach = Mathf.Lerp(0, 0.235f, nowtime / settime);
            vignette.color.value = new Color(cEach, cEach, cEach);
            yield return new WaitForSeconds(0.1f);
        }
    }
    //���̵� �Ҷ� ī�޶� ���̵�(pp���, ��ȿ��)
    //settime => ����ð�/2, startvaule => ���ڵ� ������� vignette.intensity.value , endvalue => ��ȯ�ϰ��� �ϴ°� 
    //waitingtime => fade ��������� �ð�
    IEnumerator Setfadeinten(float settime,float startvalue, float endvalue,float waitingtime = 0) 
    {
        yield return new WaitForSeconds(waitingtime);
        float nowtime=0;
        float setvalue = startvalue;
        while(setvalue != endvalue)
        {
            nowtime += 0.05f;
            //easing ��  nowtime == 0 ? 0 : Math.pow(2, 10 * nowtime - 10);
            setvalue = Mathf.Lerp(startvalue, endvalue, nowtime / settime);
            Mathf.Clamp(setvalue, 0, 1);
            vignette.intensity.value = setvalue;
            yield return new WaitForSeconds(0.05f);
        }
    }

    //���̵� Ǯ���� Ǯ���� �����ϴºκ� ����
    // X��ǥ �����Ҷ� �̻��ϸ� �θ��� (���/DM pjh)
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
