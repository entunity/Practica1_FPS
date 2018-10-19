using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMovimientoIntro : MonoBehaviour {

    [SerializeField] GameObject rey;
    [SerializeField] Sprite[] fotos;
    private void Start() {
        GameObject go=GameObject.FindGameObjectWithTag("Player");
        go.GetComponentInChildren<Jugador>().MostrarTexto(Frases.lineas1, fotos, 2);

    }
    private void OnTriggerExit(Collider other) {
        if(rey!=null)
            rey.GetComponent<MoverBichosIntro>().enabled = true;
        
    }
    private void OnTriggerStay(Collider other) {
        if (rey != null)
            rey.GetComponent<MoverBichosIntro>().enabled = false;
    }
}
