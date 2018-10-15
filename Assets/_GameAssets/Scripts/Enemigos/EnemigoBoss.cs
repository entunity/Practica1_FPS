using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemigoBoss : EnemigoAvanzado {
    [Header("Boss")]
    [SerializeField] List<GameObject> protectores;
    [SerializeField] float TiempoSpawnEscudo;

    private float TimerSpawn;
    public override void Update() {
        base.Update();
        TimerSpawn += Time.deltaTime;
        if (TimerSpawn >= TiempoSpawnEscudo) {
            GameObject respawn = protectores[Random.Range(0,protectores.Count())];
            respawn.GetComponent<Renderer>().enabled = true;
            respawn.GetComponent<Collider>().enabled = true;
            TimerSpawn = 0;
        }
    }
}
