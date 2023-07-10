using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerExit : MonoBehaviour
{
    [SerializeField]
    GameObject[] Clicker;


    [SerializeField]
    TextBock _interaction;

    public void Exit()
    {
        GameManager.Instance.bPlayerMove = true;
        Clicker[0].SetActive(true);
        Clicker[1].SetActive(false);
        Clicker[2].SetActive(false);
        if (GameManager.Instance.inventoryItem.Contains(1))
        {
            TextManagerAction.Instance.PopText(_interaction.Name, _interaction.Texts, _interaction.Item, (int)_interaction.ItemType, _interaction.transform.position);
            if (_interaction.Item != null)
            {
                _interaction.gameObject.SetActive(false);
            }
        }
    }
}