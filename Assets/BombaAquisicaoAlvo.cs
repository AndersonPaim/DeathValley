using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaAquisicaoAlvo : MonoBehaviour
{
    public float proximityCheck;
    private Bomba bomba;
    // Start is called before the first frame update
    void Awake()
    {
        bomba = GetComponentInParent<Bomba>();
    }

    // Update is called once per frame
    void OnTriggerEmter(Collider other)
    {
        if(other.tag == "Enemy" && !bomba.target)
        {
            if(proximityCheck > 0)
            {
                var distance = Vector3.Distance(other.transform.position, transform.position);
                if(distance > proximityCheck)
                {
                    AssignTarget(other.transform);
                }
            }
            else
            {
                AssignTarget(other.transform);
            }
        }

    }

    void AssignTarget(Transform target)
    {
        bomba.target = target;
        var magnitude = bomba.rb.velocity.magnitude;
        Vector3 dir = bomba.target.position - transform.position;
        bomba.rb.velocity = Vector3.zero;
        bomba.rb.AddForce(dir.normalized * magnitude, ForceMode.VelocityChange);
    }
}
