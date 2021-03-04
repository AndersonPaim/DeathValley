using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidade;
    public float tempo;
    Camera camera1;
    Camera camera2;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject titulo;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        tempo += Time.deltaTime;

        if (tempo < 8)
        {
            transform.Rotate(0, velocidade * Time.deltaTime, 0);
        }
        else
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            Destroy(gameObject);
            Destroy(titulo);
        }
    }
}
