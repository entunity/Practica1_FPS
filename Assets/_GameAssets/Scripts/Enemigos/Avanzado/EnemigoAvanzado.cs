using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAvanzado : EnemigoBase {
    [Header("Propio")]
    [SerializeField] float distanciaDeteccion;

    private Vector3 playerXZ;

    void FixedUpdate() {

        if (Vector3.Distance(this.transform.position, player.transform.position) < distanciaDeteccion) {
            estaPersiguiendo = true;
            playerXZ = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            this.transform.LookAt(playerXZ);
        } else {
            estaPersiguiendo = false;
        }
    }
}
