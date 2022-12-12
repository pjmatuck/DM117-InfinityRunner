using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawnerController : MonoBehaviour
{
    [SerializeField] GameObject[] treePrefab;
    [SerializeField] Transform[] treeSpawnPoints;
    [SerializeField] float spawnRadius;

    void OnEnable()
    {
        InsertTrees();
    }

    void InsertTrees()
    {
        var generateMode = Random.Range(0, 2);

        int numberOfTrees = 0;

        switch (generateMode)
        {
            case 0: //RIGHT
                numberOfTrees = Random.Range(1, 4);
                for(int i = 0; i < numberOfTrees; i++)
                {
                    InsertTree(treeSpawnPoints[1].position);
                }
                break;
            case 1: //LEFT
                numberOfTrees = Random.Range(1, 4);
                for (int i = 0; i < numberOfTrees; i++)
                {
                    InsertTree(treeSpawnPoints[0].position);
                }
                break;
        }
    }

    void InsertTree(Vector3 spot)
    {
        var randomInCircle = Random.insideUnitCircle * spawnRadius;

        var position = new Vector3(randomInCircle.x, 0f, randomInCircle.y) + spot;

        Instantiate(treePrefab[Random.Range(0, treePrefab.Length)], 
            position, Quaternion.identity, this.transform);
    }
}
