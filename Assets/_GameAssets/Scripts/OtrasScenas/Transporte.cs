using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporte : MonoBehaviour {
    [SerializeField] Sprite[] fotos;
    [SerializeField] GameObject UI;
    [SerializeField] GameObject armaInicial;
    [SerializeField] GameObject tutorial;
    private GameObject Player;
    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas3, fotos, 2);
    }
	
	// Update is called once per frame
	void Update () {
        if (Jugador.lineaActual == 3) {
            UI.SetActive(true);
            armaInicial.SetActive(true);
            tutorial.SetActive(true);
            Player.GetComponentInChildren<Jugador>().enabled = false;
            Player.GetComponentInChildren<Ballesta>().enabled = false;
            Player.GetComponentInChildren<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //Time.timeScale = 0.1f;
        }
	}
    public void Aceptar() {
        //Time.timeScale = 1f;
        tutorial.SetActive(false);
        Player.GetComponentInChildren<Jugador>().enabled = true;
        Player.GetComponentInChildren<Ballesta>().enabled = true;
        Player.GetComponentInChildren<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
        //esperar y cambiar escena
        CambiarScena.CambiarScene(Configuracion.LvlJugable);
    }
}
