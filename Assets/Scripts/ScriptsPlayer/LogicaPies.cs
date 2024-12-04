using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public PlayerAnimator playerAnimator;
   
    private void OnTriggerStay(Collider other)
    {
        playerAnimator.grounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerAnimator.grounded = false;
    }
}

