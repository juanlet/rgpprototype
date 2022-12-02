using UnityEngine;
using RPG.Movement;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
{
    private void Update()
        {
            InteractWithCombat();
            InteractWithMovement();
        }

        private void InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                // transform will work with eiter a collider or a rigid body, so we use transform property
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if(target == null) continue;

                if(Input.GetMouseButtonDown(0)){
                      Fighter fighter  = GetComponent<Fighter>();
                       if(fighter != null) {
                          fighter.Attack(target);
                       } 
                }
            }
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                // if user press left click we discard previous rays to order the user to go to a certain place
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
            RaycastHit hitInformation;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hitInformation);
            if (hasHit)
            {
                Mover mover = GetComponent<Mover>();
                if(mover != null) {
                   mover.MoveTo(hitInformation.point);
                }
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}