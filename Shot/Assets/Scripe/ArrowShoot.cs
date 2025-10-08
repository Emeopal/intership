using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public GameObject Player;
    public GameObject arrowPrefab;
    public float speed;
    public Transform arrowStart;
    private Vector3 StartPosition;
    public int i = 1;
    public List<GameObject> Arrows;
    public LayerMask Ground;
    public LayerMask PlayerMask;
    public bool check=false;
    public AudioSource bgm;
    public AudioClip clip;


    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.clip = clip;
        bgm.loop = false;
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {

        shoot();
    }

    void shoot()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            bgm.Play();
            GameObject arrow= Instantiate(arrowPrefab, arrowStart.position, transform.rotation);
            
        }
    }
    


}
