using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManaganer : MonoBehaviour
{
    [SerializeField] private State currentState;

    // Update is called once per frame
    void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState(); //Save the state in nextState

        if(nextState != null) // Verify is the state is not null
        {
            SwitchNextState(nextState);
        }
    }

    private void SwitchNextState(State next) //Change to the next State
    {
        currentState = next;
    }
}
