using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
	public State Current = null;
	public State Previous = null;

    // Start is called before the first frame update
    void Start()
    {
        Go(new StateB(1));
    }

    // Update is called once per frame
    void Update()
    {
        if (Current != null) {
        	Current.Update();
        }
    }

    void Go(State state)
    {
    	Previous = Current;
    	Current = state;
    	Current.Start(this);
    	Debug.Log(gameObject.name + " enter State: " + state.ToString());
    }
}
