using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawn : MonoBehaviour
{
    public DropPrefab[] dropPrefabs;

    public void dropitems()
    {
        foreach(var dropprefab in dropPrefabs)
        {
            if (Random.Range(0f, 100f) <= dropprefab.dropPercentage)
            {
                Instantiate(dropprefab.prefab, transform.position, Quaternion.identity);
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
