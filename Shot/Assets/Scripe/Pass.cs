using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pass : MonoBehaviour
{
    public int LevelScore = 0;
    public Text ScoreText;
    public Text TotalScore;
    public int totalscore;
    public AudioSource bgm;
    public AudioClip clip;
    // Start is called before the first frame update
    
    void Start()
    {
        bgm.loop = false;
        bgm.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GoldCoin"))
        {
            LevelScore += 100;
            ScoreText.text = "LevelScore:        " + LevelScore;
            Destroy(collision.gameObject,0);
            bgm.Play();
            DataManager.AddScore(100);
        }
        if (collision.CompareTag("SilverCoin"))
        {
            LevelScore += 50;
            ScoreText.text = "LevelScore:        " + LevelScore;
            Destroy(collision.gameObject,0);
            bgm.Play();
            DataManager.AddScore(50);
        }
        
        totalscore = DataManager.TotalScore;
        TotalScore.text = "TotalScore:        " + totalscore;
    }
}
