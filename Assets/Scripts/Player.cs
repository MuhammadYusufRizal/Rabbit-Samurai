using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int attack;
    public float speed;

    public Animator animator;

    Player(int health, int attack, float speed){
        this.health = health;
        this.attack = attack;
        this.speed = speed;
    }

    public void StandAttack(){
        animator.SetTrigger("attack");
    }

    public void Idle(){
        animator.SetBool("run", false);
    }

    public void Run(){
        animator.SetBool("run", true);
    }

    public bool isRunning(){
        return animator.GetBool("run");
    }

    public void RunAttack(){
        animator.SetTrigger("run_attack");
    }
}
