using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Animator enemyAnimator;

    public int killCount;
    public bool isDead;

    //for running enemies
    public bool isRunning;
    public Rigidbody2D rb;

    public float accelTime;
    private Vector2 movement;

    public float timeLeft;

    public float countDownTime = 2f;

    //for cowardly enemies
    public bool isCoward;
    public float speed = 5f;
    public float followStopDist = 3;
    public float retreatDist = 2;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        killCount = 0;
        Debug.Log("kill count " + killCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning == true) {
            timeLeft -= Time.deltaTime;
        
            if (timeLeft <= 0) {
                movement = new Vector2(Random.Range(-5f, 5f), Random.Range(-4f, 4f));
                movement = movement.normalized * 0.1f;
                rb.AddForce(movement, ForceMode2D.Impulse);
                timeLeft += accelTime;
            }
        }

        if (isCoward == true) {
            //if the distance between the player's position is greater than the follow stop distance,
            if (Vector2.Distance(transform.position, player.position) > followStopDist)
            {
                //enemy moves towards the player's position
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, player.position, step);
                // Debug.Log("follow");
            }
            //if the distance between the player's position is less than the retreat dist,
            else if (Vector2.Distance(transform.position, player.position) < retreatDist)
            {
                float step = -speed * Time.deltaTime;
                //enemy will move away
                transform.position = Vector2.MoveTowards(transform.position, player.position, step);
                // Debug.Log("RUN AWAY");
            }
        }

        // if (isDead == true) {
        //     this.enabled = false;
        // }
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        //play hurt anim
        enemyAnimator.SetTrigger("Hurt");
        if (currentHealth <= 0) {
            enemyAnimator.SetBool("IsDead", true);
            Die();
        }
    }

    void Die() {
        // killCount++;
        speed = 0;
        //die animation
        // enemyAnimator.SetBool("IsDead", true);
        // this.enabled = false;   
        rb.velocity = Vector2.zero;
        isDead = true;
        StartCoroutine(countDownCo(rb));
    }

    private IEnumerator countDownCo(Rigidbody2D rb) {
        yield return new WaitForSeconds(countDownTime);
        FindObjectOfType<audioManager>().Play("enemyDie");
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        isRunning = false;
        isCoward = false;
        // killCount++;
        // Debug.Log("killcount " + killCount);
        // isDead = true;
        // enemyAnimator.SetBool("StillDead", true);
    }
}
