using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawn : MonoBehaviour
{
    public DropPrefab[] dropPrefabs;
    private bool iscreated;

    public void dropitems()
    {
        foreach (var dropprefab in dropPrefabs)
        {
            if (Random.Range(0f, 100f) <= dropprefab.dropPercentage&&iscreated==false)
            {
                Instantiate(dropprefab.prefab, transform.position, Quaternion.identity);
                iscreated = true;
            }
        }
    }

    [System.Serializable]
    public class DropPrefab
    {
        public GameObject prefab;
        [Range(0f, 100f)] public float dropPercentage;
    }
    
}
