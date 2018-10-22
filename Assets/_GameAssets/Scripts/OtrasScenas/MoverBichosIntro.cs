using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBichosIntro : MonoBehaviour {

    
    [SerializeField] Vector3 PosIni;
    [SerializeField] Vector3 PosFinal;
    [SerializeField] float distancia;
    [SerializeField] Vector3 VectorSeparacion;
    [SerializeField] float velocidad;
    private GameObject player;
    
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        PosIni = this.transform.position;
        PosFinal = this.transform.position - VectorSeparacion;
    }
	
    private void LateUpdate() {
        distancia = Vector3.Distance(player.transform.position, this.transform.position);
        //this.transform.position=new Vector3(PosIni.x, PosIni.y, PosIni.z-distancia*4.5f);
        if (distancia < 8) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, PosFinal, velocidad * 1 * Time.deltaTime);
        } else
            this.transform.position = Vector3.MoveTowards(this.transform.position, PosIni, velocidad * 1 * Time.deltaTime);

        if (this.transform.position.z <= PosFinal.z&&PosIni.z!=PosFinal.z) {
            Destroy(this.gameObject);
        }
        if (this.transform.position.x <= PosFinal.x && PosIni.x != PosFinal.x) {
            Destroy(this.gameObject);
        }
    }
}
