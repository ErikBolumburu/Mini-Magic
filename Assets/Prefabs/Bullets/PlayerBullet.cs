using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

   private Rigidbody2D rb;
   public float bulletSpeed;
   public float bulletDamage;
   private Vector2 mousePos;

    public void Start() {
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = mousePos - new Vector2(transform.position.x, transform.position.y);
        mouseDirection.Normalize();
        rb.velocity = mouseDirection * bulletSpeed;
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
