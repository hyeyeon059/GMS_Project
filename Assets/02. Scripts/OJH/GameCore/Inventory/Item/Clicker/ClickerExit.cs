using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerExit : MonoBehaviour
{
    [SerializeField]
    GameObject[] clicker;


    [SerializeField]
    TextBock _interaction;

    public void Exit()
    {
        GameManager.Instance.bPlayerMove = true;
        clicker[0].SetActive(false);
        if (Clicker.click == 0)
        {
            TextManagerAction.Instance.PopText(_interaction.Name, _interaction.Texts, _interaction.Item, (int)_interaction.ItemType, _interaction.transform.position, _interaction.ItemNumber);
            if (_interaction.Item != null)
            {
                _interaction.gameObject.SetActive(false);
            }
        }
    }
}