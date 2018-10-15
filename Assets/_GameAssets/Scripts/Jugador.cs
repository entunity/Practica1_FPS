using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

    [Header("Jugador")]
    [SerializeField] List<GameObject> listaArmas;
    [SerializeField] Camera camara;
    [SerializeField] float MaxVidaPlayer;
    [Header("Interfaz")]
    [SerializeField] Slider BarraVida;
    [SerializeField] Text TextoVida;

    public static float VidaPlayer;
    public static float DanioPlayer = 0;
    public enum enumArmas : int {
        ballesta = 0,
        lanzallamas = 1

    }
    void Start() {
        Jugador.DanioPlayer = 5;
        VidaPlayer = MaxVidaPlayer;
    }
    void Update() {
        controlArma();
        ControlUi();
        //ocultarArmas(armaActiva);
    }
    private void ControlUi() {
        BarraVida.value = VidaPlayer/ MaxVidaPlayer;
        TextoVida.text = VidaPlayer + "/"+ MaxVidaPlayer;
       
    }
    private void controlArma() {
        if (Input.GetKeyDown(Configuracion.botonArma1)){
            ActivarArmas((int)Jugador.enumArmas.ballesta);
            Jugador.DanioPlayer = 5;
        }
        if (Input.GetKeyDown(Configuracion.botonArma2))
        {
            ActivarArmas((int)Jugador.enumArmas.lanzallamas);
            Jugador.DanioPlayer = 1;
        }
        if (Input.GetButton(Configuracion.botonZoom)) {
            camara.fieldOfView = Configuracion.FovZoom;
        } else {
            camara.fieldOfView = Configuracion.FovPlayer;
        }
    }
    private void ActivarArmas(int arma) {
        for (int n = 0; n < listaArmas.Count; n++) {
            listaArmas[n].SetActive(false);
        }
        listaArmas[arma].SetActive(true);
    }
    private void OnTriggerEnter(Collider other) {
        print(other.gameObject.name);
        if (other.gameObject.tag == Configuracion.tagMunicion) {
            Ballesta.PuedeDisparar = true;
            Lanzallamas.cargabaston = Lanzallamas.cargamaxima;
            Destroy(other.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.name);
        print(collision.gameObject.name);
        if (collision.gameObject.tag == Configuracion.tagMunicion) {
            Ballesta.PuedeDisparar = true;
            Lanzallamas.cargabaston = Lanzallamas.cargamaxima;
            Destroy(collision.gameObject);
        }
    }

}
