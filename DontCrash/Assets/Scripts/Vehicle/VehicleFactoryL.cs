using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleFactoryL : VehicleFactory_I {

	private GameObject frame, cab, cargo, wheel, attachment;
	private static System.Random rand;

	public VehicleFactoryL() {
		rand = new System.Random();
	}

	public override void AssembleVehicle() {
		Instantiate(VehicleBase);
	}

	private GameObject selectFrame() {
		int selectedIndex = rand.Next(0, Frame.Count);
		return Frame[selectedIndex];
	}

	private GameObject selectCab() {
		int selectedIndex = rand.Next(0, Cab.Count);
		return Cab[selectedIndex];
	}

	private GameObject selectCargo() {
		int selectedIndex = rand.Next(0, Cargo.Count);
		return Cargo[selectedIndex];
	}

	private GameObject selectWheel() {
		int selectedIndex = rand.Next(0, Wheel.Count);
		return Wheel[selectedIndex];
	}

	private GameObject selectAttachment() {
		int selectedIndex = rand.Next(0, Attachment.Count);
		return Attachment[selectedIndex];
	}
}
