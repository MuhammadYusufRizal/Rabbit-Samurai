using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinding;

public class enemyAI : MonoBehaviour
{
    float distance1;
    float distance2;

    public float speed = 50f;
    public float nextWaypointDistance = 3f;
    
    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath = false;

    public Transform enemyGFX;

    public Enemy enemy;
    public float delay = 0f;

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    Seeker seeker;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(currentHealth);

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }
    
    void UpdatePath() {
        if(distance1 > distance2) {
           if(seeker.IsDone()) {
                seeker.StartPath(rb.position, GameObject.Find("Player").transform.position, OnPathComplete);
            } 
        }
        if(seeker.IsDone()){
            seeker.StartPath(rb.position, GameObject.Find("GoddesEgg").transform.position, OnPathComplete);
        }
        // if(seeker.IsDone()) {
        //     seeker.StartPath(rb.position, GameObject.Find("Player").transform.position, OnPathComplete);
        // } 
        
    }

    void OnPathComplete(Path p) {
        if(!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }


    void Update() {
        distance1 = Vector3.Distance(GameObject.Find("Enemy").transform.position, GameObject.Find("GoddesEgg").transform.position);
        distance2 = Vector3.Distance(GameObject.Find("Enemy").transform.position, GameObject.Find("Player").transform.position);

        if(!reachedEndofPath) {
            enemy.animator.SetFloat("Speed", speed);
        }
        if(reachedEndofPath){
            enemy.animator.SetFloat("Speed", 0);
        }
        if(currentHealth <= 0 && !reachedEndofPath) {
            enemy.animator.SetFloat("Speed", 0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null) {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count) {
            reachedEndofPath = true;
            return;
        }else {
            reachedEndofPath = false;
            if(currentHealth <= 0) {
                enemy.animator.SetFloat("Speed", 0);
            }
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance) {
            currentWaypoint++;
        }

        if(rb.velocity.x >= 0.01f) {
            enemyGFX.localScale = new Vector3(1f, 1f, 1f);
        }
        else if(rb.velocity.y <= 0.01f) {
            enemyGFX.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0) {
            enemy.Die();
        }
    }
}
