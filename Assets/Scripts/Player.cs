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

    //public void Attack(){
    //    animator.SetTrigger("attack");
    //}

    public void Idle(){
        animator.SetBool("run", false);
    }

    public void Run(){
        animator.SetBool("run", true);
    }

<<<<<<< HEAD
    public bool isRunning(){
        return animator.GetBool("run");
    }

    public void RunAttack(){
        animator.SetTrigger("run_attack");
    }
=======
    //void RunAttack(){
    //    animator.SetTrigger("run_attack");
    //}
>>>>>>> 8d9894008a5b0bbe3d93bd8bfefa07939f578d1c
}
