using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lanzallamas : MonoBehaviour {


    [Header("Lanzallamas")]
    [SerializeField] ParticleSystem Fuego;
    [SerializeField] float PonerCargabaston;
    [SerializeField] GameObject hitboxLlamas;
    [SerializeField] float multiplicadorCargar;
    [Header("UI")]
    [SerializeField] Slider MunicionLlamas;

    public static float cargabaston;
    private float tiempoactual;
    public bool disparandofuego = false;
    public static float cargamaxima;
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
        //aumentar carga
        if (disparandofuego == false && cargabaston <= cargamaxima) {
            cargabaston += Time.deltaTime/multiplicadorCargar;
            if (cargabaston >= cargamaxima) {
                cargabaston = cargamaxima;
            }
        }
        // apagado baston
        if (cargabaston <= 0 || (Input.GetButtonUp(Configuracion.botonDisparo) && disparandofuego == true)) {
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
        else if ((Input.GetButton(Configuracion.botonDisparo) && disparandofuego == false)) {
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
        } 
        
    }
}
