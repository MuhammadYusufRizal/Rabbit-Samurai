﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{
    //public Player player;
    public Animator animator;
    private Rigidbody2D rb;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime) {
            if(Input.GetKeyDown(KeyCode.Z)) {
<<<<<<< HEAD
                if(!player.isRunning()){
                    Attack();
                }
                else{
                    RunAttack();
                }
=======
                Attack();
>>>>>>> 8d9894008a5b0bbe3d93bd8bfefa07939f578d1c
                nextAttackTime = Time.time + 1f/attackRate;
            }
        }   
    }

    public void RunAttack() {
        player.RunAttack();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<enemyAI>().TakeDamage(attackDamage);
        }
    }

    public void Attack() {
<<<<<<< HEAD
        player.StandAttack();
=======
        animator.SetTrigger("attack");

>>>>>>> 8d9894008a5b0bbe3d93bd8bfefa07939f578d1c
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<enemyAI>().TakeDamage(attackDamage);
        }
    }


    void OnDrawGizmosSelected() {
        if(attackPoint == null) {
            return;
        }
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
