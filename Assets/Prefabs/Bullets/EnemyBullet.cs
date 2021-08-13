using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody2D rb;
    private Transform playerTransform;
    private Vector2 moveDirection;

    public void directBullet(Transform target){
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (target.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Player")){
            col.gameObject.GetComponent<PlayerController>().DamagePlayer(20);
            Destroy(gameObject);
        }
        else if(col.gameObject.tag.Equals("Wall")){
            Destroy(gameObject);
        }
    }

}
