using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ballesta : MonoBehaviour {
    [Header("Disparo")]
    [SerializeField] Transform objetoACrear;
    [SerializeField] float tiempoentredisparos;
    [SerializeField] GameObject puntodisparo;
    [Header("UI")]
    [SerializeField] Image MunicionFlecha;
    private float tiempoactual;
    private bool existeflecha;
    public static bool PuedeDisparar;
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
        if (Time.time >= tiempoactual) {
            PuedeDisparar = true;
        } else {
            PuedeDisparar = false;
        }
        if (PuedeDisparar == true) {
            MunicionFlecha.enabled = true;
        } else {
            MunicionFlecha.enabled = false;
        }
    }
}
