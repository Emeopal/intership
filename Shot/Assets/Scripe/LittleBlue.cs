using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBlue : MonoBehaviour
{

    public float enemyMoveSpeed;
    public Collider2D LittleBlueColl;
    public Rigidbody2D LittleBlueRB;
    public GameObject Enemy_LittleBlue;
    public Animator EnemyAnim;
    public Transform leftpos;
    public Transform rightpos;
    public bool dead = false;
    private PickUpSpawn pickupspawner;
    public AudioSource bgm;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        LittleBlueColl = GetComponent<Collider2D>();
        LittleBlueRB = GetComponent<Rigidbody2D>();
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
            Destroy(Enemy_LittleBlue, 0.6f);
            pickupspawner.dropitems();
            EnemyAnim.SetTrigger("BeingAttack");
        }
    }

    void checkpos()
    {
        if (dead == false)
        {
            if (Enemy_LittleBlue.GetComponent<Transform>().localPosition.x > rightpos.localPosition.x)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }
            else if (Enemy_LittleBlue.GetComponent<Transform>().localPosition.x < leftpos.localPosition.x)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    void EnemyMove()
    {
        if (Enemy_LittleBlue.GetComponent<Transform>().localScale.x > 0)
        {
            LittleBlueRB.velocity = new Vector2(enemyMoveSpeed, 0);
        }
        else if (Enemy_LittleBlue.GetComponent<Transform>().localScale.x < 0)
        {
            LittleBlueRB.velocity = new Vector2(-enemyMoveSpeed, 0);
        }
    }
}