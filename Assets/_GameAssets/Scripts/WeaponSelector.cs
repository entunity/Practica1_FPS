using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour {

    [Header("Jugador")]
    [SerializeField] List<GameObject> listaArmas;
    void Start() {
        Configuracion.DanioPlayer = 5;
    }
    void Update() {
        controlArma();
        //ocultarArmas(armaActiva);
    }
    private void controlArma() {
        if (Input.GetKeyDown(Configuracion.botonArma1)){
            ActivarArmas((int)Configuracion.enumArmas.ballesta);
            Configuracion.DanioPlayer = 5;
        }
        if (Input.GetKeyDown(Configuracion.botonArma2))
        {
            ActivarArmas((int)Configuracion.enumArmas.lanzallamas);
            Configuracion.DanioPlayer = 1;
        }
        if (Input.GetKeyDown(Configuracion.botonZoom)) {
        }
    }

    private void ActivarArmas(int arma) {
        for (int n = 0; n < listaArmas.Count; n++) {
            listaArmas[n].SetActive(false);
        }
        listaArmas[arma].SetActive(true);
    }
    
}
