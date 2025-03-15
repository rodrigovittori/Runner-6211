using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Runner 6211 - [M1.L3] - Actividad Nº 5 "¡Movimiento entre los carriles!"

public class CharacterScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed; // Velocidad de mov. de mi PJ
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
        /* >> Cambio de carril << */

        // Izquierda
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ) && transform.position.x > -9)
            { transform.Translate(-9, 0, 0); } // Mover el personaje 9 unidades a la izquierda

        // Derecha
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && transform.position.x < 9)
            { transform.Translate(9, 0, 0); } // Mover el personaje 9 unidades a la derecha
    }
    
private void FixedUpdate()
    { rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime); }

}
// Fin de la clase CharacterScript