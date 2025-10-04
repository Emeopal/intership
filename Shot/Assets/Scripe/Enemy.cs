using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Transform target;
    public float enemyMoveSpeed;
    public Collider2D LittleGreenColl;
    public Rigidbody2D LittleGreenRB;
    public GameObject Enermy;
    
    // Start is called before the first frame update
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").transform;
        LittleGreenColl = GetComponent<Collider2D>();
        LittleGreenRB = GetComponent<Rigidbody2D>();
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FollowPlayer()
    {
        transform.position=Vector2.MoveTowards(transform.position,target.position,enemyMoveSpeed*Time.deltaTime);
    }

    void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(Enermy, 3);
        }
    }
}
