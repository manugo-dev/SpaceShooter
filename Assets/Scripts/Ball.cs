using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction;

    public void Shoot(Vector2 direction)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed; 
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player ball hit enemy");
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy == null)
            {
                Debug.LogError("Enemy component not found on collided object.");
                return;
            }

            ObjectPool<Enemy> enemyPool = GameObject.FindObjectOfType<ObjectPool<Enemy>>();
            //if (enemyPool == null)
            //{
            //    Debug.LogError("Enemy pool not found in the scene.");
            //    return;
            //}

            enemyPool.ReleaseObject(enemy);
            //ScoreManager.Instance.AddScore(10);
        }

        //if (collision.gameObject.CompareTag("EnemyBalls"))
        //{
        //    Debug.Log("Player ball hit enemy balls");
        //    EnemyBall enemyBall = collision.gameObject.GetComponent<EnemyBall>();
        //    if (enemyBall == null)
        //    {
        //        Debug.LogError("EnemyBall component not found on collided object.");
        //        return;
        //    }

        //    ObjectPool<EnemyBall> enemyBallPool = GameObject.FindObjectOfType<ObjectPool<EnemyBall>>();
        //    if (enemyBallPool == null)
        //    {
        //        Debug.LogError("EnemyBall pool not found in the scene.");
        //        return;
        //    }

        //    enemyBallPool.ReleaseObject(enemyBall);
        //    ScoreManager.Instance.AddScore(5); 
        //}
    }

    public void ResetBall()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero; 
        transform.position = new Vector3(0, -10, 0); 
    }
}
