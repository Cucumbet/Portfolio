using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class InteractbleStateMachine : StateMachine

{

    public RayCastt pickray;
    public UiInventoryManager UIinventoryManager;
    [SerializeField] GameObject hands;
    public SwitchWeaponState switching { get; protected set; }
    public GameObject Hands => hands;
    private Animator animator;
    public Animator Animator => animator;
    public PickUpState pickup { get; protected set; }
    protected override BaseState GetInitialState()
    {
        return pickup;
    }

    public void EndAnim()
    {
        animator.SetBool("PickUp", false);

    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        pickup = new PickUpState(this);
        switching = new SwitchWeaponState(this);
    }
   
    

}