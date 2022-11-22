using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    //Variables
    [SerializeField] private float initialSpeed = 4f;
    [SerializeField] private float speedMultiplier = 1.1f;
    private Rigidbody2D ballRb2d;

    [SerializeField] private AudioClip goal;
    [SerializeField] private AudioClip hitplayer;
    [SerializeField] private AudioClip hitwall;
    private AudioSource audioSource;

    public GameObject lastPaddleHit;
    //Functions
    void Start()
    {
        ballRb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(WaitFirstBall());
       
    }

    private void InitBall()
    {
        float xSpeed = Random.Range(0, 2) == 0 ? 1 : -1;
        float ySpeed = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb2d.velocity = new Vector2(xSpeed, ySpeed)* initialSpeed;
    }

    private void PlayBallSound(int sound)
    {
        switch (sound)
        {
            case 1: audioSource.clip = goal;
                break;
            case 2: audioSource.clip = hitplayer;
                break;
            case 3: audioSource.clip = hitwall;
                break;
        }
        audioSource.Play();        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {          
            lastPaddleHit = collision.gameObject;
            ballRb2d.velocity *= speedMultiplier;
            PlayBallSound(2);
        }
        else
        {
            PlayBallSound(3);
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("GoalLeft") || collision.gameObject.CompareTag("GoalRight"))
        {
            if (collision.gameObject.CompareTag("GoalLeft"))
                MatchControl.Instance.player1Goal();
            else if (collision.gameObject.CompareTag("GoalRight"))
                MatchControl.Instance.player2Goal();
            PlayBallSound(1);
            if (MatchControl.Instance.Player1Score < 2 && MatchControl.Instance.Player2Score < 2)
            {
                MatchControl.Instance.Restart();
                InitBall();
            }
            else
            {
                MatchControl.Instance.EndGame();
            }
        }
    }


    IEnumerator WaitFirstBall()
    {
        yield return new WaitForSeconds(1);
        InitBall();
    }
}
