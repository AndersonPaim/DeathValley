using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
  
    public Rigidbody shoot;
    public float speed = 10f;
    public float tempo;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

        tempo += Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
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
