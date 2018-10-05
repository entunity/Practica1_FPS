using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {


    [SerializeField] Transform objetoACrear;
    [SerializeField] float tiempoentredisparos;
    [SerializeField] GameObject puntodisparo;
    [SerializeField] ParticleSystem Fuego;
    [SerializeField] float cargabaston;
    [SerializeField] GameObject ballesta;
    [SerializeField] GameObject baston;

     public static float vida=100;

    private float tiempoactual;
    private bool existeflecha;
    public bool disparandofuego=false;
    private float cargamaxima;

    void Start()
    {
        /*
        tiempoentredisparos = 0.4f;
        disparandofuego = false;
        */
        cargamaxima = cargabaston;


    }

    // Update is called once per frame
    void Update () {

        controlArma();
        if (ballesta.activeSelf == true) { controlBallesta(); }
        if (baston.activeSelf == true) {controlBaston();}
        
       

    }

    private void controlArma() {
        if (Input.GetKeyDown(Configuracion.botonArma1)){
            ballesta.SetActive(true);
            baston.SetActive(false);
        }
        if (Input.GetKeyDown(Configuracion.botonArma2))
        {
            ballesta.SetActive(false);
            baston.SetActive(true);
        }
        if (Input.GetKeyDown(Configuracion.botonZoom)) {
            ballesta.SetActive(false);
            baston.SetActive(true);
        }
    }

    private void controlBallesta()
    { 
        //disparo ballesta
        if (Time.time >= tiempoactual && (Input.GetButtonDown(Configuracion.botonDisparo)))
        {
            Instantiate(objetoACrear.gameObject, puntodisparo.transform.position, transform.rotation);
            tiempoactual = Time.time + tiempoentredisparos;
        }
    }

    private void controlBaston()
    {//aumentar carga
        if (disparandofuego == false && cargabaston <= cargamaxima)
        {
            cargabaston += Time.deltaTime;
            if (cargabaston >= cargamaxima)
            {
                cargabaston = cargamaxima;
            }
        }
        // apagado baston
        
        if (cargabaston <= 0|| (Input.GetButtonDown(Configuracion.botonDisparo) && disparandofuego == true))

        {
            Fuego.Stop();
            disparandofuego = false;
        }
        //encendido baston
        else if ((Input.GetButtonDown(Configuracion.botonDisparo) && disparandofuego == false))
        {
            Fuego.Play();
            disparandofuego = true;
        }

        //disminuir carga
        else if (disparandofuego == true)
        {
            cargabaston -= Time.deltaTime;
        }

        
       

        
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == Configuracion.tagEnemigos) {
            vida -= 1;
        }
    }
}
