using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Player : MonoBehaviour
{
    [SerializeField] BallPool ballPool;
    [SerializeField] private float playerMoveSpeed = 5f;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float shootCooldown = 0.5f;
    [SerializeField] private float screenLimitX = 8f;
    [SerializeField] private float screenLimitY = 4f;

    private float nextShootTime = 0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float newX = transform.position.x + horizontalInput * playerMoveSpeed * Time.deltaTime;
        float newY = transform.position.y + verticalInput * playerMoveSpeed * Time.deltaTime;

        newX = Mathf.Clamp(newX, -screenLimitX, screenLimitX);
        newY = Mathf.Clamp(newY, -screenLimitY, screenLimitY); 

        transform.position = new Vector2(newX, newY);
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextShootTime)
        {
            animator.SetTrigger("IsShooting"); // It runs ShotBall when player do the animation
            nextShootTime = Time.time + shootCooldown;
        }
    }

    public void ShootBall()
    {
        Ball ball = ballPool.GetObject();
        ball.transform.position = shootPoint.position;
        ball.transform.rotation = Quaternion.identity;
        ball.GetComponent<Ball>().Shoot(Vector2.right);
    }

}
