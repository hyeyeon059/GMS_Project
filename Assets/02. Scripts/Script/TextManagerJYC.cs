using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManagerJYC : MonoBehaviour
{
    public static TextManagerJYC Instance;

    private GameObject _textCanvas;
    private TextMeshProUGUI _name;
    private TextMeshProUGUI _text;
    private GameObject _next;
    private string[] _nameArr;
    private string[][] _textBook;
    private int _index = 0;

    private int _textNumber = 0;

    private bool _isWriting = false;
    public bool OnText
    {
        get => _textCanvas.activeSelf;
    }

    private void Awake()
    {
        if (TextManagerJYC.Instance == null)
        {
            Instance = this;
        }
        _textCanvas = GameObject.Find("TextCanvas/TextBackground");
        _name = _textCanvas.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        _text = _textCanvas.transform.Find("Text").GetComponent<TextMeshProUGUI>();
        _next = _textCanvas.transform.Find("Next").gameObject;
        _textCanvas.SetActive(false);
    }

    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && _textCanvas.activeSelf)
        {
            NextText();
        }
    }

    public void PopText(string[] name, string[][] text)
    {
        _textNumber = 0;
        _textCanvas.SetActive(true);
        _nameArr = name;
        _textBook = text;
        NextText();
    }

    public void NextText()
    {
        _name.text = _nameArr[_index];
                
        if (_isWriting)
        {
            SkipText();
            return;
        }

        _next.SetActive(false);
        if (_textNumber >= _textBook[_index].Length)
        {
            _index++;
            _textNumber = 0;
            if (_index >= _textBook.Length)
            {
                _textCanvas.SetActive(false);
                return;
            }
            _name.text = _nameArr[_index];
        }

        _text.text = "";
        StartCoroutine("TextPrint", 20);
        _textNumber++;
    }

    private void SkipText()
    {
        StopCoroutine("TextPrint");
        _text.text = _textBook[_index][_textNumber - 1];
        _isWriting = false;
        _next.SetActive(true);
    }

    IEnumerator TextPrint(int tps)
    {
        _isWriting = true;
        foreach (char c in _textBook[_index][_textNumber])
        {
            _text.text += c.ToString();
            yield return new WaitForSeconds(1f / tps);
        }
        _next.SetActive(true);
        _isWriting = false;
    }
}
