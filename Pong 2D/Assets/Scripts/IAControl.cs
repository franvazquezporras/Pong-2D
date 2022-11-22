
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAControl : MonoBehaviour
{
    [SerializeField] private float basicSpeed = 3;
    private float currentSpeed = 0;
    [SerializeField] private GameObject ball;
    private Vector2 ballPosition;
    private float limitYBound = 3.5f;
    void Update()
    {
        Move();
        DifficultControl();
    }
    
    private void DifficultControl()
    {        
        if (currentSpeed < basicSpeed + (MatchControl.Instance.Player1Score * 0.5f))
            currentSpeed = basicSpeed + (MatchControl.Instance.Player1Score * 0.5f);      
    }


    public void SetLimitYBound(float limit)
    {
        limitYBound = limit;
    }
    private void Move()
    {
        ballPosition = ball.transform.position;
        Vector2 playerPosition = transform.position;
        if (transform.position.y > ballPosition.y)                   
            playerPosition.y = Mathf.Clamp(playerPosition.y + (-currentSpeed * Time.deltaTime), -limitYBound, limitYBound);
        else if (transform.position.y < ballPosition.y)
            playerPosition.y = Mathf.Clamp(playerPosition.y + currentSpeed * Time.deltaTime, -limitYBound, limitYBound);
        transform.position = playerPosition;
    }
}
