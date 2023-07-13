using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrintText : MonoBehaviour
{
    [SerializeField]
    private GameObject _text;
    [SerializeField]
    private GameObject _blood;

    private Image _fade;

    private string[] _nameArr =
    {
        "주인공",
        "???",
        "주인공",
        " ",
        "주인공",
        "???",
        "주인공",
        "강아지",
        "주인공",
    };
    //private string[][] _textArr;

    string[][] text =
    {
        new string[] {
            "아... 겁나 힘들다.",
            "부장님은 맨날 야근시키고 회사는 포괄임금제를 선택해서 야근을해도 수당을 안줘요."
        },
        new string[] {
            "(저벅저벅)"
        },
        new string[] {
            "(...? 누가 따라오나?)",
        },
        new string[] {
            "(뒤를 돈다)"
        },
        new string[] {
            "뭐..뭐지 아무것도 없잖아? 이게 뭐야 기분나쁘네...",
            "피곤해서 헛것이 들리네",
            "그래도 내일은 공휴일이니까",
            "내일은 늦잠자고 하루종일 게임이나 해야지"
        },
        new string[] {
            "(저벅저벅)"
        },
        new string[] {
            "진짜 누구야!"
        },
        new string[] {
            "아르르르왈왈"
        },
        new string[] {
            "아 뭐야... 그냥 강아지 잖아...?",
            "...? 잠시만...",
            "강아지 발소리가 저ㄹ.."
        },
    };

    private void Awake()
    {
        _fade = _blood.GetComponent<Image>();
    }

    void Start()
    {
        TextManagerJYC.Instance.PopText(_nameArr, text);
    }

    void Update()
    {
        if (!_text.activeSelf && !_blood.activeSelf)
        {
            //사운드 깡
            _blood.SetActive(true);
            StartCoroutine("FadeOut");
        }
    }

    IEnumerator FadeOut()
    {
        while (_fade.color != Color.black)
        {
            _fade.color -= new Color(0.3f, 0.3f, 0.3f, -0.3f) * Time.deltaTime;
            yield return null;
            SceneManager.LoadScene("Main");
            yield return null;
        }
    }
}
