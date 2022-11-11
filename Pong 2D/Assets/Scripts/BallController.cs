using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Variables
    [SerializeField] private float initialSpeed = 4f;
    [SerializeField] private float speedMultiplier = 1.1f;
    private Rigidbody2D ballRb2d;


    //Functions
    void Start()
    {
        ballRb2d = GetComponent<Rigidbody2D>();
        InitBall();
    }


    private void InitBall()
    {
        float xSpeed = Random.Range(0, 2) == 0 ? 1 : -1;
        float ySpeed = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb2d.velocity = new Vector2(xSpeed, ySpeed)* initialSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            ballRb2d.velocity *= speedMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GoalLeft"))
        {
            GameManager.Instance.player1Goal();
          
        }
        else
        {
            GameManager.Instance.player2Goal();
          
        }
        GameManager.Instance.Restart();
        InitBall();
    }
}
