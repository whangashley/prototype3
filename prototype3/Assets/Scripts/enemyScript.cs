using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        //play hurt anim
        enemyAnimator.SetTrigger("Hurt");

        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("enemy died");
        //die animation
        enemyAnimator.SetBool("IsDead", true);
        // this.enabled = false;
    }

}
