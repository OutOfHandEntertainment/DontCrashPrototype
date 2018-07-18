using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleFactory_I {

	public GameObject VehicleBase;

	protected List<GameObject> Frame;
	protected List<GameObject> Cab;
	protected List<GameObject> Cargo;
	protected List<GameObject> Attachment;
	protected List<GameObject> Wheel;

	public abstract void AssembleVehicle();
}
