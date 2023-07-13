using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEOn : MonoBehaviour
{
    [SerializeField]
    private GameObject _qte;

    public void QTE()
    {
        GameManager.Instance.bPlayerMove = false;
        _qte.SetActive(true);
    }
}
