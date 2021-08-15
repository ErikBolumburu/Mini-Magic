using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;

    void Update(){
        if(health <= 0){
            Destroy(gameObject);
        }
    }
    public void DamageEnemy(float damage){
        health -= damage;
    }
}
