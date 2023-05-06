using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{
    private UIDocument _uiDocument;

    private void Awake()
    {
        _uiDocument = GetComponent<UIDocument>();

    }

    private void OnEnable()
    {
        VisualElement root = _uiDocument.rootVisualElement;

        VisualElement popup = root.Q("Popup");
        Button btn = root.Q<Button>("PopupBtn");

        btn.RegisterCallback<ClickEvent>(e =>
        {
            Time.timeScale = 0;
            popup.AddToClassList("PopUp");

        });

        root.RegisterCallback<ClickEvent>(e =>
        {
            Time.timeScale = 1;
            popup.RemoveFromClassList("PopUp");
        });
    }
}
