using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class TextManagerAction : MonoBehaviour
{
    public static TextManagerAction Instance;

    private GameObject _textCanvas;    
    private TextMeshProUGUI _name;
    private TextMeshProUGUI _text;
    private GameObject _next;
    private Sprite _item;
    private int _itemType;
    private Vector3Int _TileCellPos;
    private string[] _textBook = { };

    private Tilemap _tilemap;

    private int _textNumber = 0;

    private bool _isWriting = false;
    public bool OnText
    {
        get => _textCanvas.activeSelf;
    }

    private void Awake()
    {
        if (TextManagerAction.Instance == null)
        {
            Instance = this;
        }
        _tilemap = GameObject.Find("MapGrid/Interaction").GetComponent<Tilemap>();
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

    public void PopText(string name, string[] text, Sprite s, int itemType, Vector3 pos)
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
        _item = s;
        _itemType = itemType;
        _TileCellPos = _tilemap.WorldToCell(pos);
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
        if (_textNumber >= _textBook.Length)
        {
            _textCanvas.SetActive(false);
            if (GameManager.Instance != null)
            {
                GameManager.Instance.bPlayerMove = true;
            }
            if (_item != null)
            {
                if (_itemType == 0)
                    UIManager.Instance.ActiveItemAdd(_item);
                else if (_itemType == 1)
                    UIManager.Instance.PassiveItemAdd(_item);
                _item = null;
                _tilemap.SetTile(_TileCellPos, null);
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
