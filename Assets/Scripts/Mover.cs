using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // if user press left click we discard previous rays to order the user to go to a certain place
            MoveToCursor();
        }
        // starting point is the camera, we make the direction long so it can go far
        //Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
        //lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInformation;
        bool hasHit = Physics.Raycast(ray, out hitInformation);
        if(hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hitInformation.point;
        }
    }
}
