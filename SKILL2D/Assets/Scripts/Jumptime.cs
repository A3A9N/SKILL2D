using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Jumptime : MonoBehaviour
{
    public TextMeshProUGUI tiempoTexto; // Arrastra aqu� el componente de texto desde el inspector
    private float tiempo;
    private bool estaContando;

    void Start()
    {
        tiempo = 0f;
        estaContando = false;
        ActualizarTexto();
    }

    void Update()
    {
        // Si est� contando, incrementa el tiempo
        if (estaContando)
        {
            tiempo += Time.deltaTime;
            ActualizarTexto();
        }

        // Inicia el cron�metro con el click izquierdo
        if (Input.GetMouseButtonDown(0)) // Bot�n izquierdo
        {
            estaContando = true;
        }

        // Detiene el cron�metro con el click derecho
        if (Input.GetMouseButtonDown(1)) // Bot�n derecho
        {
            estaContando = false;
        }

        // Resetea el cron�metro con la rueda del rat�n hacia arriba
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // Rueda hacia arriba
        {
            tiempo = 0f;
            estaContando = false;
            ActualizarTexto();
        }
    }

    void ActualizarTexto()
    {
        // Formatea el tiempo como MM:SS:MS
        int minutos = Mathf.FloorToInt(tiempo / 60f);
        int segundos = Mathf.FloorToInt(tiempo % 60f);
        int milisegundos = Mathf.FloorToInt((tiempo % 1f) * 100f); // Milisegundos (dos d�gitos)

        tiempoTexto.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
    }
}
