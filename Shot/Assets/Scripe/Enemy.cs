using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public int maxHP;
    public Transform target;
    public float enemyMoveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
}
