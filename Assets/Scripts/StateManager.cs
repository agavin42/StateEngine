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

	public bool StateP<T1>()
	{
		return Current!=null && typeof(T1).IsAssignableFrom(Current.GetType());
	}

    // Update is called once per frame
    void Update()
    {
        if (Current != null) {
        	try
        	{
        		Current.Trans();
             	Current.Update();
        	}
        	catch (State.StateGoException e)
        	{
        		Go(e.NewState);
        		Update();	// Update again so the new state logic gets called
        	}
        }
    }

    void Go(State state)
    {
    	Previous = Current;
    	Current = state;
    	if (Previous!=null)
    	{
    		Previous.Exit();
    	}

    	Current.Start(this);
      	Debug.Log(gameObject.name + " enter State: " + state.ToString());
	  	Current.Enter();
    }
}
