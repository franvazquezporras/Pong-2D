using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Variables
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;

    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;
    [SerializeField] private Transform ball;

    private int player1Score;
    private int player2Score;

    private static GameManager instance;


    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }


    public void player1Goal()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
    }

    public void player2Goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
    }


   public void Restart()
    {
        player1Transform.position = new Vector2(player1Transform.position.x, 0);
        player2Transform.position = new Vector2(player2Transform.position.x, 0);
       ball.position = new Vector2(0, 0);
    }
}
