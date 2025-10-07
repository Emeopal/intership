using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource bgm;
    public AudioClip clip;
    private void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.clip = clip;
        bgm.loop = true;
        bgm.Play();
    }

    private void Update()
    {
        
    }
    // Start is called before the first frame update

    public void Ready()
    {
        SceneManager.LoadScene(1);
    }
    
    
}
