using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonChase : StateMachineBehaviour
{

    private GameObject player;
    private float speed;
    private float damage;
    private float step;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("Player");
        speed = animator.gameObject.GetComponent<Enemy>().speed;    
        damage = animator.gameObject.GetComponent<Enemy>().damage;    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        step = speed * Time.deltaTime;
        animator.gameObject.transform.position = Vector2.MoveTowards(animator.gameObject.transform.position, player.transform.position, step);
        if(Vector2.Distance(animator.gameObject.transform.position, player.transform.position) < 0.5){
            player.GetComponent<PlayerController>().DamagePlayer(damage);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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
