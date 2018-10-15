using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAvanzado : EnemigoBase {
    [Header("Avanzado")]
    [SerializeField] float DistanciaPersecucion;
    private Vector3 playerXZ;
    //protected virtual void Update() { }sobreescritura normal
    //protected override void Update() { }
    //base,Update(); llama al update del q hereda
    public override void Update() {
        base.Update();
        //if((this.transform.position- player.transform.position).sqrMagnitude< DistanciaPersecucion) {  }
        if (detectarDistanciaPersonaje() < DistanciaPersecucion) {
            estaPersiguiendo = true;
            playerXZ = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            this.transform.LookAt(playerXZ);
        } else {
            estaPersiguiendo = false;
        }
    }
}
