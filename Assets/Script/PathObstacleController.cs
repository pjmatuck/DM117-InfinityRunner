using UnityEngine;

public class PathObstacleController : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] Transform[] obstaclesPlaceHolders;

    public void InsertObstacle()
    {
        var placeHolder = Random.Range(0, obstaclesPlaceHolders.Length);

        Instantiate(obstaclePrefab, obstaclesPlaceHolders[placeHolder]);
    }
}
