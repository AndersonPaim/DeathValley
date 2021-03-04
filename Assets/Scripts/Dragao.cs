using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragao : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocidade;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, velocidade * Time.deltaTime, 0);
    }
}
