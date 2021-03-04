using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingText : MonoBehaviour
{

    public float tempoDestruir = 3;
    public Vector3 Offset = new Vector3(0, 2, 0);
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tempoDestruir);
        transform.localPosition += Offset;
        
    }
    void Update()
    {
        player = GameObject.Find("Player");
        transform.LookAt(player.transform.position);
        transform.Rotate(0, 180, 0);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
      
    }
}
