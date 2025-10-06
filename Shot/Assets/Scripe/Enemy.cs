using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float enemyMoveSpeed;
    public Collider2D LittleGreenColl;
    public Rigidbody2D LittleGreenRB;
    public GameObject Enemy_LittleGreen;
    public Animator EnemyAnim;
    public Transform leftpos;
    public Transform rightpos;
    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {

        LittleGreenColl = GetComponent<Collider2D>();
        LittleGreenRB = GetComponent<Rigidbody2D>();
        EnemyAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        checkpos();
        EnemyMove();
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            dead = true;
            Destroy(Enemy_LittleGreen, 0.6f);
            EnemyAnim.SetTrigger("BeingAttack");
        }
    }

    void checkpos()
    {
        if (dead == false)
        {
            if (Enemy_LittleGreen.GetComponent<Transform>().localPosition.x > rightpos.localPosition.x)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            else if (Enemy_LittleGreen.GetComponent<Transform>().localPosition.x < leftpos.localPosition.x)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    void EnemyMove()
    {
        if (Enemy_LittleGreen.GetComponent<Transform>().localScale.x > 0)
        {
            LittleGreenRB.velocity = new Vector2(enemyMoveSpeed, LittleGreenRB.velocity.y);
        } 
        else if(Enemy_LittleGreen.GetComponent<Transform>().localScale.x < 0)
        {
            LittleGreenRB.velocity = new Vector2(-enemyMoveSpeed, LittleGreenRB.velocity.y);
        }
    }
}

    
