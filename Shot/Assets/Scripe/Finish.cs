using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject PassMenu;
    public float detectionR;
    public LayerMask EnemyLayer;
    private float TimeSum=0;
    private float DeadLine;
    // Start is called before the first frame update
    void Start()
    {
        detectionR = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }

    void Check()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionR, EnemyLayer);
        if (hits.Length > 0)
        {
            foreach (Collider2D hit in hits)
            {
                // Debug.Log("¼ì²âµ½µĞÈË");
            }
        }
        else
        {
            TimeSum += Time.deltaTime;
            if (TimeSum >= 3)
            {
                PassMenu.SetActive(true);
            }
        }
    }
}
