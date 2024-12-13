using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float shootInterval = 2f;
    [SerializeField] private float speed = 3f;
    [SerializeField] private EnemyBallPool enemyBallPool; // enemy ball pool
    private float shootTimer;
    private Transform playerTransform;

    void Start()
    {
        // Find player by tag
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        // Follow player
        MoveTowardsPlayer();

        // enemy shooting time
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0)
        {
            ShootBall();
            shootTimer = shootInterval; // Reiniciar el temporizador
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void ShootBall()
    {
        EnemyBall ball = enemyBallPool.GetObject();
        ball.transform.position = transform.position;
        ball.Shoot(Vector2.left); 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si la colisión es con un objeto etiquetado como "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enemy hit player");
        }
    }
}
