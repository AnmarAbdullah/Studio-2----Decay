using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
  protected override void Behavior()
  {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
  }
}
