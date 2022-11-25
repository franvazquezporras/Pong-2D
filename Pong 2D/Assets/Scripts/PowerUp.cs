using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //Variables
    [SerializeField] private float ScalePlayer = 2;
    [SerializeField] private float duration = 5;
    [SerializeField] private float lifeTime = 8;
    private BallController ball;
    private GameObject playerFocus;
    private SpriteRenderer sprite;
    private Collider2D colliderPowerUp;



    /*********************************************************************************************************************************/
    /*Funcion: Awake                                                                                                                 */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Asigna las referencias a las variables y prepara la destruccion del objeto  si este no se obtiene antes           */
    /*             del tiempo definido                                                                                               */
    /*********************************************************************************************************************************/
    private void Awake()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
        colliderPowerUp = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject,lifeTime);
    }


    /*********************************************************************************************************************************/
    /*Funcion: OnTriggerEnter2D                                                                                                      */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: colision de otro objeto                                                                                 */
    /*Descripción: Comprueba si el objeto con el que colisiona es la pelota, comprueba cual fue la ultima pala que golpeo la pelota  */
    /*             desactiva la colision y el sprite del powerUp e inicia la corrutina InitPowerUp                                   */
    /*********************************************************************************************************************************/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            playerFocus = ball.lastPaddleHit;
            colliderPowerUp.enabled = false;
            sprite.enabled = false;
            StartCoroutine(InitPowerUp());
        }
        
    }


    /*********************************************************************************************************************************/
    /*Funcion: changeLimit                                                                                                           */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: nuevo limite de movimiento                                                                              */
    /*Descripción: Modifica el limite al que se pueden mover en Y las paletas de los jugadores                                       */
    /*********************************************************************************************************************************/
    private void changeLimit(float newLimit)
    {
        if(playerFocus.name == "Player 1" || playerFocus.name  == "Player 2")
            playerFocus.GetComponent<PlayerPaddle>().SetLimitYBound(newLimit);
        else
            playerFocus.GetComponent<IAControl>().SetLimitYBound(newLimit);
    }

    /*********************************************************************************************************************************/
    /*Funcion: InitPowerUp                                                                                                           */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Modifica el tamaño de la paleta, espera el tiempo de duracion del powerUp y vuelve el tamaño a su estado inicial  */
    /*             por ultimo destruye el objeto powerUp                                                                             */
    /*********************************************************************************************************************************/
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
