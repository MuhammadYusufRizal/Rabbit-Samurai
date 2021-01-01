using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCombat : MonoBehaviour
{
    public Enemy enemy;
    public Animator animator;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 5;

    void OnTriggerEnter2D (Collider2D coll) {
        enemy.Attack();
    }
}
