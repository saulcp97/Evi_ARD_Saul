using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaR : MonoBehaviour
{
    private Vector3 posicionInicial;
    public float anglulo = 0;
    public float velocidad = 1;
    public float rango = 5;
    // Start is called before the first frame update
    void Start() {
        posicionInicial = transform.position/2;
    }

    // Update is called once per frame
    void Update() {
        transform.position = posicionInicial + new Vector3(Mathf.Sin(anglulo) * rango, posicionInicial.y, posicionInicial.z);
        anglulo += velocidad * Time.deltaTime;
    }
}
