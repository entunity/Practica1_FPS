using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMovimientoIntro : MonoBehaviour {

    [SerializeField] GameObject rey;
    private void OnTriggerExit(Collider other) {
        if(rey!=null)
            rey.GetComponent<MoverBichosIntro>().enabled = true;
        
    }
    private void OnTriggerStay(Collider other) {
        if (rey != null)
            rey.GetComponent<MoverBichosIntro>().enabled = false;
    }
}
