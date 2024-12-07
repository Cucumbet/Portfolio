using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShootingState : BaseState
{
    private ShootingStateMachine player;

    public ShootingState(StateMachine player) : base(player)
    {
        this.player = (ShootingStateMachine)player;
    }


    public override void Exit()
    {
       
    }

    public override void Enter()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public override void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            player.ammoneeded = player.maxAmmo - player.currentammo;
            player.ammotoreload = Mathf.Min(player.ammoneeded, player.totalammo);

            player.currentammo += player.ammotoreload;
            player.totalammo -= player.ammotoreload;



        }
        Zoom();
        Shooting();
        player.currentbullets.text = player.currentammo.ToString() + "/" + player.totalammo;
    }

   
    public void Zoom()
    {
        if(Input.GetKey(KeyCode.Mouse1)) 
        {
            player.cameraplayer.fieldOfView = 40;
          
        }

        else 
        {
            player.cameraplayer.fieldOfView = 60;


        }
    }

    public void Shooting()
    {
        
        if(Input.GetKeyDown(KeyCode.Mouse0) && player.currentammo > 0)
        {
            player.Shoot();
           


        }
    }
    
}
