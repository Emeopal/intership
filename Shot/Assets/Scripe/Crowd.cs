using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowd : MonoBehaviour
{
    public Rigidbody2D CrowdRB;
    public float Speed;
    public GameObject Crowd_1;
    public float x;
    // Start is called before the first frame update
    void Start()
    {
        CrowdRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CrowdMove();
        check();
    }

    void CrowdMove()
    {
        CrowdRB.velocity = new Vector2(Speed,CrowdRB.velocity.y);
    }

    void check()
    {
        if (transform.position.x < x)
        {
            Debug.Log("准备调整位置");
            transform.position = new Vector3(x:30,y:transform.position.y);
        }
    }

}
