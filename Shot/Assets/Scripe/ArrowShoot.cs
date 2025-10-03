using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{

    public GameObject arrowPrefab;
    public float speed;
    public Transform arrowStart;
    public Rigidbody2D ArrowRB;
    private Vector3 StartPosition;
    public Collider2D ArrowColl;
    public bool ArrowExist;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        shoot();
    }

    void shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ArrowExist = true;
            float faceNum = Input.GetAxisRaw("Horizontal");
            if (faceNum != 0)
            {
                transform.localScale = new Vector3(-faceNum, transform.localScale.y, transform.localScale.z);
                /*认为y和z默认*/
            }
            GameObject arrow = Instantiate(arrowPrefab, arrowStart.position, transform.rotation);
            ArrowColl = GetComponent<Collider2D>();
            ArrowRB = GetComponent<Rigidbody2D>();
            ArrowRB.velocity = transform.right * speed * faceNum;
            
        }
    }
    
}
