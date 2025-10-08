using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBlack : MonoBehaviour
{

    public float enemyMoveSpeed;
    public Collider2D LittleBlackColl;
    public Rigidbody2D LittleBlackRB;
    public GameObject Enemy_LittleBlack;
    public Animator EnemyAnim;
    public Transform leftpos;
    public Transform rightpos;
    public Transform jumppos;
    public bool dead = false;
    private PickUpSpawn pickupspawner;
    public AudioSource bgm;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        LittleBlackColl = GetComponent<Collider2D>();
        LittleBlackRB = GetComponent<Rigidbody2D>();
        EnemyAnim = GetComponent<Animator>();
        pickupspawner = GetComponent<PickUpSpawn>();
        bgm = GetComponent<AudioSource>();
        bgm.clip = clip;
        bgm.loop = false;
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
            bgm.Play();
            dead = true;
            Destroy(Enemy_LittleBlack, 0.6f);
            pickupspawner.dropitems();
            EnemyAnim.SetTrigger("BeingAttack");
        }
    }

    void checkpos()
    {
        if (dead == false)
        {
            if (Enemy_LittleBlack.GetComponent<Transform>().localPosition.x > rightpos.localPosition.x)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
            else if (Enemy_LittleBlack.GetComponent<Transform>().localPosition.x < leftpos.localPosition.x)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }else if (Enemy_LittleBlack.GetComponent<Transform>().localPosition.x > jumppos.localPosition.x&&
                Enemy_LittleBlack.GetComponent<Transform>().localPosition.y< jumppos.localPosition.y)
             {
                EnemyAnim.SetBool("Jump",true);
                LittleBlackRB.velocity = new Vector2(LittleBlackRB.velocity.x,7);
             }
            if(LittleBlackRB.velocity .y<-0.1f)
            {
                EnemyAnim.SetBool("Jump", false);
            }
        }
    }

    void EnemyMove()
    {
        if (Enemy_LittleBlack.GetComponent<Transform>().localScale.x > 0)
        {
            LittleBlackRB.velocity = new Vector2(enemyMoveSpeed, LittleBlackRB.velocity.y);
        }
        else if (Enemy_LittleBlack.GetComponent<Transform>().localScale.x < 0)
        {
            LittleBlackRB.velocity = new Vector2(-enemyMoveSpeed, LittleBlackRB.velocity.y);
        }
    }
}


