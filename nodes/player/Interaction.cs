using Godot;
using System;

public partial class Interaction : Node {


	public event Action<ClearCounter> OnSelectedCounterChanged;

	private const string INTERACT = "interact";

	// public Player Player { private get; set; }

	[Export] private RayCast3D _Raycast;

	private ClearCounter f_selectedCounter;
	private ClearCounter _selectedCounter {
		get {
			return f_selectedCounter;
		}
		set {
			f_selectedCounter = value;
			OnSelectedCounterChanged?.Invoke(value);
		}
	}




	public override void _EnterTree() {
		GameInput.OnInteractPressed += GameInput_OnInteractPressed;
	}

	public override void _Process(double delta) {
		HandleInteractions();
	}



	private void GameInput_OnInteractPressed() {
		if (_selectedCounter != null) {
			_selectedCounter.Interact();
		}
	}



	private void HandleInteractions() {
		if (_Raycast.GetCollider() is ClearCounter raycastHit) {
			if (raycastHit != _selectedCounter) {
				_selectedCounter = raycastHit;
			}
		} else {
			_selectedCounter = null;
		}
	}

}
