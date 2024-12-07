using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : BaseState
{
    private MovementStateMachine player;
    public HorizontalMovement(StateMachine player) : base(player)
    {
        this.player = (MovementStateMachine)player;
    }

    public override void Enter()
    {

      

    }
    public override void Update()
    {
        
        player.HorizontalMove();

        if(!Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A))
        {

          player.ChangeState(player.idleState); 
         
        
        
        }

    }
    public override void Exit()
    {
     
    }


}
