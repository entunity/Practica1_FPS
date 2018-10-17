using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEstatico : EnemigoBase {
    [Header("Torre")]
    [SerializeField] protected float distanciaDeteccion;
    [SerializeField] protected GameObject canion;
    [SerializeField] protected Transform baseDisparo;
    [SerializeField] protected Transform disparo;
    [SerializeField] protected float Tiempoentredisparos;
    private float tiempoactual;
    private Vector3 playerXZ;
    protected Quaternion RotacionActual;
    protected float VelocidadRotacion=6f;

    public override void Update() {
        base.Update();
        if (detectarDistanciaPersonaje() < distanciaDeteccion) {
            playerXZ = new Vector3(player.transform.position.x, canion.transform.position.y, player.transform.position.z);
            canion.transform.LookAt(playerXZ);
            //RotacionActual = Quaternion.LookRotation(playerXZ - this.transform.position);
            //RotacionActual = Quaternion.Euler(playerXZ);
            //canion.transform.rotation = Quaternion.Slerp(canion.transform.rotation, RotacionActual, Time.deltaTime * VelocidadRotacion);
            if (Time.time >= tiempoactual) {
                disparar();
                tiempoactual = Time.time + Tiempoentredisparos;
            }
        } else {
            canion.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
    void disparar() {
        Quaternion rot= canion.transform.rotation;
        Instantiate(disparo, baseDisparo.transform.position, new Quaternion(rot.x,0,0,0));
    }
}
