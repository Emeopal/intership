using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Windows;


public class Arrow : MonoBehaviour
{
    
    public float ArrowSpeed;
    private Rigidbody2D ArrowRB;
    private Collider2D ArrowColl;
    public float speed;
    public bool isStuck_G=false;
    public GameObject Arrow_C;
    public Collider2D PlayerColl;
    public GameObject Player;
    public Renderer arrowrender;
 
    
        // Start is called before the first frame update
    void Start()
    {
        arrowrender = GetComponent<Renderer>();
        ArrowColl = GetComponent<Collider2D>();
        ArrowRB = GetComponent<Rigidbody2D>();
        float faceNum = UnityEngine.Input.GetAxisRaw("Horizontal");
        if (faceNum == 0)
        {
            if (Player.GetComponent<Transform>().localScale.x > 0)
            {
                faceNum = 1;
            }
            else
            {
                faceNum = -1;
            }
        }
        speed = faceNum * ArrowSpeed;
        ArrowRB.velocity = new Vector2(speed,ArrowRB.velocity.y);
        Physics2D.IgnoreCollision(PlayerColl, ArrowColl, true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        maintiandirection();
        

    }
    
    void maintiandirection()
    {
        if (isStuck_G == false)
        {
            if (ArrowRB.velocity.x > 0)
            {
                ArrowRB.velocity = new Vector2(ArrowSpeed, ArrowRB.velocity.y);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }

            else if (ArrowRB.velocity.x < 0)
            {
                ArrowRB.velocity = new Vector2(-ArrowSpeed, ArrowRB.velocity.y);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            
        }else if (isStuck_G == true)
        {
            //ArrowRB.velocity = new Vector2(0, 0);
            this.enabled = false;
            ArrowRB.isKinematic = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Destroy(Arrow_C, 0.0f);
            }
            if (collision.gameObject.CompareTag("Ground"))
            {
                Destroy(Arrow_C, 5);
                isStuck_G = true;
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Physics2D.IgnoreCollision(PlayerColl,ArrowColl,true);
            }
    }




}
