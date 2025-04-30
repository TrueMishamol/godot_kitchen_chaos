using Godot;
using System;

public partial class Interaction : Node {


	public event Action<BaseCounter> OnSelectedCounterChanged;

	private const string INTERACT = "interact";

	public Player Player { private get; set; }

	[Export] private RayCast3D _Raycast;

	private BaseCounter f_selectedCounter;
	private BaseCounter _selectedCounter {
		get => f_selectedCounter;
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
			_selectedCounter.Interact(Player);
		}
	}



	private void HandleInteractions() {
		if (_Raycast.GetCollider() is BaseCounter raycastHit) {
			if (raycastHit != _selectedCounter) {
				_selectedCounter = raycastHit;
			}
		} else {
			_selectedCounter = null;
		}
	}

}
