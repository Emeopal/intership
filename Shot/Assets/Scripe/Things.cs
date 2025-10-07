using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Things : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource bgm;
    public GameObject Coin;
    public Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        coll = GetComponent<Collider2D>();
        bgm.loop = false;
        bgm.clip = clip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bgm.Play();
            Destroy(Coin,0);
        }
    }
}
