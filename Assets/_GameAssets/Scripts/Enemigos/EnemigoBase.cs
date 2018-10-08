using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBase : MonoBehaviour {
    [Header("Movimiento")]
    [SerializeField] private float velocidad;
    [SerializeField] private float tiempoCambioDireccion;
    [Header("Impacto")]
    [SerializeField] private float danyo;
    [SerializeField] private float distanciaExplosion;
    [SerializeField] private Transform particulaExplosion;

    [Header("Herencia")]
    protected GameObject player;
    [SerializeField] protected bool estaPersiguiendo;


    private Vector3 direccion;
    private float timer;

    // Use this for initialization
    void Start() {
        cambiarDireccion();
        player = GameObject.FindGameObjectWithTag(Configuracion.tagPlayer);
        estaPersiguiendo = false;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
        if (estaPersiguiendo == false) {
            timer += Time.deltaTime;
            if (timer > tiempoCambioDireccion) {
                cambiarDireccion();
                timer = 0;
            }
        }
        if (detectarDistanciaPersonaje() < distanciaExplosion) {
            Configuracion.vida -= danyo;
            morir();
            Debug.Log("Vida: " + Configuracion.vida);

        }
    }
    //mira la distancia al player
    private float detectarDistanciaPersonaje() {
        return Vector3.Distance(this.transform.position, player.transform.position);
    }
    //cambia la direccion en la q mira
    private void cambiarDireccion() {
        direccion = new Vector3(0, Random.Range(-180, 181), 0);
        transform.Rotate(direccion);
    }
    //destrulle el objeto o si no el padre
    public void morir() {
        if (this.transform.parent == null) {
            Instantiate(particulaExplosion.gameObject, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        } else {
            Instantiate(particulaExplosion.gameObject, this.transform.position, this.transform.rotation);
            Destroy(this.transform.parent.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if ((collision.gameObject.tag == Configuracion.tagMunicion)) {
            morir();
        }
        if ((collision.gameObject.tag == Configuracion.tagEntorno)){
            cambiarDireccion();
        }
    }
    
}
