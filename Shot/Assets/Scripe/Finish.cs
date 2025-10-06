using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public float detectionR;
    public LayerMask EnemyLayer;
    // Start is called before the first frame update
    void Start()
    {
        detectionR = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        check();
    }

    void check()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionR, EnemyLayer);
        if (hits.Length > 0)
        {
            foreach (Collider2D hit in hits)
            {
               // Debug.Log("ºÏ≤‚µΩµ–»À");
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
