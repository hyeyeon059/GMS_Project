using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uimanager : MonoBehaviour
{
    public GameObject escpanel;

    private void Awake()
    {
        escpanel.SetActive(false);
    }
    public void Update()
    {
        esc();
    }
    public void esc()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("dkdk");
            escpanel.SetActive(true);
        }
    }
    public void exitBtn()
    {
        Application.Quit();
        Debug.Log("exit");
         
    }
    public void titlebtn()
    {
        SceneManager.LoadScene("Start");
    }
    public void x()
    {
        escpanel.SetActive(false);
    }
   
   
}
