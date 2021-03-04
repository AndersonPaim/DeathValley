using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torretaTiro : MonoBehaviour
{

    public float distancia;
    public GameObject player;
    public float tempo;
    public Rigidbody shoot;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        tempo += Time.deltaTime;
        player = GameObject.Find("Player");
        distancia = Vector3.Distance(player.transform.position, transform.position);

        transform.LookAt(player.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        if (distancia < 50)
        {
            if (tempo > 3)
            {
                Rigidbody shootClone = (Rigidbody)Instantiate(shoot, transform.position, transform.rotation);
                shootClone.velocity = transform.forward * speed;
                tempo = 0;
            }
        }
    }
}
