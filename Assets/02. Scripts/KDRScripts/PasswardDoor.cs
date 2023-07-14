using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswardDoor : MonoBehaviour
{
    private CircleCollider2D circle;

    private GameObject _input;
    private TMP_InputField _inputText;

    [SerializeField]
    private string _pass;

    [SerializeField]
    public bool F = false;

    private TextBock _textBock;

    private void Awake()
    {
        _input = transform.GetChild(0).gameObject;
        _inputText = _input.transform.Find("Input").GetComponent<TMP_InputField>();
        _textBock = gameObject.GetComponent<TextBock>();
    }

    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            InputOn();
        }
    }

    public void InputOn()
    {
        GameManager.Instance.bPlayerMove = false;
        _input.SetActive(true);
    }

    public void InputExit()
    {
        Pass();
        _input.SetActive(false);
    }

    private void Pass()
    {
        if (_inputText.text.ToUpper() == _pass.ToUpper())
        {
            _inputText.text = "";
            TextManagerAction.Instance.PopText(_textBock.Name, _textBock.Texts, _textBock.Item, (int)_textBock.ItemType, _textBock.transform.position, _textBock.ItemNumber);
            if (_textBock.Item != null)
            {
                _textBock.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
        }
        else
        {
            GameManager.Instance.bPlayerMove = true;
        }
    }
}
