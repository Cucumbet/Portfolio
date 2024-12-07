using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class SwitchWeaponState : BaseState
{

    private InteractbleStateMachine player; 

    public SwitchWeaponState(StateMachine player) : base(player)
    {
        this.player = (InteractbleStateMachine)player;

    }
    // Start is called before the first frame update
    public override void Exit()
    {
       
    }

    public override void Enter()
    {

        
        PistolOn();


            player.pickray.inventoryManager.activeItem.transform.SetParent(player.Hands.transform); 
            player.pickray.inventoryManager.SetPistol(player.pickray.inventoryManager.activeItem);




    }


    public override void Update()
    {

        player.Animator.SetBool("PistolOn", true);
        player.pickup.Pickup();



        if (Input.GetKey(KeyCode.Alpha2) && player.pickray.inventoryManager.activeItem.activeInHierarchy)
        {
            player.Animator.SetBool("PistolOn", false);
            player.pickray.inventoryManager.activeItem.SetActive(false);
            player.pickray.inventoryManager.activeItem.GetComponent<Item>().Weaponimage.gameObject.SetActive(false);
            player.ChangeState(player.pickup);

        }
        
    }


    public void PistolOn()
    {
        player.Animator.SetBool("PistolOn", true);
        player.pickray.inventoryManager.activeItem.SetActive(true);
        player.pickray.inventoryManager.activeItem.GetComponent<Item>().Weaponimage.gameObject.SetActive(true);


    }
}
