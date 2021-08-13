using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public void DamageEnemy(float damage){
        health -= damage;
    }
}
