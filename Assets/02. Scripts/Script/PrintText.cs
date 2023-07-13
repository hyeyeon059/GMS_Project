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
        "���ΰ�",
        "???",
        "���ΰ�",
        " ",
        "���ΰ�",
        "???",
        "���ΰ�",
        "������",
        "���ΰ�",
    };
    //private string[][] _textArr;

    string[][] text =
    {
        new string[] {
            "��... �̳� �����.",
            "������� �ǳ� �߱ٽ�Ű�� ȸ��� �����ӱ����� �����ؼ� �߱����ص� ������ �����."
        },
        new string[] {
            "(��������)"
        },
        new string[] {
            "(...? ���� �������?)",
        },
        new string[] {
            "(�ڸ� ����)"
        },
        new string[] {
            "��..���� �ƹ��͵� ���ݾ�? �̰� ���� ��г��ڳ�...",
            "�ǰ��ؼ� ����� �鸮��",
            "�׷��� ������ �������̴ϱ�",
            "������ �����ڰ� �Ϸ����� �����̳� �ؾ���"
        },
        new string[] {
            "(��������)"
        },
        new string[] {
            "��¥ ������!"
        },
        new string[] {
            "�Ƹ������п�"
        },
        new string[] {
            "�� ����... �׳� ������ �ݾ�...?",
            "...? ��ø�...",
            "������ �߼Ҹ��� ����.."
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
            //���� ��
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
