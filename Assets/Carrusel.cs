using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoYRotacion : MonoBehaviour
{
    public float velocidadRotacion = 50f;
    public float distanciaTraslacion = 3.4f;
    public float tiempoEspera = 1f;

    private float anguloActual = 0f;

    void Start()
    {
        // Comenzar la secuencia
        StartCoroutine(EjecutarSecuencia());
    }

    IEnumerator EjecutarSecuencia()
    {
        while (true)
        {
            // Rotar 360 grados en el eje Y
            yield return RotarEnY(360f);

            // Detenerse
            yield return new WaitForSeconds(tiempoEspera);

            // Trasladarse hacia arriba
            yield return TrasladarEnY(distanciaTraslacion);

            // Detenerse
            yield return new WaitForSeconds(tiempoEspera);

            // Rotar 360 grados en el eje Y
            yield return RotarEnY(360f);

            // Detenerse
            yield return new WaitForSeconds(tiempoEspera);

            // Trasladarse hacia abajo
            yield return TrasladarEnY(-2 * distanciaTraslacion);

            // Detenerse
            yield return new WaitForSeconds(tiempoEspera);

            // Rotar 360 grados en el eje Y
            yield return RotarEnY(360f);

            // Detenerse
            yield return new WaitForSeconds(tiempoEspera);

            // Trasladarse hacia arriba
            yield return TrasladarEnY(distanciaTraslacion);

            // Detenerse
            yield return new WaitForSeconds(tiempoEspera);

            // Resetear rotación a 0
            anguloActual = 0f;

            // Esperar un tiempo antes de repetir la secuencia
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    IEnumerator RotarEnY(float angulo)
    {
        float anguloInicial = anguloActual;
        float anguloObjetivo = anguloInicial + angulo;

        while (anguloActual < anguloObjetivo)
        {
            float pasoRotacion = velocidadRotacion * Time.deltaTime;
            anguloActual += pasoRotacion;
            transform.Rotate(Vector3.up, pasoRotacion);
            yield return null;
        }
    }

    IEnumerator TrasladarEnY(float distancia)
    {
        Vector3 posicionInicial = transform.position;
        Vector3 posicionObjetivo = posicionInicial + Vector3.up * distancia;

        while (Vector3.Distance(transform.position, posicionObjetivo) > 0.01f)
        {
            float pasoTraslacion = velocidadRotacion * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, pasoTraslacion);
            yield return null;
        }
    }
}

