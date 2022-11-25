
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAControl : MonoBehaviour
{

    //Variables
    [SerializeField] private float basicSpeed = 3;
    private float currentSpeed = 0;
    [SerializeField] private GameObject ball;
    private Vector2 ballPosition;
    private float limitYBound = 3.5f;


    /*********************************************************************************************************************************/
    /*Funcion: Update                                                                                                                */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Llama por cada frame las funciones de Mover y actualizacion de velocidad de la IA                                 */
    /*********************************************************************************************************************************/
    void Update()
    {
        Move();
        DifficultControl();
    }


    /*********************************************************************************************************************************/
    /*Funcion: DifficultControl                                                                                                      */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Actualiza la velocidad de la IA cada vez que el player meta goles                                                 */
    /*********************************************************************************************************************************/
    private void DifficultControl()
    {        
        if (currentSpeed < basicSpeed + (MatchControl.Instance.Player1Score * 0.5f))
            currentSpeed = basicSpeed + (MatchControl.Instance.Player1Score * 0.5f);      
    }


    /*********************************************************************************************************************************/
    /*Funcion: DifficultControl                                                                                                      */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: limites de movimiento                                                                                   */
    /*Descripción: Actualiza los limites de Y a los que se puede mover la IA                                                         */
    /*********************************************************************************************************************************/
    public void SetLimitYBound(float limit)
    {
        limitYBound = limit;
    }




    /*********************************************************************************************************************************/
    /*Funcion: Move                                                                                                                  */
    /*Desarrollador: Vazquez                                                                                                         */    
    /*Descripción: Actualiza la posicion de la IA en base a la posicion Y de la pelota                                               */
    /*********************************************************************************************************************************/
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
