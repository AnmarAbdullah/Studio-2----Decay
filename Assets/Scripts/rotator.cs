using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public GameObject boss;
    public float speed;

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
