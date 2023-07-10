using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class UIManager : MonoBehaviour
{
    static public UIManager Instance;

    private KeyCode[] numberKeyCodes =
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
        KeyCode.Alpha7,
        KeyCode.Alpha8,
        KeyCode.Alpha9,
    };

    private GameObject _itemCanvas;
    private GameObject _activeItem;
    private GameObject _passiveItem;
    private GameObject _itemZoomBack;
    private Image _itemZoom;

    private void Awake()
    {
        if (UIManager.Instance == null)
        {
            Instance = this;
        }
        _itemCanvas = GameObject.Find("ItemCanvas");
        _activeItem = _itemCanvas.transform.Find("ItemBar/ActiveItems").gameObject;
        _passiveItem = _itemCanvas.transform.Find("ItemBar/PassiveItems").gameObject;
        _itemZoomBack = _itemCanvas.transform.Find("ItemZoomBack").gameObject;
        _itemZoom = _itemZoomBack.transform.Find("ItemZoom").GetComponent<Image>();
    }

    public void ActiveItemAdd(Sprite s)
    {
        for (int i = 0; i < _activeItem.transform.childCount; i++)
        {
            if (_activeItem.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite.name == "Null")
            {
                _activeItem.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = s;
                break;
            }
        }
    }

    public void PassiveItemAdd(Sprite s)
    {
        for (int i = 0; i < _passiveItem.transform.childCount; i--)
        {
            if (_passiveItem.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite.name == "Null")
            {
                _passiveItem.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = s;
                break;
            }
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(numberKeyCodes[i]))
            {
                if (((TextManagerAction.Instance.OnText || !GameManager.Instance.bPlayerMove) && !_itemZoomBack.activeSelf) || _activeItem.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite.name == "Null")
                {
                    break;
                }
                if (_itemZoomBack.activeSelf && _itemZoom.sprite == _activeItem.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite)
                {
                    _itemZoomBack.SetActive(false);
                    GameManager.Instance.bPlayerMove = true;
                    break;
                }
                _itemZoomBack.SetActive(true);
                _itemZoom.sprite = _activeItem.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite;
                GameManager.Instance.bPlayerMove = false;
            }
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && _itemZoomBack.activeSelf)
        {
            _itemZoomBack.SetActive(false);
            GameManager.Instance.bPlayerMove = true;
        }
    }
}
