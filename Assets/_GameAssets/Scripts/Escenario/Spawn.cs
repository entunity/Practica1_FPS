﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour {
    [Header("Enemigo")]
    [SerializeField] List<Transform> Enemigos;
    private Transform Enemigo;
    [Header("Spawn")]
    [SerializeField] List<Transform> PuntosSpawn;
    [SerializeField] float TiempoSpawn;
    [SerializeField] List<Transform> EnemigosSpawn;
    private Transform EnemigoSpawn;
    private GameObject spawn;
    [Header("Boss")]
    [SerializeField] GameObject PuntoSpawnBoss;
    private GameObject boss;
    private bool bossFight = false;
    [Header("UILvl")]
    [SerializeField] Text InfoLvl;
    [SerializeField] Text InfoTiempo;
    private float timer;
    private int[] lvl;
    // Use this for initialization
    void Start () {
        lvl = Configuracion.lvl1;
    }
	
	// Update is called once per frame
	void Update () {
        InfoTiempo.text = ((int)Time.time).ToString();
        //generador enemigo
        timer += Time.deltaTime;
        if (timer >= TiempoSpawn) {
            this.transform.Rotate(0,Random.Range(0,181),0);
            generarEnemigo();
            timer = 0;
        }
        if (Time.time <= (Configuracion.TiemposLvl[0] * Configuracion.MultiplicadorLvl))
        {
            lvl = Configuracion.lvl1;
            InfoLvl.text = "Lvl: 1";
        }
        else if (Time.time <= (Configuracion.TiemposLvl[1] * Configuracion.MultiplicadorLvl))
        {
            lvl = Configuracion.lvl2;
            InfoLvl.text = "Lvl: 2";
        }
        else if (Time.time <= (Configuracion.TiemposLvl[2] * Configuracion.MultiplicadorLvl))
        {
            lvl = Configuracion.lvl3;
            InfoLvl.text = "Lvl: 3";
        }
        else if(bossFight==false) //hacer solo 1 vez
        {
            SpawnBoss();
        }
    }
    private void generarEnemigo() {
        spawn = PuntosSpawn[Random.Range(0, PuntosSpawn.Count())].gameObject;
        int n = Random.Range(1, 11);
        //basico
        if (n <= lvl[0])
        {
            Enemigo = Enemigos[0];
            EnemigoSpawn = EnemigosSpawn[0];
        }
        //avanzado
        else if (n <= lvl[1])
        {
            Enemigo = Enemigos[1];
            EnemigoSpawn = EnemigosSpawn[1];
        }
        //torre
        else if (n <= lvl[2])
        {
            Enemigo = Enemigos[2];
            EnemigoSpawn = EnemigosSpawn[2];
        }
        spawn = Instantiate(EnemigoSpawn.gameObject, spawn.transform.position, spawn.transform.rotation);
        spawn.GetComponent<Rigidbody>().AddRelativeForce(0, 300f, 300f);
        Invoke("ActivarEnemigo", 1.5f);
    }
    private void ActivarEnemigo() {
        Instantiate(Enemigo.gameObject, spawn.transform.position, spawn.transform.rotation);
        Destroy(spawn);
    }
    private void SpawnBoss()
    {
        bossFight = true;
        lvl = Configuracion.lvl1;
        boss=Instantiate(EnemigosSpawn[3].gameObject, PuntoSpawnBoss.transform.position, PuntoSpawnBoss.transform.rotation);
        boss.GetComponent<Rigidbody>().AddRelativeForce(0, 350f, 350f);
        InfoLvl.text = "Boss";
        PuntoSpawnBoss.SetActive(false);
        Invoke("ActivarBoss", 1.5f);
    }
    private void ActivarBoss() {
        if (boss.activeSelf==true) {
        Instantiate(Enemigos[3].gameObject, boss.transform.position, boss.transform.rotation);
        Destroy(boss);
        }
    }

}