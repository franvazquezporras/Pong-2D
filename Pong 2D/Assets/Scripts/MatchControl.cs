using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchControl : MonoBehaviour
{
    //Variables
    [SerializeField] private TMP_Text player1ScoreText;
    [SerializeField] private TMP_Text player2ScoreText;
    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;
    [SerializeField] private Transform ball;
    [SerializeField] private TMP_Text winText;
    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelLose;
    [SerializeField] private bool iaGame;
    private int player1Score;
    private int player2Score;
    public int Player2Score { get => player2Score; set => player2Score = value; }
    public int Player1Score { get => player1Score; set => player1Score = value; }
    private static MatchControl instance;


    //Singleton
    public static MatchControl Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<MatchControl>();
            return instance;
        }
    }


    /*********************************************************************************************************************************/
    /*Funcion: player1Goal                                                                                                           */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Aumenta el marcador del jugador 1 en subiendo un punto y actualiza el texto de su marcardor                       */
    /*********************************************************************************************************************************/
    public void player1Goal()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
    }


    /*********************************************************************************************************************************/
    /*Funcion: player2Goal                                                                                                           */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Aumenta el marcador del jugador 2 en subiendo un punto y actualiza el texto de su marcardor                       */
    /*********************************************************************************************************************************/
    public void player2Goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
    }


    /*********************************************************************************************************************************/
    /*Funcion: EndGame                                                                                                               */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Comprueba si alguno de los 2 marcadores a llegado al maximo de goles (10) actualizando el cartel de               */
    /*             victoria/derrota y activandolo.                                                                                   */
    /*********************************************************************************************************************************/
    public void EndGame()
    {
        if(Player2Score == 10)
        {
            if (iaGame)
            {
                winText.text = "You Lose";
                panelLose.SetActive(true);
            }
            else
            {
                winText.text = "Player 2 Win";
                panelLose.SetActive(true);
            }                
        }
        else
        {
            if (iaGame)
            {
                winText.text = "You Win";
                winText.enabled = true;
                StartCoroutine(NextGame());
            }                
            else
            {
                winText.text = "Player 1 Win";
                panelLose.SetActive(true);
            }                
        }
        winText.enabled = true;
        panelWin.SetActive(true);
    }

    /*********************************************************************************************************************************/
    /*Funcion: Restart                                                                                                               */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Reinicia las posiciones de los jugadores(Excepto de la IA) y la pelota al marcar un gol                           */
    /*********************************************************************************************************************************/
    public void Restart()
    {
        if (!iaGame)
            player2Transform.position = new Vector2(player2Transform.position.x, 0);
        player1Transform.position = new Vector2(player1Transform.position.x, 0);
        ball.position = new Vector2(0, 0);
    }


    /*********************************************************************************************************************************/
    /*Funcion: NextGame                                                                                                              */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Corrutina activa el panel de victoria, espera 3 segundos y carga el siguiente nivel                               */
    /*********************************************************************************************************************************/
    IEnumerator NextGame()
    {
        panelWin.SetActive(true);
        yield return new WaitForSeconds(3);
        SelectorLevel nextLevel = new SelectorLevel();      
        nextLevel.nextLevel();
    }
}
