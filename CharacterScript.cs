using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Runner 6211 - [M1.L4] - Actividad Nº 5 "Script para la animación de salto"

public class CharacterScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed; // Velocidad de mov. de mi PJ
    [SerializeField] private float jumpForce; // 7f
    [SerializeField] Animator anim;
    [SerializeField] GameObject menu; // Ventana de GameOver
    private bool isGameOver = false;

    [SerializeField] TMP_Text score; // TMP text donde muestro la puntuación actual
    private float roundScore;        // puntuación a mostrar por pantalla

    void Start()
    {
        
    }
    
    void Update()
    {
        if (!isGameOver) // Mientras siga en partida
        {

        // Aumentar y actualizar puntuación
        roundScore += Time.deltaTime;
        score.text = "Puntos: " + roundScore.ToString("f1");



        /* >> Cambio de carril << */

        // Izquierda
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) ) && transform.position.x > -9)
            { transform.Translate(-9, 0, 0); } // Mover el personaje 9 unidades a la izquierda

        // Derecha
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && transform.position.x < 9)
            { transform.Translate(9, 0, 0); } // Mover el personaje 9 unidades a la derecha

        // Condición de Salto
        if ( ( Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) ) && (rb.velocity.y <= 0.1) )
            { rb.AddForce(transform.up * jumpForce, ForceMode.Impulse); }

        if (( Mathf.Abs(rb.velocity.y) > 0 ) && (transform.position.y > 0.1f))
            { anim.SetBool("jump", true); }
        else
            { anim.SetBool("jump", false); }
        }
        
    }
    
private void FixedUpdate()
    { 
        if (!isGameOver) // Mientras siga en partida
            { rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime); } // El personaje avanza
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
            {
                isGameOver = true;
                menu.SetActive(true);
            }
    }

}
// Fin de la clase CharacterScript