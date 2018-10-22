using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CambiarScena : MonoBehaviour {
    [SerializeField] Transform particula;
    [SerializeField] Sprite[] fotos;
    [SerializeField] float tiempoEntreFrases;
    private GameObject objeto;
    [SerializeField] Text textoFinal ;
    public static bool ganado;
    [SerializeField] AudioClip win;
    [SerializeField] AudioClip lose;
    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == Configuracion.tagPlayer) {

            other.GetComponent<CharacterController>().enabled = false;
            
            CrearParticulas(other.gameObject, new Vector3(-2f, 0, 0));
            CrearParticulas(other.gameObject, new Vector3(-2f, 0, 0));
            CrearParticulas(other.gameObject, new Vector3(0, 2f, 0));
            CrearParticulas(other.gameObject, new Vector3(0, -2f, 0));
            
            other.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas2, fotos, tiempoEntreFrases);
            Invoke("Cambio", tiempoEntreFrases* Frases.lineas2.Length);
        }
    }
    private void CrearParticulas(GameObject player,Vector3 distancia) {
        objeto = Instantiate(particula.gameObject, player.transform.position + distancia, particula.transform.rotation);
        objeto.GetComponent<Orbitar>().target = player.transform;
    }
    private void Awake() {
        if (textoFinal != null) {
            if (ganado) {
                textoFinal.text = "¡Enhorabuena, sigues vivo!/r/nQue no es poco...";
                this.GetComponent<AudioSource>().clip = win;
            } else {
                this.GetComponent<AudioSource>().clip = lose;
                textoFinal.text = "Uno mas que cae...";
            }
            this.GetComponent<AudioSource>().Play();
        }
    }
    
    private void Cambio() {
        SceneManager.LoadScene(Configuracion.Transporte);
    }
    public void Cambio(String escena) {
        SceneManager.LoadScene(escena);
    }
    public static void CambiarScene(String escena) {
        SceneManager.LoadScene(escena);
    }
    public static void CambiarScene(String escena,bool ganar) {
        Debug.Log(ganar);
        ganado = ganar;
        SceneManager.LoadScene(escena);
        
    }
    public void salir() {
        Application.Quit();
    }

}
