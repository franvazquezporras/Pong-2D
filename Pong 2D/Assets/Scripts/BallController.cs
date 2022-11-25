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



    /*********************************************************************************************************************************/
    /*Funcion: Start                                                                                                                 */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Asigna las referencias de las variables e inicia la corrutina para la primera pelota                              */
    /*********************************************************************************************************************************/
    void Start()
    {
        ballRb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(WaitFirstBall());
       
    }

    /*********************************************************************************************************************************/
    /*Funcion: InitBall                                                                                                              */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Genera la direccion de salida de la pelota de forma aleatoria en las 4 diagonales y asigna la velocidad a la misma*/
    /*********************************************************************************************************************************/
    private void InitBall()
    {
        float xSpeed = Random.Range(0, 2) == 0 ? 1 : -1;
        float ySpeed = Random.Range(0, 2) == 0 ? 1 : -1;
        ballRb2d.velocity = new Vector2(xSpeed, ySpeed)* initialSpeed;
    }

    /*********************************************************************************************************************************/
    /*Funcion: PlayBallSound                                                                                                         */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: Sonido                                                                                                  */
    /*Descripción: Se reproduce el sonido que recibe como parametro de entrada                                                       */
    /*********************************************************************************************************************************/
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

    /*********************************************************************************************************************************/
    /*Funcion: OnCollisionEnter2D                                                                                                    */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: colision de otro objeto                                                                                 */
    /*Descripción: Si golpea una de las palas (jugadores) aumenta la velocidad de la pelota                                          */
    /*********************************************************************************************************************************/
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


    /*********************************************************************************************************************************/
    /*Funcion: OnTriggerEnter2D                                                                                                      */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: colision de otro objeto                                                                                 */
    /*Descripción: Comprueba si a llegado a marcar un gol y en que porteria se ha marcado                                            */
    /*********************************************************************************************************************************/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("GoalLeft") || collision.gameObject.CompareTag("GoalRight"))
        {
            if (collision.gameObject.CompareTag("GoalLeft"))
                MatchControl.Instance.player1Goal();
            else if (collision.gameObject.CompareTag("GoalRight"))
                MatchControl.Instance.player2Goal();
            PlayBallSound(1);
            if (MatchControl.Instance.Player1Score < 10 && MatchControl.Instance.Player2Score < 10)
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

    /*********************************************************************************************************************************/
    /*Funcion: WaitFirstBall                                                                                                         */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Espera un tiempo antes de iniciar el movimiento de la pelota                                                      */
    /*********************************************************************************************************************************/
    IEnumerator WaitFirstBall()
    {
        yield return new WaitForSeconds(1);
        InitBall();
    }
}
