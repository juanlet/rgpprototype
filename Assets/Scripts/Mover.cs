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

        UpdateAnimator();
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

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        // our animator only wants to know if we are running or not, that's why we convert from global(world) to local(Player)
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed); 
    }
}
