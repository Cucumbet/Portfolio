using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationaState : BaseState
{


    private RotationStateMachine player;
    public RotationaState(StateMachine player) : base(player)
    {
        this.player = (RotationStateMachine)player;
    }


    public override void Exit()
    {

    }

    public override void Enter()
    {

    }

    public override void Update()
    {
        player.Rotate();
    }
}
