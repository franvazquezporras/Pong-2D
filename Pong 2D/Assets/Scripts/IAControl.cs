
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAControl : MonoBehaviour
{
    [SerializeField] private float basicSpeed = 3;
    private float currentSpeed = 0;
    [SerializeField] private GameObject ball;
    private Vector2 ballPosition;
    private float LimitYBound = 3.5f;
    void Update()
    {
        Move();
        DifficultControl();
    }
    
    private void DifficultControl()
    {
        Debug.Log("VELOCIDAD " + currentSpeed);
        if (currentSpeed < basicSpeed + (GameManager.Instance.Player1Score*0.5f))
            currentSpeed = basicSpeed + (GameManager.Instance.Player1Score * 0.5f);      
    }

  

    private void Move()
    {
        ballPosition = ball.transform.position;
        Vector2 playerPosition = transform.position;
        if (transform.position.y > ballPosition.y)                   
            playerPosition.y = Mathf.Clamp(playerPosition.y + (-currentSpeed * Time.deltaTime), -LimitYBound, LimitYBound);
        else if (transform.position.y < ballPosition.y)
            playerPosition.y = Mathf.Clamp(playerPosition.y + currentSpeed * Time.deltaTime, -LimitYBound, LimitYBound);
        transform.position = playerPosition;
    }
}
