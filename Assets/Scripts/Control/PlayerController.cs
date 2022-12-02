using UnityEngine;
using RPG.Movement;
namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // if user press left click we discard previous rays to order the user to go to a certain place
            MoveToCursor();
        }
    }
    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInformation;
        bool hasHit = Physics.Raycast(ray, out hitInformation);
        if (hasHit)
        {
            GetComponent<Mover>().MoveTo(hitInformation.point);
        }
    }
}
}