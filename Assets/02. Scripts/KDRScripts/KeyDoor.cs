using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NeedItem
{
    LockPick = 2,
    IDCard = 3,
    Key = 5,
    CardKey = 6,
    MasterKey = 7
}

public class KeyDoor : MonoBehaviour
{
    private TextBock _textBock;

    [SerializeField]
    private NeedItem _needItem;

    private void Awake()
    {
        _textBock = GetComponent<TextBock>();
    }

    private void Update()
    {
        if (GameManager.Instance.inventoryItem.Contains((int)_needItem))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            TextManagerAction.Instance.PopText(_textBock.Name, _textBock.Texts, _textBock.Item, (int)_textBock.ItemType, _textBock.transform.position, _textBock.ItemNumber);
            if (_textBock.Item != null)
            {
                _textBock.gameObject.SetActive(false);
            }
        }
    }
}
