using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNext : MonoBehaviour
{
    private Image _sr;

    float _current = 0;
    float _persent = 0;
    int _p = 1;


    private void Awake()
    {
        _sr = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _current = 0;
        _persent = 0;
        _p = 1;
        _sr.color = new Color(1, 1, 1, _persent);
        StartCoroutine("Pulse");
    }

    IEnumerator Pulse()
    {
        while (true)
        {
            _current += Time.deltaTime * _p;
            _persent = Mathf.Pow(_current, 2) / 0.5f;
            if (_current > 1 || _current < 0)
            {
                _p *= -1;
                break;
            }
            _current = Mathf.Clamp(_current, 0, 1);
            _persent = Mathf.Clamp(_persent, 0, 1);
            _sr.color = new Color(1, 1, 1, _persent);
            yield return null;
        }
        StartCoroutine("Pulse");
    }
}
