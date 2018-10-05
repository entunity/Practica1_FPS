using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBase : MonoBehaviour {
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    [SerializeField] float tiempoCambioDireccion;
    [Header("Impacto")]
    [SerializeField] float danyo;
    [SerializeField] float distanciaExplosion;

    [Header("Herencia")]
    public GameObject player;
    public bool estaPersiguiendo;


    private Vector3 direccion;
    private float timer;

    // Use this for initialization
    private void Start() {
        cambiarDireccion();
        player = GameObject.FindGameObjectWithTag(Configuracion.tagPlayer);
        estaPersiguiendo = false;
    }

    // Update is called once per frame
    private void Update() {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        if (estaPersiguiendo == false) {
            timer += Time.deltaTime;
            if (timer > tiempoCambioDireccion) {
                cambiarDireccion();
                timer = 0;
            }

            if (detectarDistanciaPersonaje() < distanciaExplosion) {
                Jugador.vida -= danyo;
                morir();
                Debug.Log("Vida: " + Jugador.vida);

            }
        }
    }
    //mira la distancia al player
    private float detectarDistanciaPersonaje() {
        return Vector3.Distance(this.transform.position, player.transform.position);
    }
    //cambia la direccion en la q mira
    private void cambiarDireccion() {
        direccion = new Vector3(0, Random.Range(-90, 91), 0);
        transform.Rotate(direccion);
    }
    //destrulle el objeto o si padre
    private void morir() {
        if (this.transform.parent == null) {
            Destroy(this.gameObject);
        } else {
            Destroy(this.transform.parent.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if ((collision.gameObject.tag == Configuracion.tagMunicion)) {
            morir();
        }
    }
}
