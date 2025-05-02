using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class PlatesCounterVisual : Node3D {


	[Export] private PlatesCounter _PlatesCounter;
	[Export] private Node3D _CounterTopPoint;
	[Export] private PackedScene _PlateVisualScene;

	private List<Node3D> plateVisualInstancesList = new List<Node3D>();



	public override void _Ready() {
		_PlatesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
		_PlatesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
	}

	private void PlatesCounter_OnPlateSpawned() {
		Node3D plateVisualInstance = _PlateVisualScene.Instantiate() as Node3D;
		_CounterTopPoint.AddChild(plateVisualInstance);

		float plateOffsetY = 0.1f;
		plateVisualInstance.Position = new Vector3(0, plateOffsetY * plateVisualInstancesList.Count(), 0);

		plateVisualInstancesList.Add(plateVisualInstance);
	}

	private void PlatesCounter_OnPlateRemoved() {
		Node3D plateVisualInstance = plateVisualInstancesList[plateVisualInstancesList.Count - 1];
		plateVisualInstancesList.Remove(plateVisualInstance);
		plateVisualInstance.QueueFree();
	}

}
