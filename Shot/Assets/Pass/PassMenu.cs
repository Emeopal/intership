using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassMenu : MonoBehaviour
{
    public GameObject PassdMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PassdMenu.activeInHierarchy)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                continuetonext();
            }
        }
    }

    public void continuetonext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void endgame()
    {
        SceneManager.LoadScene(0);
    }
    
}
