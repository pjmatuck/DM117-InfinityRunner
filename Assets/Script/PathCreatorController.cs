using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathCreatorController : MonoBehaviour
{
    [SerializeField] GameObject path;
    [SerializeField] int numberOfPaths;
    [SerializeField] Transform playerTransform;

    List<GameObject> paths = new List<GameObject>();
    float pathSize;
    float nextUpdate = 1.5f;
    int createdPaths = 0;

    // Start is called before the first frame update
    void Start()
    {
        pathSize = path.GetComponent<MeshFilter>().sharedMesh.bounds.size.z;

        for(int i = 0; i < numberOfPaths; i++)
        {
            var position = new Vector3(
                this.transform.position.x,
                0f,
                this.transform.position.z + pathSize * i);

            paths.Add(CreatePath(position));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
            return;

        if(playerTransform.position.z >= nextUpdate * pathSize)
        {
            nextUpdate++;
            UpdatePaths();
        }
    }

    private void UpdatePaths()
    {
        Destroy(paths[0]);
        paths.RemoveAt(0);

        var position = new Vector3(
            0f,
            0f,
            paths[paths.Count - 1].transform.position.z + pathSize);

        paths.Add(CreatePath(position));
    }

    GameObject CreatePath(Vector3 position)
    {
        GameObject pathGameObject = Instantiate(path, position, Quaternion.identity, this.transform);
        createdPaths++;
        if (createdPaths % 2 == 0)
        {
            PathObstacleController pathObstacleController = pathGameObject.GetComponent<PathObstacleController>();
            pathObstacleController.InsertObstacle();
        }
        return pathGameObject;

    }
}
