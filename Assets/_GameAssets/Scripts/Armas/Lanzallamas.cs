using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lanzallamas : MonoBehaviour {


    [Header("Lanzallamas")]
    [SerializeField] ParticleSystem Fuego;
    [SerializeField] float PonerCargabaston;
    [SerializeField] GameObject hitboxLlamas;
<<<<<<< HEAD
    [SerializeField] float multiplicadorCarga;
    [Header("Bola de fuego")]
    [SerializeField] GameObject ptoSalidaBola;
    [SerializeField] private Transform bolaFuego;
    [SerializeField] float velocidadBola;
    [SerializeField] float gastoBola;
=======
    [SerializeField] float multiplicadorCargar;
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b
    [Header("UI")]
    [SerializeField] Slider MunicionLlamas;

    public static float cargabaston;
    public bool disparandofuego = false;
    public static float cargamaxima;
    private GameObject bola;
    // Use this for initialization
    void Start () {
        cargabaston = PonerCargabaston;
        cargamaxima = PonerCargabaston;
    }

    // Update is called once per frame
    void Update () {
        ControlBaston();
    }

    private void ControlBaston() {
        MunicionLlamas.value = cargamaxima-cargabaston;
        //disparo secundario
        if (Input.GetButtonDown(Configuracion.botonSecundario)&&cargabaston>=gastoBola) {
            cargabaston -= gastoBola;
           bola= Instantiate(bolaFuego.gameObject, ptoSalidaBola.transform.position, ptoSalidaBola.transform.rotation);
            bola.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * velocidadBola);
        }
        //aumentar carga
        if (disparandofuego == false && cargabaston <= cargamaxima) {
<<<<<<< HEAD
            cargabaston += Time.deltaTime/multiplicadorCarga;
=======
            cargabaston += Time.deltaTime/multiplicadorCargar;
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b
            if (cargabaston >= cargamaxima) {
                cargabaston = cargamaxima;
            }
        }
        // apagado baston
<<<<<<< HEAD
        else if (cargabaston <= 0 || (Input.GetButtonUp(Configuracion.botonDisparo) && disparandofuego == true)) {
=======
        if (cargabaston <= 0 || (Input.GetButtonUp(Configuracion.botonDisparo) && disparandofuego == true)) {
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b
            Fuego.Stop();
            hitboxLlamas.SetActive(false);
            disparandofuego = false;
            this.GetComponent<AudioSource>().Stop();
        }
        /*else if (cargabaston <= 0 || (Input.GetButtonDown(Configuracion.botonDisparo) && disparandofuego == true)) {
            Fuego.Stop();
            hitboxLlamas.SetActive(false);
            disparandofuego = false;
            this.GetComponent<AudioSource>().Stop();
        }*/
        //encendido baston
<<<<<<< HEAD
        if ((Input.GetButton(Configuracion.botonDisparo) && disparandofuego == false)) {
=======
        else if ((Input.GetButton(Configuracion.botonDisparo) && disparandofuego == false)) {
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b
            Fuego.Play();
            hitboxLlamas.SetActive(true);
            disparandofuego = true;
            this.GetComponent<AudioSource>().Play();
        }
         /*else if ((Input.GetButtonDown(Configuracion.botonDisparo) && disparandofuego == false)) {
            Fuego.Play();
            hitboxLlamas.SetActive(true);
            disparandofuego = true;
            this.GetComponent<AudioSource>().Play();
        }*/
        //disminuir carga
        else if (disparandofuego == true) {
            cargabaston -= Time.deltaTime;
<<<<<<< HEAD
        }
=======
        } 
>>>>>>> f9348683a4de031621bdfc09079c3aa23d6bf04b
        
    }
}
