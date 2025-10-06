using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseManage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }

    public void Restore()
    {
        PauseManage.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PauseManage.activeInHierarchy)
            {
                //Debug.Log("esc±»°´ÏÂ");
                PauseManage.SetActive(true);
                Time.timeScale = 0;
                
            }else if (PauseManage.activeInHierarchy)
            {
                PauseManage.SetActive(false);
                Time.timeScale = 1;
            }
        }
    } 

    public void BacktoMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
