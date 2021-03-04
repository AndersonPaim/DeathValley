using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barreira : MonoBehaviour
{
   
    public float tempo;
    public float dano;
    public GameObject inimigo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo >= 5)
        {
            Destroy(gameObject);
        }
       

    }
}
