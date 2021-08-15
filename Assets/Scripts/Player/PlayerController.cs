using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    [Header("Components")]
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    
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
    [SerializeField] private Transform playerAttackSource;


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
        RestartOrQuit();
    }

    void GetMovementInput(){
        // Called in Update()
        if(!isDead){
            if(Input.GetAxis("XHorizontal") != 0 || Input.GetAxis("XVertical") != 0){
                horizontal = Input.GetAxisRaw("XHorizontal");
                vertical = Input.GetAxisRaw("XVertical");
            }
            else{
                horizontal = Input.GetAxisRaw("Horizontal");
                vertical = Input.GetAxisRaw("Vertical");
            }
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
                    GameObject bulletGO = Instantiate(bullet, playerAttackSource.position, Quaternion.identity);
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

    void RestartOrQuit(){
        if(isDead){
            if(Input.GetKeyDown(KeyCode.R)){
                SceneManager.LoadScene("Necromancer_Boss");
            }
            else if(Input.GetKeyDown(KeyCode.Q)){
                Application.Quit();
            }
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
