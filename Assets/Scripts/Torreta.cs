using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Torreta : MonoBehaviour
{
    public float distancia;
    public GameObject player;
      

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
        distancia = Vector3.Distance(player.transform.position, transform.position);
        

        if (distancia < 200)
        {
            transform.LookAt(player.transform.position);
            transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 180);

        }
    }
}
