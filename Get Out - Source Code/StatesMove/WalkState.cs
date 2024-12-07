    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WalkState : BaseState
{

    private MovementStateMachine player;
    public WalkState(StateMachine player) : base(player)
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
 
        player.Setbool(MovementStateMachine.CanRun, false);
        player.Move();
        if (Input.GetKey(KeyCode.W) && (Input.GetKey(KeyCode.LeftShift)))
        {
            player.ChangeState(player.runState);

        }

        if (!Input.GetKey(KeyCode.W)) 
        {

            player.ChangeState(player.idleState);

        }

        //if (!Input.GetKey(KeyCode.W) || !Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
        //{
        //    player.ChangeState(player.idleState);

        //}

    }




}

