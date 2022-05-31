using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool dead = false;
    [SerializeField] private int baseAttackCooldown = 60;
    private int attackCooldown;
    private int detection = 15;
    [SerializeField] private Transform player;
    Animator animator;
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;



    void Start()
    {
        animator = GetComponent<Animator>();
        attackCooldown = baseAttackCooldown;
    }

    void FixedUpdate()
    {
        if (dead)
        {
            animator.SetBool("enemy_InRange", false);
            animator.SetBool("enemy_Found", false);
            animator.SetBool("dead", true);
            if (baseAttackCooldown+5 <= 0)
            {
                Destroy(this.gameObject);
            }
            else
            {
                baseAttackCooldown -= 1;
            }
        }
        else 
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= detection)
            {
                animator.SetBool("enemy_Found", true);
                if (distance > stoppingDistance)
                {
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                    animator.SetBool("enemy_InRange", false);
                }
                else
                {
                    animator.SetBool("enemy_InRange", true);
                    if (attackCooldown <= 0)
                    {
                        Attack();
                        attackCooldown = baseAttackCooldown;
                    }
                    else
                    {
                        attackCooldown -= 1;
                    }
                }
            }
            else
            {
                animator.SetBool("enemy_Found", false);
            }
        }     
    }
    void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);

        foreach(Collider2D enemy in hitEnemies)
        {
            //Debug.Log("Hit");
            enemy.gameObject.GetComponent<UnitHP>().TakeDamage(5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spike"))
        {
            this.gameObject.GetComponent<UnitHP>().TakeDamage(3f);
        }
    }
}
