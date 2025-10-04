using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Windows;


public class Arrow : MonoBehaviour
{
    public bool leftorright;
    public float ArrowSpeed;
    private Rigidbody2D ArrowRB;
    private Collider2D ArrowColl;
    private int flyingLayer;
    private int staticLayer;
    public float speed;
    public bool isStuck_G=false;
    public LayerMask Ground;
    public Transform Head;
 
    
        // Start is called before the first frame update
    void Start()
    {
        leftorright = true;
        ArrowColl = GetComponent<Collider2D>();
        ArrowRB = GetComponent<Rigidbody2D>();
        float faceNum = UnityEngine.Input.GetAxisRaw("Horizontal");
        speed = faceNum * ArrowSpeed;
        ArrowRB.velocity = new Vector2(speed,ArrowRB.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
        maintiandirection();
        
        
    }
    
    void maintiandirection()
    {
        if (ArrowRB.velocity.x>0)
        {
            ArrowRB.velocity = new Vector2(ArrowSpeed,ArrowRB.velocity.y);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
   
        else if(ArrowRB.velocity.x <0)
        {
            ArrowRB.velocity = new Vector2(-ArrowSpeed, ArrowRB.velocity.y);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else if(ArrowRB.velocity.x == 0)
        {
            if (UnityEngine.Input.GetKeyDown("d"))
            {
                leftorright = true;
            }
            else if (UnityEngine.Input.GetKeyDown("a"))
            {
                leftorright = false;
            }

            if (leftorright)
            {
                ArrowRB.velocity = new Vector2(ArrowSpeed, ArrowRB.velocity.y);
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if(!leftorright)
            {
                ArrowRB.velocity = new Vector2(-ArrowSpeed, ArrowRB.velocity.y);
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    
}
