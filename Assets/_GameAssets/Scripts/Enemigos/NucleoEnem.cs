using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NucleoEnem : EnemigoBase {

    
    private void Start() {}
    private void Update() {}
    private void OnCollisionEnter(Collision collision) {
        if ((collision.gameObject.tag == Configuracion.tagMunicion)) {
            morir();
        }
    }
    }
