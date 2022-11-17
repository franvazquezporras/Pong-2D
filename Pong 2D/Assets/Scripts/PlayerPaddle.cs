using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    //Variables
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPlayer1;
    private float LimitYBound = 3.5f;

    //Functions
    void Update()
    {
        float movement; 
        if(isPlayer1)
            movement = Input.GetAxisRaw("Vertical");
        else
            movement = Input.GetAxisRaw("Vertical2");

        Vector2 playerPosition = transform.position;
        playerPosition.y = Mathf.Clamp(playerPosition.y + movement * speed * Time.deltaTime, -LimitYBound, LimitYBound);
        transform.position = playerPosition;       
    }
}
