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
    void Start()
    {
        playerColl = GetComponent<Collider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
    }

    // Update is called once per frame
    void Update()
    {
        updatecheck();
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
            playerjumpcount = 1;
            playerAnim.SetBool("jump", false);
        }
        else
        {
            playerAnim.SetBool("jump", true);
        }

        if (pressjump)
        {
            pressjump = false;
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerjumpspeed);
            playerjumpcount--;
        }
    }

    void playerDown()
    {
        playerAnim.SetFloat("y.speed",playerRB.velocity.y);
    }

    void FixedUpdateCheck()
    {
        isGround = Physics2D.OverlapCircle(foot.position, 0.1f, Ground);
    }

    void updatecheck()
    {
        if (Input.GetButtonDown("Jump")&&playerjumpcount>0)
        {
            
            pressjump = true;
        }
    }
}
