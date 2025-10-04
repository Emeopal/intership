using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{

    public GameObject arrowPrefab;
    public float speed;
    public Transform arrowStart;
    public Collider2D Coll;
    private Vector3 StartPosition;
    public bool ArrowExist;
    public int i = 1;
    public List<GameObject> Arrows;
    public LayerMask Ground;
    public Transform Head;
    public Collider2D PlayerCollider;
    public LayerMask PlayerMask;
    

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
            
            GameObject arrow= Instantiate(arrowPrefab, arrowStart.position, transform.rotation);
            
            Arrows.Add(arrow);

            foreach(GameObject i in Arrows){
                

                if (Physics2D.OverlapBox(Head.position, new Vector2(0.1f, 0.1f), Ground)){
                    Destroy(i, 5);
                }
                /*if(Physics2D.OverlapBox(Head.position, new Vector2(0.1f, 0.1f), PlayerMask))
                {
                   
                    
                }*/
                
            }
        }
    }
    
    
}
