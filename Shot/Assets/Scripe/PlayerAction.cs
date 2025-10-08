using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("水平移动")]
    public float playermovespeed;
    [Header("跳跃")]
    public float playerjumpspeed;
    public int playerjumpcount;
    public bool isjump;
    public bool pressjump;
    [Header("判断是否落地")]
    public LayerMask Ground;
    public bool isGround;
    public Transform foot;
    public Rigidbody2D playerRB;
    public Collider2D playerColl;
    public Animator playerAnim;
    private Renderer myRender;
    public int numblinks;
    public float seconds;
    public int life;
    public Animator LifeAnim;
    private bool isAttacted;
    public GameObject PlayerGO;
    public AudioSource bgm;
    public AudioClip clip;
    //buff
    private float time_1;
    private float time_2;
    private float time_3;
    public AudioSource bgm_1;
    public AudioClip clip_1;
    void Start()
    {
        playerColl = GetComponent<Collider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        myRender = GetComponent<Renderer>();
        bgm.loop = false;
        bgm.clip = clip;
        bgm_1.loop = false;
        bgm_1.clip = clip_1;
        playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
        life = 3;
    }

    void Update()

    {
        updatecheck();
        playerattack();
        deathcheck();
        checkposition();
        checkBuff();
        doBuff();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        playerjump();
        playerDown();
        FixedUpdateCheck();
    }

    private void checkposition()
    {
        Vector3 pos = transform.position;
        if (pos.x<-15)
        {
            pos.x += 30;
        }
        else if (pos.x > 15)
        {
            pos.x -= 30;
        }
        if (pos.y < -4)
        {
            pos.y += 8;
        }
        else if (pos.y > 4)
        {
            pos.y -= 8;
        }
        transform.position = pos;
        

    }

    void PlayerMove()
    {
        float horizontalNum = Input.GetAxis("Horizontal");
        float faceNum = Input.GetAxisRaw("Horizontal");
        playerRB.velocity = new Vector2(playermovespeed * horizontalNum, playerRB.velocity.y);
        playerAnim.SetFloat("run",Mathf.Abs(playermovespeed*horizontalNum));
        if (faceNum != 0)
        {
            transform.localScale = new Vector3(faceNum, transform.localScale.y, transform.localScale.z);
                                                     /*认为y和z默认*/
        }
    }
    void playerjump()
    {
        if (isGround)
        {
            playerAnim.SetBool("jump", false);
        }
        else
        {
            playerAnim.SetBool("jump", true);
        }
        if (isGround && isjump == false)
        {
            playerjumpcount = 1;
        }

        if (pressjump)
        {
            pressjump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerjumpspeed);
            playerjumpcount--;
        }
        if (playerRB.velocity.y < 1)
        {
            isjump = false;
        }
    }

    void playerDown()
    {
        playerAnim.SetFloat("y.speed",playerRB.velocity.y);
    }

    void playerattack()
    {
        if (Input.GetButton("Fire1"))
        {
            playerAnim.SetTrigger("attack");
        }
    }

    void FixedUpdateCheck()
    {
        if (Physics2D.OverlapCircle(foot.position, 0.1f, Ground))
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }
    }
    

    void updatecheck()
    {
        if (Input.GetButtonDown("Jump")&&playerjumpcount>0)
        {
            isjump = true;
            pressjump = true;
        }
    }

    void BlinkPlayer(int numblinks,float seconds)
    {
        StartCoroutine(DoBlinks(numblinks,seconds));
        
    }

    IEnumerator DoBlinks(int numblinks,float seconds)
    {
        for(int i = 0; i < numblinks * 2; i++)
        {
            myRender.enabled = !myRender.enabled;
            yield return new WaitForSeconds(seconds);
            if (i==2) {
                playerAnim.SetBool("hurt", false);
            }
        }
        yield return new WaitForSeconds(1f);
        isAttacted = false;
    }
   

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&&isAttacted==false)
        {
            bgm.Play();
            isAttacted = true;
            life--;
            playerRB.velocity = new Vector2(playerRB.velocity.x,5);
            LifeAnim.SetInteger("Life", life);
            playerAnim.SetBool("hurt",true);
            BlinkPlayer(numblinks,seconds);
            
        }
    }

    void deathcheck()
    {
        if (life==0)
        {
            Destroy(PlayerGO, 0.6f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Buff_Life"))
        {
            bgm_1.Play();
            Destroy(collision.gameObject, 0);
            if (life < 3 && life > 0)
            {
                life++;
                LifeAnim.SetInteger("Life", life);
                
            }
        }
        else if (collision.CompareTag("Buff_Speed"))
        {
            bgm_1.Play();
            Destroy(collision.gameObject, 0);
            time_1 = 20;
        }
        else if (collision.CompareTag("Buff_NB"))
        {
            bgm_1.Play();
            Destroy(collision.gameObject, 0);
            time_2 = 20;
        }
        else if (collision.CompareTag("Buff_Fly"))
        {
            bgm_1.Play();
            Destroy(collision.gameObject, 0);
            time_3 = 20;
        }
    }

    void doBuff()
    {
        float speed_0 = playermovespeed;
        float speed_1 = playermovespeed * 2;
        time_1 -= Time.deltaTime;
        if (time_1 > 0)
        {
            playermovespeed = speed_1;
        }
        else
        {
            playermovespeed = speed_0;
        }
        time_2 -= Time.deltaTime;
        if (time_2 > 0)
        {
            isAttacted = true;
        }
        if (time_2 < 0 && time_2 > 0.1f)
        {
            isAttacted = false;
        }
        time_3 -= Time.deltaTime;
        if (time_3 > 0)
        {
            playerjumpcount = 1;
        }
    }

    void checkBuff()
    {
        if (time_1 > time_2)
        {
            time_2 = 0;
        }
        else
        {
            time_1 = 0;
        }
        if (time_2 > time_3)
        {
            time_3 = 0;
        }
        else
        {
            time_2 = 0;
        }
        if (time_3 > time_1)
        {
            time_1 = 0;
        }
        else
        {
            time_3 = 0;
        }
    }
}
