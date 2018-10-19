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
    [SerializeField] GameObject dialogo;
    [SerializeField] Image fotoEnemigo;
    [SerializeField] Text textoDialogo;
    private String[] textosDial;
    private Sprite[] fotosDial;
    public static int lineaActual;
    void Start() {
        Jugador.danioPlayer = 5;
        vidaPlayer = ponerMaxVidaPlayer;
        maxVidaPlayer = ponerMaxVidaPlayer;
        //dialogo.SetActive(false);
    }
    void Update() {
        controlArma();
        ControlUi();
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
        
    }
    private void ActivarArmas(int arma) {
        for (int n = 0; n < listaArmas.Count; n++) {
            listaArmas[n].SetActive(false);
        }
        listaArmas[arma].SetActive(true);
    }
    public void MostrarTexto(String[] textos,Sprite[] fotos,float tiempo) {
        
        dialogo.SetActive(true);
        lineaActual =0;
        this.textosDial = textos;
        this.fotosDial = fotos;
        InvokeRepeating("CambiarTexto", 0, tiempo);
    }
    public void CambiarTexto() {
        textoDialogo.text = textosDial[lineaActual];
        fotoEnemigo.sprite = fotosDial[UnityEngine.Random.Range(0, fotosDial.Length)];
        lineaActual += 1;
        if (lineaActual == textosDial.Length) {
            CancelInvoke();
            dialogo.SetActive(false);
        }
    }
}
