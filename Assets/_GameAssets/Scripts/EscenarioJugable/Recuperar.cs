using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recuperar : MonoBehaviour {

    private float AnguloGiro = 2f;
    private Vector3 PosicionInicial;
    private Vector3 PosicionFinal;
    private float altura = 0.5f;
    private float speed = 1.0f;
    private void Start() {

        PosicionInicial = this.transform.position;
        PosicionFinal = new Vector3(this.transform.position.x, this.transform.position.y + altura, this.transform.position.z);
        this.transform.position = new Vector3(PosicionInicial.x, Random.Range(PosicionInicial.y, PosicionFinal.y), PosicionInicial.z);
    }
    private void Update() {
        this.transform.Rotate(new Vector3(0, AnguloGiro, 0));
        this.transform.position = Vector3.Lerp(PosicionInicial, PosicionFinal, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
    [SerializeField] int recargar;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Configuracion.tagPlayer) {
            if (recargar == 1) {
                Ballesta.PuedeDisparar = true;
                Lanzallamas.cargabaston = Lanzallamas.cargamaxima;
                
            }
            else if (recargar == 2) {
                Jugador.vidaPlayer = Jugador.maxVidaPlayer;
            }
            this.gameObject.SetActive(false);
        }
    }
}
