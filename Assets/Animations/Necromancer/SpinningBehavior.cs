using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBehavior : StateMachineBehaviour
{

    [SerializeField] private GameObject bullet;
    public float fireRate;
    private float nextFire;
    private float timer;
    public float minTime;
    public float maxTime;
    private GameObject boss;
    private GameObject player;
    private Transform[] targets;
    private Transform attackSource;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        boss = GameObject.FindGameObjectsWithTag("Boss")[0];
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        attackSource = GameObject.Find("AttackSource").GetComponent<Transform>();

        targets = new Transform[4];

        targets[0] = GameObject.Find("1").transform;
        targets[1] = GameObject.Find("2").transform;
        targets[2] = GameObject.Find("3").transform;
        targets[3] = GameObject.Find("4").transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            int random = Random.Range(0,2);
            if(random == 0)
                animator.SetTrigger("Chase");
            else if(random == 1)
                animator.SetTrigger("SummonSkeletons");
        }
        else
        {
            timer -= Time.deltaTime;
        }

        CheckIfTimeToFire();
    }

    void CheckIfTimeToFire(){
        if(Time.time > nextFire){
            for (int i = 0; i < 4; i++)
            {
                GameObject bulletGO = Instantiate(bullet, attackSource.position, Quaternion.identity);
                bulletGO.GetComponent<EnemyBullet>().directBullet(targets[i]);
                nextFire = Time.time + fireRate;
            }
        }
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
