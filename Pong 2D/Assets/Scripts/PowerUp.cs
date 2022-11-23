using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float ScalePlayer = 2;
    [SerializeField] private float duration = 5;
    [SerializeField] private float lifeTime = 8;

    private BallController ball;
    private GameObject playerFocus;
    private SpriteRenderer sprite;
    private Collider2D collider;
    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject,lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            playerFocus = ball.lastPaddleHit;
            collider.enabled = false;
            sprite.enabled = false;
            StartCoroutine(InitPowerUp());
        }
        
    }
    private void changeLimit(float newLimit)
    {
        if(playerFocus.name == "Player 1" || playerFocus.name  == "Player 2")
            playerFocus.GetComponent<PlayerPaddle>().SetLimitYBound(newLimit);
        else
            playerFocus.GetComponent<IAControl>().SetLimitYBound(newLimit);
    }
    IEnumerator InitPowerUp()
    {
        playerFocus.transform.localScale = new Vector3(0.3f,3,0);
        changeLimit(2.5f);
        yield return new WaitForSeconds(duration);
        playerFocus.transform.localScale = new Vector3(0.3f,1.5f,0);
        changeLimit(3.5f);        
        Destroy(gameObject);
    }
}
