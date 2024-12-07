using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState

{
    private MovementStateMachine player;
    public RunState(StateMachine player) : base(player)
    {
        this.player = (MovementStateMachine)player;
    }


    public override void Exit()
    {

    }

    public override void Enter()
    {
     
    }

    public override void Update()
    {
        player.Setbool(MovementStateMachine.CanRun, true);
        player.Transitor();


         if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {

            player.ChangeState(player.idleState);

        
        }
     



    }

    
}
