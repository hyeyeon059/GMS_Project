using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    private GameObject _movingLine;
    private GameObject _target;

    private float _time = 1f;
    private float _speed = 1;

    private int count = 4;


    float current;
    float percent;

    private void Awake()
    {
        _target = transform.Find("QTEBar/Target").gameObject;
        _movingLine = transform.Find("QTEBar/Line").gameObject;
        current = 0;
        percent = 0;
    }

    void Start()
    {
        StartCoroutine("Moving");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ((_movingLine.transform.localPosition - _target.transform.localPosition).magnitude < 0.1f)
            {
                count--;
                _speed += 0.3f;
                if (count <= 0)
                {
                    StopCoroutine("Moving");
                    QTEEND();
                }
                _target.transform.localPosition = new Vector3(Random.Range(-0.4f, 0.4f), 0, 0);
                Debug.Log("명중");
            }
        }
    }

    IEnumerator Moving()
    {
        while (percent < 1)
        {
            current += Time.deltaTime * _speed;
            percent = current / _time;
            _movingLine.transform.localPosition = new Vector3(Mathf.Lerp(-0.5f, 0.5f, percent), 0, 0);
            yield return null;
        }
        while (percent > 0)
        {
            current -= Time.deltaTime * _speed;
            percent = current / _time;
            _movingLine.transform.localPosition = new Vector3(Mathf.Lerp(-0.5f, 0.5f, percent), 0, 0);
            yield return null;
        }
        StartCoroutine("Moving");
    }

    private void QTEEND()
    {
        Debug.Log("성공");
        gameObject.SetActive(false);
    }
}
