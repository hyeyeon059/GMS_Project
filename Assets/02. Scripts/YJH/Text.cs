using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    string[] text = {"���� �����Դϴ�.", "������ �̿��� ������� �ӿ� ��ǰ�� ������ ���̺������� ������ ü������ϴ�",
        " �� �� ���忡 ���ݵǾ��� ��xx���� Ż��� �� ��ü�� ���µ���", "���ָ� ����� ���ε��� ���� �̿��� ���� ȯ���� ������","�ŵ��鿡�� ������ ������ ����� ���� �����ϴ�" ,
        " �������� ��xx���� ���� �������� ġ�Ḧ �ް� ������", "������ ������ ���� ������ ���������ϴ�", "���� ���� �Դϴ�...."};
    void Start()
    {
        TextManager.Instance.PopText("����",text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
