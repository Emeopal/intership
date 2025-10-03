using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    
    public float ArrowSpeed;
    public Rigidbody2D ArrowRB;
    public Collider2D ArrowColl;
    private bool isStuck = false;
    private int flyingLayer;
    private int staticLayer;
    public int faceNum_1;
    
   
    // Start is called before the first frame update
    void Start()
    {
        ArrowColl = GetComponent<Collider2D>();
        ArrowRB = GetComponent<Rigidbody2D>();
        flyingLayer = LayerMask.NameToLayer("Player");
        staticLayer = LayerMask.NameToLayer("Weapon");
        ArrowRB.velocity = new Vector2(ArrowSpeed , 0);
    }

    // Update is called once per frame
    void Update()
    {
        check_2();
        
        if (isStuck)
        {
            ArrowRB.velocity = new Vector2(0, 0);
        }
        
        else
        {
            ArrowRB.velocity = new Vector2(ArrowSpeed * faceNum_1, ArrowRB.velocity.y);
        }
        
        check_1();
    }
    
    void check_1()
    {
        if (!ArrowColl.gameObject.CompareTag("Ground"))
        {
            Physics2D.IgnoreLayerCollision(flyingLayer,staticLayer,true);
        }
        else
        {
            isStuck = true;
        }
    }
    void check_2()
    {
        float faceNum = Input.GetAxisRaw("Horizontal");
        if (faceNum != 0)
        {
            transform.localScale = new Vector3(-faceNum, transform.localScale.y, transform.localScale.z);
            /*认为y和z默认*/
        }
        if (faceNum > 0)
        {
            faceNum_1 = 1;
        }
        else if (faceNum < 0)
        {
            faceNum_1 = -1;
        }





    }





}
