using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour {

    [Header("Jugador")]
    [SerializeField] List<GameObject> listaArmas;
    [SerializeField] Camera camara;
    [SerializeField] float ponerMaxVidaPlayer;
    public static float maxVidaPlayer;
    public static float vidaPlayer;
    public static float danioPlayer = 0;
    public enum enumArmas : int {
        ballesta = 0,
        lanzallamas = 1

    }
    [Header("Interfaz")]
    [SerializeField] private Slider BarraVida;
    [SerializeField] private Text TextoVida;
    //[SerializeField] private Canvas dialogo;
    //[SerializeField] private Text PonerTextoDialogo;
    //[SerializeField] private Image fotoEnemigo;
    public static Text TextoDialogo;
    void Start() {
        Jugador.danioPlayer = 5;
        vidaPlayer = ponerMaxVidaPlayer;
        maxVidaPlayer = ponerMaxVidaPlayer;
    }
    void Update() {
        controlArma();
        ControlUi();
        //PonerTextoDialogo = TextoDialogo;
        //ocultarArmas(armaActiva);
    }
    private void ControlUi() {
        BarraVida.value = vidaPlayer/ maxVidaPlayer;
        TextoVida.text = vidaPlayer + "/"+ maxVidaPlayer;
       
    }
    private void controlArma() {
        if (Input.GetKeyDown(Configuracion.botonArma1)){
            ActivarArmas((int)Jugador.enumArmas.ballesta);
            Jugador.danioPlayer = 5;
        }
        if (Input.GetKeyDown(Configuracion.botonArma2))
        {
            ActivarArmas((int)Jugador.enumArmas.lanzallamas);
            Jugador.danioPlayer = 1;
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
    /*public static void MostrarTexto(String TextoDial) {
        TextoDialogo.text = TextoDial;
    }*/
}
