using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class StateMachine : MonoBehaviour 
    {
    private BaseState currentstate;
    protected BaseState CurrentState => currentstate;
    protected abstract BaseState GetInitialState();


    private void Start()
    {
        currentstate = GetInitialState();
        currentstate?.Enter();

    }

    private void Update() 
    { 
         currentstate?.Update();
    
    
    }
    public void ChangeState(BaseState newState)
    {
        currentstate.Exit();
        currentstate = newState;
        newState?.Enter();

    }

}  

