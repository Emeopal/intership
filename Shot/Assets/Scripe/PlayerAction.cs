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
    private GameObject PlayerGO;
    public AudioSource bgm;
    public AudioClip clip;
    void Start()
    {
        playerColl = GetComponent<Collider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        myRender = GetComponent<Renderer>();
        PlayerGO = GetComponent<GameObject>();
        bgm = GetComponent<AudioSource>();
        bgm.loop = false;
        bgm.clip = clip;
        playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
        life = 3;
    }

    void Update()
    {
        updatecheck();
        playerattack();
        deathcheck();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        playerjump();
        playerDown();
        FixedUpdateCheck();
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
            Destroy(PlayerGO, 3);
        }
    }


}
