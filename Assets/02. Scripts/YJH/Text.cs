using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Text : MonoBehaviour
    
{
    string[] text = {"���� �����Դϴ�.", "������ �̿��� ������� �ӿ� ��ǰ�� ������ ���̺������� ������ ü������ϴ�",
        " �� �� ���忡 ���ݵǾ��� ��xx���� Ż��� �� ��ü�� ���µ���", "���ָ� ����� ���ε��� ���� �̿��� ���� ȯ���� ������","�ŵ��鿡�� ������ ������ ����� ���� �����ϴ�" ,
        " �������� ��xx���� ���� �������� ġ�Ḧ �ް� ������", "������ ������ ���� ������ ���������ϴ�", "���� ���� �Դϴ�...."};

 
    private void Awake()
    {
        
    }
    void Start()
    {
        TextManager.Instance.PopText("����",text);             
    }
    private void Update()
    {

       


    }



}
