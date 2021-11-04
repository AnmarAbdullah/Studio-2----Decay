using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public GameObject boss;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Orbit();
    }

    void Orbit()
    {
        transform.RotateAround(boss.transform.position, Vector3.up, speed * Time.deltaTime);
    }

}
