using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecargarMunicion : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other) {
        print(other.gameObject.name);
        if (other.gameObject.tag == Configuracion.tagPlayer) {
            Ballesta.PuedeDisparar = true;
            Lanzallamas.cargabaston = Lanzallamas.cargamaxima;
            Destroy(this.gameObject);
        }
    }
}
