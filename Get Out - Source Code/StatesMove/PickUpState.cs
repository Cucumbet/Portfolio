using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class PickUpState : BaseState
{
    private InteractbleStateMachine player;

    public PickUpState(StateMachine player) : base(player)
    {
        this.player = (InteractbleStateMachine)player;
    }

    public override void Exit()
    {

    }

    public override void Enter()
    {

       
    }

    
    public override void Update()
    {
   
        Pickup();
     
        if (Input.GetKey(KeyCode.Alpha1) && player.pickray.inventoryManager.list.Contains(player.pickray.inventoryManager.activeItem))
        {
            player.ChangeState(player.switching);

        }
    }



    public void Pickup()
    {


        if (Input.GetKeyDown(KeyCode.E) && player.pickray.showEmassage() && player.Animator.GetFloat("Vertical") == 0f && player.UIinventoryManager.slotsfreecount > 0)
        {
            player.Animator.SetBool("PistolOn", false);
            player.Animator.SetBool("PickUp", true);
            player.pickray.inventoryManager.itemtopick.SetActive(false);
            player.pickray.inventoryManager.list.Add(player.pickray.inventoryManager.itemtopick);


            AddSprites();


        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S))
        {
            player.Animator.SetBool("PickUp", false);
           

        }

       
        



    }
      
    public void AddSprites()
    {
        if (player.pickray.inventoryManager.activeItem)
        {
            player.UIinventoryManager.listofslots[0].transform.GetChild(0).GetComponent<Image>().sprite = player.UIinventoryManager.weapon;


        }



        if (player.pickray.inventoryManager.ItemMedic)
        {
            //player.UIinventoryManager.listofslots[1].transform.GetChild(0).GetComponent<Image>().sprite = player.UIinventoryManager.Medic;
            
            player.UIinventoryManager.SetSprite(player.UIinventoryManager.Medic);
            player.pickray.inventoryManager.ItemMedic = null;
        }

        if (player.pickray.inventoryManager.ItemBullets)
        {
            //player.UIinventoryManager.listofslots[2].transform.GetChild(0).GetComponent<Image>().sprite = player.UIinventoryManager.Bullets;
            player.UIinventoryManager.SetSprite(player.UIinventoryManager.Bullets);
            player.pickray.inventoryManager.ItemBullets = null;

        }


    }



}
