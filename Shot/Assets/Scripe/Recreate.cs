using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UI.Image;

public class Recreate : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> BTGO;
    public List<Transform> BTTF;
    public GameObject Origin;
    public List<float> timecount;
    public List<Vector3> postions;
    
    void Start()
    {
        for(int i=0;i<5; i++)
        {
            BTTF[i] = BTGO[i].GetComponent<Transform>();
            postions[i] = BTTF[i].position;
            timecount[i] = 5;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        checkexist();
        recreate();
    }

    public void checkexist()
    {
        for (int i = 0; i < 5; i++)
        {
            
            if (!BTGO[i])
            {
                timecount[i] -= Time.deltaTime;
               
            }
            
        }
    }

    public void recreate()
    {
        for (int i = 0; i < 5; i++)
        {
            if (timecount[i] <= 0 && !BTGO[i])
            {
                
                BTGO[i]=Instantiate(Origin, postions[i], Quaternion.identity);
                timecount[i] = 5;
            }
        }
    }
    
}
