using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    string[] text = {"�� ������� ������ ���� Ż���̴�", "(�ָӴϿ��� usb�� ������)",
        " �� usb�� �Ű� �ؾ���", " ��� ����̳� ��������. �� ���� ���","�׷��� ���� ���� �ذ�..." ,
        " ������ �����?", "��... ��� �� �ð��̳�", "����. �ᱹ ������ �����ݾ�.", "�� ������ �� ����ع�������"};
    void Start()
    {
        TextManager.Instance.PopText("���ΰ�",text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
