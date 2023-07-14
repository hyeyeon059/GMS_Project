using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Active = 0,
    Passive = 1
}

public class TextBock : MonoBehaviour
{
    [SerializeField]
    public string Name;
    [Multiline]
    public string[] Texts;
    [SerializeField]
    public Sprite Item;
    [SerializeField]
    public ItemTypes ItemType = ItemTypes.Active;
    [SerializeField]
    public int ItemNumber = 0;
}
