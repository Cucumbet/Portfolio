using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class IdleState : BaseState

{
    private MovementStateMachine player;
    public IdleState(StateMachine player): base(player)
    {
        this.player =(MovementStateMachine) player;
    }
  
    public override void Exit()
    {
        
    }

    public override void Enter()
    {
        

    }

    public override void Update()
    {
  
        //player.Setfloat("Horizontal", Input.GetAxis("Horizontal"));
        //if (Mathf.Abs(player.transform.rotation.y) > 0.5f)
        //{
        //    player.ChangeState(player.horizmove);
        //}


        player.Setbool(MovementStateMachine.CanRun, false);
        float X = Input.GetAxis("Horizontal");
        player.Animator.SetFloat("Horizontal", X);
        float Y = Input.GetAxis("Vertical");
        player.Animator.SetFloat("Vertical", Y);



        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {

            player.ChangeState(player.horizmove);

        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))  /*&& !(Input.GetKey(KeyCode.LeftShift)*//*)*/)
        
        {

          player.ChangeState(player.walkState);
        
        }
  


    }

}
