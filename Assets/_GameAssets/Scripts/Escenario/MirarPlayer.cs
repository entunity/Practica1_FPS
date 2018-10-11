using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarPlayer : MonoBehaviour {
    private Vector3 playerXZ;
    protected GameObject player;

    private float time;
    private float lerpValue;
    private float speed = 2.0f;
    //OnWillRenderObject, Renderer.isVisible, Renderer.OnBecameVisible
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag(Configuracion.tagPlayer);
    }
	
	// Update is called once per frame
	void Update () {
            playerXZ = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
            this.transform.LookAt(playerXZ);
        time += Time.deltaTime;
        lerpValue = (time / speed);
        transform.position = new Vector3(this.transform.position.x,Mathf.Lerp(this.transform.position.y, this.transform.position.y+0.2f, lerpValue),this.transform.position.z);

    }
    
}
