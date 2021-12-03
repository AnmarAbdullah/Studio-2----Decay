using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    StateManager distance;
    private void Start()
    {
        distance = GetComponentInParent<StateManager>();
    }
    public override State RunCurrentState()
    {
        //GetComponent<PlayerController>().Health -= 40;
        //do attack animation
        return this;
    }

}
