using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampas : MonoBehaviour {
    [SerializeField] float multiplicador;
    private float andar;
    private float correr;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other) {
        if (other.tag == Configuracion.tagPlayer) {
            andar=other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed;
            correr = other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed;
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.tag == Configuracion.tagPlayer) {
            other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed= andar * multiplicador;
            other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed= correr* multiplicador;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == Configuracion.tagPlayer) {
            other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_WalkSpeed = andar;
            other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_RunSpeed = correr;
        }
    }
}
