using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHiddenCube: MonoBehaviour
{
    [SerializeField] GameObject ObjectToFollow;
    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = ObjectToFollow.transform.rotation;
        this.transform.position = ObjectToFollow.transform.position;
    }
}
