using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyBall : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("enemy ball hit player");
        }
    }

    public void ResetBall()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero; 
        transform.position = new Vector3(0, -10, 0); 
    }
}
