using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarPlayer : MonoBehaviour {

    //Datos
    protected GameObject player;
    private float speed = 2.0f;
    private float altura = 1f;
    //Posicion
    private Vector3 playerXZ;
    private Vector3 PosicionInicial;
    private Vector3 PosicionFinal;
    private void Awake() {
        player = GameObject.FindGameObjectWithTag(Configuracion.tagPlayer);
        PosicionInicial = this.transform.position;
        PosicionFinal = new Vector3(this.transform.position.x, this.transform.position.y + altura, this.transform.position.z);
    }
    void Start () {
        this.transform.position = new Vector3(PosicionInicial.x, Random.Range(PosicionInicial.y, PosicionFinal.y), PosicionInicial.z);
    }
	
	// Update is called once per frame
	void Update () {
        playerXZ = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        this.transform.LookAt(playerXZ);
        this.transform.position = Vector3.Lerp(PosicionInicial, PosicionFinal, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);

    }
    
}
