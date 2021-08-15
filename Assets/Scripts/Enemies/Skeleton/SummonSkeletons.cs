using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonSkeletons : StateMachineBehaviour
{

    [SerializeField] private GameObject skeletonPrefab;
    public int minSkeletons, maxSkeletons;
    public int skeletonSpawnRange;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform bossTransform = animator.gameObject.transform;
        Vector2 bossPos = bossTransform.position;
        int skeletonCount = Random.Range(minSkeletons, maxSkeletons + 1);
        for (int i = 0; i < skeletonCount; i++)
        {
            Vector2 randomDisplacement = new Vector2(Random.Range(-skeletonSpawnRange, skeletonSpawnRange), Random.Range(-skeletonSpawnRange, skeletonSpawnRange));
            Vector2 randomPos = bossPos + randomDisplacement; 
            Instantiate(skeletonPrefab, randomPos, Quaternion.identity);
        }

        int random = Random.Range(0,2);
        if(random == 0)
            animator.SetTrigger("Spinning");
        else if(random == 1)
            animator.SetTrigger("Chase");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

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
