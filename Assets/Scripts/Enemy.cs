using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int attack;
    public float speed;
    public float delay = 0f;

    public Animator animator;

    public Enemy(int health, int attack, float speed){
        this.health = health;
        this.attack = attack;
        this.speed = speed;
    }

    public void Attack(){
        animator.SetTrigger("Attack");
    }
    
    public void Run(){

    }

    public void Idle(){

    }

    public void Die(){
        Debug.Log("Enemy died!");
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
