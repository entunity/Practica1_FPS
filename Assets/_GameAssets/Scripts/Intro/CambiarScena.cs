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
    private void Cambio() {
        SceneManager.LoadScene(Configuracion.Transporte);
    }
    public static void Cambio(String escena) {
        SceneManager.LoadScene(escena);
    }
}
