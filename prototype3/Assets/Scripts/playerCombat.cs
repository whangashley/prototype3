using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour
{

    public Animator playerAnimator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 30;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public Rigidbody2D playerRB;

    // public bool isInteracting;

    enemyScript enemyScriptNormal;
    public GameObject objEnemy;

    void Start()
    {
        // isInteracting = false;
        enemyScriptNormal = objEnemy.GetComponent<enemyScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime) {
            if (Input.GetMouseButton(0)) {
                FindObjectOfType<audioManager>().Play("playerAttack");
                Attack();
                // isInteracting = true; 
                nextAttackTime = Time.time + 1f / attackRate;
            }            
        }
    }

    void Attack() {
        playerRB.velocity = Vector2.zero;
        
        //play atk anim
        playerAnimator.SetTrigger("attack");

        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        //damage them
        foreach(Collider2D enemy in hitEnemies) {
            enemy.GetComponent<enemyScript>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected() {
        if (attackPoint == null) {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
