using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecargarMunicion : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision.gameObject.name);
        print(collision.gameObject.name);
        if (collision.gameObject.tag == Configuracion.tagPlayer) {
            Ballesta.PuedeDisparar = true;
            Lanzallamas.cargabaston = Lanzallamas.cargamaxima;
            Destroy(this.gameObject);
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Debug.Log(hit.gameObject.name);
        print(hit.gameObject.name);
        if (hit.gameObject.tag == Configuracion.tagPlayer) {
            Ballesta.PuedeDisparar = true;
            Lanzallamas.cargabaston = Lanzallamas.cargamaxima;
            Destroy(this.gameObject);
        }
    }
}
