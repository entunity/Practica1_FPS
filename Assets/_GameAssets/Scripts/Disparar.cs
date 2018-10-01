using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour {


    [SerializeField] Transform objetoACrear;
    [SerializeField] float tiempoentredisparos;
    [SerializeField] GameObject puntodisparo;
    [SerializeField] ParticleSystem Fuego;
    [SerializeField] float cargabaston;
    [SerializeField] GameObject ballesta;
    [SerializeField] GameObject baston;

    private float tiempoactual;
    private GameObject flecha;
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

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update () {

        controlArma();
        if (ballesta.activeSelf == true) { controlBallesta(); }
        if (baston.activeSelf == true) {controlBaston();}
        
       

    }

    private void controlArma() {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            ballesta.SetActive(true);
            baston.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ballesta.SetActive(false);
            baston.SetActive(true);
        }
    }

    private void controlBallesta()
    { 
        //disparo ballesta
        if (Time.time >= tiempoactual && (Input.GetButtonDown("Fire1")))
        {
            flecha = Instantiate(objetoACrear.gameObject, puntodisparo.transform.position, transform.rotation);
            flecha.AddComponent<MoverFlecha>();
            tiempoactual = Time.time + tiempoentredisparos;
        }
    }

    private void controlBaston()
    {
        //Input.GetKey


        //encendido baston
        if ((Input.GetButtonDown("Fire1") && disparandofuego == false))
        {
            Fuego.Play();
            disparandofuego = true;
        }

        //descuento baston
        if (disparandofuego == true)
        {
            cargabaston -= Time.deltaTime;
        }

        //aumentar carga
        if (disparandofuego == false && cargabaston <= cargamaxima)
        {
            cargabaston += Time.deltaTime;
            if (cargabaston >= cargamaxima)
            {
                cargabaston = cargamaxima;
            }
        }

        // apagado baston
        if (cargabaston <= 0|| ((Input.GetButtonDown("Fire1") && disparandofuego == true)))
        {
            Fuego.Stop();
            disparandofuego = false;
        }
    }
}
