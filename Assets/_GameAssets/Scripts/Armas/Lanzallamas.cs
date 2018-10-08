using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzallamas : MonoBehaviour {


    [Header("Lanzallamas")]
    [SerializeField] ParticleSystem Fuego;
    [SerializeField] float cargabaston;
    [SerializeField] GameObject hitboxLlamas;


    private float tiempoactual;
    public bool disparandofuego = false;
    private float cargamaxima;
    // Use this for initialization
    void Start () {
        cargamaxima = cargabaston;
    }

    // Update is called once per frame
    void Update () {
        ControlBaston();
    }

    private void ControlBaston() {//aumentar carga
        if (disparandofuego == false && cargabaston <= cargamaxima) {
            cargabaston += Time.deltaTime;
            if (cargabaston >= cargamaxima) {
                cargabaston = cargamaxima;
            }
        }
        // apagado baston

        if (cargabaston <= 0 || (Input.GetButtonDown(Configuracion.botonDisparo) && disparandofuego == true)) {
            Fuego.Stop();
            hitboxLlamas.SetActive(false);
            disparandofuego = false;
        }
        //encendido baston
        else if ((Input.GetButtonDown(Configuracion.botonDisparo) && disparandofuego == false)) {
            Fuego.Play();
            hitboxLlamas.SetActive(true);
            disparandofuego = true;
        }

        //disminuir carga
        else if (disparandofuego == true) {
            cargabaston -= Time.deltaTime;
        }
    }
}
