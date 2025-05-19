using Godot;
using System;

public partial class Interaction : Node {


	public event Action<BaseCounter> OnSelectedCounterChanged;

	public Player Player { private get; set; }

	[Export] private RayCast3D _Raycast;

	private BaseCounter b_selectedCounter;
	private BaseCounter _selectedCounter {
		get => b_selectedCounter;
		set {
			b_selectedCounter = value;
			OnSelectedCounterChanged?.Invoke(value);
		}
	}




	public override void _Ready() {
		GameInput.OnInteractPressed += GameInput_OnInteractPressed;
		GameInput.OnInteractAlternatePressed += GameInput_OnInteractAlternatePressed;
	}

	public override void _Process(double delta) {
		HandleInteractions();
	}



	private void GameInput_OnInteractPressed() {
		if (_selectedCounter != null) {
			_selectedCounter.Interact(Player);
		}
	}

	private void GameInput_OnInteractAlternatePressed() {
		if (_selectedCounter != null) {
			_selectedCounter.InteractAlternate(Player);
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
