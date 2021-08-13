using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;

public class PlayerController : MonoBehaviour
{
    
    [Header("Components")]
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    public InputControl inputControl;
    
    [Header("Movement")]
    private float defaultMoveSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float OnHitBuffTime;
    [SerializeField] private float moveSpeedOnHit;
    private bool invincible;

    private float horizontal;
    private float vertical;
    private float speedLimiter = 0.7f;

    [Header("Death")]
    public bool isDead = false;
    public GameObject deathScreen;

    [Header("Player Stats")]
    public float health;

    [Header("Attack")]
    [SerializeField] private GameObject bullet;
    public float basicAttackCooldown = 1;
    private float nextFireTime = 0;

    void Awake(){
    }

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        defaultMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update(){
        GetMovementInput();
        PlayerAttack();
        PlayerDeath();
        InvincibleBuffs();
        FlipSprite();
    }

    void GetMovementInput(){
        // Called in Update()
        if(!isDead){
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
        else{
            horizontal = 0f;
            vertical = 0f;
        }
    }

    void PlayerAttack(){
        if(Input.GetAxisRaw("Fire1") == 1){
            if(!isDead){
                if(Time.time > nextFireTime){
                    GameObject bulletGO = Instantiate(bullet, transform.position, Quaternion.identity);
                    nextFireTime = Time.time + basicAttackCooldown;
                }
            }
        }
    }

    void PlayerDeath(){
        // Called in Update()
        if(health <= 0){
            isDead = true;
            animator.SetBool("isDead", true);
            deathScreen.SetActive(true);
        }
    }

    void InvincibleBuffs(){
        // Called in Update()
        if(invincible){
            moveSpeed = moveSpeedOnHit;
        }
        else{
            moveSpeed = defaultMoveSpeed;
        }
    }

    void FlipSprite(){
        // Called in Update()
        if(horizontal < 0){
            sprite.flipX = true;
        }
        else if(horizontal > 0){
            sprite.flipX = false;
        }
    }


    void FixedUpdate(){
        // Movement
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            horizontal *= speedLimiter;
            vertical *= speedLimiter;
            animator.SetBool("Moving", true);
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

    public void DamagePlayer(float damage){
        if(!invincible){
            health -= damage;  
            StartCoroutine(Invulnerability());
        }
    }

    IEnumerator Invulnerability() {
        invincible = true;
        yield return new WaitForSeconds(OnHitBuffTime);
        invincible = false;
    }

}
