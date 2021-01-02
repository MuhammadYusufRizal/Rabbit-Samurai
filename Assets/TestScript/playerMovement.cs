using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float dirX, dirY, speed;
    private Vector3 localScale;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 5f;
        localScale = transform.localScale;
    }

    void Update() {
        dirX = Input.GetAxisRaw("Horizontal") * speed;
        dirY = Input.GetAxisRaw("Vertical") * speed;

        AnimationControl();
    }

    private void FixedUpdate() {
        rb.velocity = new Vector2(dirX, dirY);
    }

    private void LateUpdate() {
        if(rb.velocity.x > 0) {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
        else if(rb.velocity.x < 0) {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }

    private void AnimationControl() {
        if(rb.velocity.y == 0 && rb.velocity.x == 0) {
            anim.Play("idle_right");
        }
        if(rb.velocity.x != 0 || rb.velocity.y != 0) {
            anim.Play("run");
        }
    }
}
