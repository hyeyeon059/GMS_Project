using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    private GameObject _movingLine;
    private GameObject _target;

    private RectTransform _lineRT;
    private RectTransform _targetRT;

    private float _time = 1f;
    [SerializeField]
    private float _speed = 1.5f;

    [SerializeField]
    private int count = 4;

    [SerializeField]
    private GameObject _effect;

    [SerializeField]
    TextBock _text;

    float current;
    float percent;

    private void Awake()
    {
        _target = transform.Find("Piano/QTE/Target").gameObject;
        _targetRT = _target.GetComponent<RectTransform>();
        _movingLine = transform.Find("Piano/QTE/Line").gameObject;
        _lineRT = _movingLine.GetComponent<RectTransform>();
        current = 0;
        percent = 0;
    }

    void Start()
    {
        StartCoroutine("Moving");

        _targetRT.localPosition = new Vector3(Random.Range(-800f, 800f), 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Mathf.Abs(_targetRT.localPosition.x - _lineRT.localPosition.x) < 120f)
            {
                var effect = Instantiate(_effect, _movingLine.transform);
                effect.transform.position = _targetRT.transform.position;
                _targetRT.localPosition = new Vector3(Random.Range(-800f, 800f), 0, 0);
                count--;
                _speed += 0.2f;
                if (count <= 0)
                {
                    QTEEND();
                }
            }
        }
    }

    IEnumerator Moving()
    {
        while (percent < 1)
        {
            current += Time.deltaTime * _speed;
            percent = current / _time;
            _lineRT.localPosition = new Vector3(Mathf.Lerp(-920f, 920f, percent), 0, 0);
            yield return null;
        }
        while (percent > 0)
        {
            current -= Time.deltaTime * _speed;
            percent = current / _time;
            _lineRT.localPosition = new Vector3(Mathf.Lerp(-920f, 920f, percent), 0, 0);
            yield return null;
        }
        StartCoroutine("Moving");
    }

    private void QTEEND()
    {
        TextManagerAction.Instance.PopText(_text.Name, _text.Texts, _text.Item, (int)_text.ItemType, _text.transform.position, _text.ItemNumber);
        if (_text.Item != null)
        {
            _text.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        GameManager.Instance.bPlayerMove = true;
    }
}
