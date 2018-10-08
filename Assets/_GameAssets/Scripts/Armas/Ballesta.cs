using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballesta : MonoBehaviour {
    
    [SerializeField] Transform objetoACrear;
    [SerializeField] float tiempoentredisparos;
    [SerializeField] GameObject puntodisparo;
    private float tiempoactual;
    private bool existeflecha;
    private void Update() {
        ControlBallesta();
    }
    // Use this for initialization
    private void ControlBallesta() {
        //disparo ballesta
        if (Time.time >= tiempoactual && (Input.GetButtonDown(Configuracion.botonDisparo))) {
            Instantiate(objetoACrear.gameObject, puntodisparo.transform.position, transform.rotation);
            tiempoactual = Time.time + tiempoentredisparos;
        }
    }
}
