using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : EnemigoBase {
    
    [SerializeField] float distanciaDeteccion;
    [SerializeField] GameObject canion;
    [SerializeField] Transform baseDisparo;
    [SerializeField] Transform disparo;
    [SerializeField] float tiempoentredisparos;
    private float tiempoactual;
    private Vector3 playerXZ;
    
    private void LateUpdate() {
        
        if (Vector3.Distance(this.transform.position, player.transform.position) < distanciaDeteccion) {
            playerXZ = new Vector3(player.transform.position.x, canion.transform.position.y, player.transform.position.z);
            
            canion.transform.LookAt(playerXZ);
            if (Time.time >= tiempoactual)
            {
                disparar();
                tiempoactual = Time.time + tiempoentredisparos;
            }
        } else {
            canion.transform.rotation=new Quaternion(0,0,0,0);
        }
    }
    void disparar() {
        Instantiate(disparo, baseDisparo.transform.position, canion.transform.rotation);
    }
}
