using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pass : MonoBehaviour
{
    private int LevelScore = 0;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTrigger2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoldCoin"))
        {
            LevelScore += 150;
            ScoreText.text = "LevelScore:        " + LevelScore;
        }else if (collision.gameObject.CompareTag("SilverCoin"))
        {
            LevelScore += 100;
            ScoreText.text = "LevelScore:        " + LevelScore;
        }
    }
}
