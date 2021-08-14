using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

   private Rigidbody2D rb;
   public float bulletSpeed;
   public float bulletDamage;
   private Vector2 mousePos;
   private Vector2 shootDirection;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetAxis("RSHorizontal") != 0 || Input.GetAxis("RSVertical") != 0){
            shootDirection = new Vector2(Input.GetAxis("RSHorizontal"), Input.GetAxis("RSVertical"));
        }
        else{
            shootDirection = mousePos - new Vector2(transform.position.x, transform.position.y);
            shootDirection.Normalize();
        }
        rb.velocity = shootDirection * bulletSpeed;
   }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag.Equals("Boss")){
            col.GetComponent<Enemy>().DamageEnemy(bulletDamage);
            Destroy(gameObject);
        }
        else if(col.gameObject.tag.Equals("Wall")){
            Destroy(gameObject);
        }
    }
}
