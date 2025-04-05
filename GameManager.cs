using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para trabajar con Escenas (Scenes)

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform posJugador;

    private float longSegmentoPista = 106.3f;
    private float longTotalPista = 0f; // La longitud total de la pista hasta ahora en el eje Z
    private int cantSegmentosExtra = 8;

    [Header("Lista Prefabs: ")]
    [SerializeField] List<GameObject> listaPrefabs = new List<GameObject>(); // Lista de prefabs

    void Start()
    {
        //Application.targetFrameRate = 60;
        for (int s = 0; s < cantSegmentosExtra; s++)
            { AgregarSegmentoPista(); }
    }

    void Update()
    {
        if ( posJugador.position.z > (longTotalPista - (longSegmentoPista * cantSegmentosExtra)) ) // Si ya estoy en el último tramo spawneado...
            { AgregarSegmentoPista(); } // Agregamos otro segmento
    }

    public void AgregarSegmentoPista()
        {
            Instantiate(listaPrefabs[Random.Range(0, (listaPrefabs.Count))], transform.forward * longTotalPista, transform.rotation);   
            longTotalPista += longSegmentoPista; // Después de spawnear un nvo segmento de pista, actualizo la long total
        }
    
    public void RestartGame()
        { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
        
}