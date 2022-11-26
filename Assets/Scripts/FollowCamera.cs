using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // we make it of type transform cause we need to know the position of the object
    [SerializeField] Transform target;
     
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
    }
}
