using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] Transform objectToFollow;

    Vector3 offSet;
    void Start()
    {
        offSet = this.transform.position - objectToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow == null)
            return;

        this.transform.position = new Vector3(
            this.transform.position.x,
            this.transform.position.y,
            objectToFollow.position.z + offSet.z); ;
    }
}
