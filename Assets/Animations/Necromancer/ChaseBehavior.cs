using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehavior : StateMachineBehaviour
{   

    [SerializeField] private GameObject bullet;
    public float fireRate;
    private float nextFire;

    private float timer;
    public float minTime;
    public float maxTime;
    public float chaseSpeed;

    private GameObject boss;
    private GameObject player;
    private float step;
    private Transform attackSource;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTime, maxTime);
        boss = GameObject.FindGameObjectsWithTag("Boss")[0];
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        attackSource = GameObject.Find("AttackSource").GetComponent<Transform>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        step = chaseSpeed * Time.deltaTime;
        if (timer <= 0)
        {
            int random = Random.Range(0,2);
            if(random == 0)
                animator.SetTrigger("Spinning");
            else if(random == 1)
                animator.SetTrigger("SummonSkeletons");
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if(!player.GetComponent<PlayerController>().isDead){
            boss.transform.position = Vector2.MoveTowards(boss.transform.position, player.transform.position, step);
            CheckIfTimeToFire();
        }

    }

    void CheckIfTimeToFire(){
        if(Time.time > nextFire){
            GameObject bulletGO = Instantiate(bullet, attackSource.position, Quaternion.identity);
            bulletGO.GetComponent<EnemyBullet>().directBullet(player.transform);
            nextFire = Time.time + fireRate;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
