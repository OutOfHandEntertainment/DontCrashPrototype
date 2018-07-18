using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	public VehicleFactoryManager factory;

	public float TimeBetweenEvents = 5f;

	// Use this for initialization
	void Start () {
		StartCoroutine(events());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator events() {
		while (true) {
			yield return new WaitForSecondsRealtime(TimeBetweenEvents);

			factory.ConstructVehicle(VehicleFactoryManager.vehicleTypes.light);
		}
	}
}
