using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextManager : MonoBehaviour
{
    public static TextManager Instance;

    private GameObject _textCanvas;
    private TextMeshProUGUI _name;
    private TextMeshProUGUI _text;
    private GameObject _next;
    private string[] _textBook = { };

    private int _textNumber = 0;

    [SerializeField]
    private bool _sceneChange = false;

    private bool _isWriting = false;
    public bool OnText
    {
        get => _textCanvas.activeSelf;
    }

    private void Awake()
    {
        if (TextManager.Instance == null)
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
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            NextText();
        }
    }

    public void PopText(string name, string[] text)
    {
        if (_textCanvas.activeSelf)
        {
            return;
        }
        if (GameManager.Instance != null)
        {
            GameManager.Instance.bPlayerMove = false;
        }
            _textNumber = 0;
            _textCanvas.SetActive(true);
            _name.text = name;
            _textBook = text;
            NextText();
        
    }

    public void NextText()
    {
        if (_isWriting)
        {
            SkipText();
            return;
        }

        _next.SetActive(false);
        if (GameManager.Instance != null)
        {
            if (_textNumber >= _textBook.Length)
            {
                _textCanvas.SetActive(false);
                GameManager.Instance.bPlayerMove = true;
                return;
            }
        }

        if (_textNumber >= _textBook.Length)
        {
            _textCanvas.SetActive(false);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.bPlayerMove = true;
            }

            if (_sceneChange)
            {
                SceneManager.LoadScene("Start");
            }
            return;
        }

        _text.text = "";
            StartCoroutine("TextPrint", 20);
            _textNumber++;
        
        
    }

    private void SkipText()
    {
        StopCoroutine("TextPrint");
        _text.text = _textBook[_textNumber - 1];
        _isWriting = false;
        _next.SetActive(true);
    }

    IEnumerator TextPrint(int tps)
    {
        _isWriting = true;
        foreach (char c in _textBook[_textNumber])
        {
            _text.text += c.ToString();
            yield return new WaitForSeconds(1f / tps);
        }
        _next.SetActive(true);
        _isWriting = false;
    }

    
}
