using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class BaseState

{
   
    protected readonly StateMachine stateMachine;

    protected BaseState( StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;

    }
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();

}
