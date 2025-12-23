using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakMap : MonoBehaviour
{
    public Collider2D Coll;
    public Animator Anim;
    private float timecount;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        Coll = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisableBoxCollider2D()
    {
        Coll.enabled = false;
    }

    void DestroyPlatform()
    {
        Destroy(gameObject,0);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Foot"))
        {
            Anim.SetTrigger("Break");
        }
    }
}
