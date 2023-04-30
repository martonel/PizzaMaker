using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : StateMachineBehaviour
{
    private GameObject[] anims;
    private Animator anim;
    private Animator deliveryAnim;

    public string startName = "";
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        anims = GameObject.FindGameObjectsWithTag("delivery");
        anim = anims[0].GetComponent<Animator>();
        if(startName == "deliverOver"){
            deliveryAnim = GameObject.FindGameObjectsWithTag("deliverAnim")[0].GetComponent<Animator>();
            deliveryAnim.SetBool("deliver",false);
        }
        else if(startName != ""){
            anim.Play(startName);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
