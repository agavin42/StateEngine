using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateA : State
{
	public override void Enter()
	{
		Debug.Log("is A " + StateP<StateA>());
	}

}

public class StateB : State
{
	int Param1;

	public StateB(int param1)
	{
		Param1 = param1;
	}

	public override void Enter()
	{
		Debug.Log("is A/B " + StateP<StateA, StateB>());
	}

	public override void Trans()
	{
		Go(new StateA());
	}
}