using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particula : MonoBehaviour
{

    public float tempo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempo += Time.deltaTime;

        if (tempo > 3)
        {
            Destroy(gameObject);
        }

    }
}
