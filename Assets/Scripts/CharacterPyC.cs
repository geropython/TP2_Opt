using System;
using UnityEngine;
using UnityEngine.AI;


public class CharacterPyC : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private NavMeshAgent player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private GameObject targetDest;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitpoint;
            if (Physics.Raycast(ray, out hitpoint))
            {
                targetDest.transform.position = hitpoint.point;
                player.SetDestination(hitpoint.point);
            }
        }

        if (player.velocity != Vector3.zero)
        {
            playerAnimator.SetBool(IsWalking,true);
        }
        else if (player.velocity == Vector3.zero)
        {
            playerAnimator.SetBool(IsWalking, false);
        }
    }
}
