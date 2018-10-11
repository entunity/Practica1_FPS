using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : EnemigoBase {
    [Header("Torre")]
    [SerializeField] protected float distanciaDeteccion;
    [SerializeField] protected GameObject canion;
    [SerializeField] protected Transform baseDisparo;
    [SerializeField] protected Transform disparo;
    [SerializeField] protected float Tiempoentredisparos;
    private float tiempoactual;
    private Vector3 playerXZ;

    public override void Update() {
        base.Update();
        if (Vector3.Distance(this.transform.position, player.transform.position) < distanciaDeteccion) {
            playerXZ = new Vector3(player.transform.position.x, canion.transform.position.y, player.transform.position.z);
            canion.transform.LookAt(playerXZ);
            if (Time.time >= tiempoactual) {
                disparar();
                tiempoactual = Time.time + Tiempoentredisparos;
            }

        } else {
            canion.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }
    void disparar() {
        Instantiate(disparo, baseDisparo.transform.position, canion.transform.rotation);
    }
}
