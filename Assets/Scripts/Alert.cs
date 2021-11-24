using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : State
{
    StateManager distance;

    private void Start()
    {
        distance = GetComponentInParent<StateManager>();
    }
    public override State RunCurrentState()
    {
        throw new System.NotImplementedException();
    }
}
