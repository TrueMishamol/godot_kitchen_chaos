using Godot;
using System;

public partial class StoveCounter : BaseCounter, IHasProgress {

	// IHasProgress
	public event Action<float> OnProgressChanged;

	public event Action<State> OnStateChanged;

	public enum State {
		Idle,
		Frying,
		Burning,
	}

	[Export] private FryingRecipesListResource _FryingRecipesListResource;
	[Export] private Timer _Timer;

	private State b_currentState;
	private State _currentState {
		get => b_currentState;
		set {
			b_currentState = value;
			// GD.Print(value);
			OnStateChanged?.Invoke(value);
		}
	}
	private FryingRecipeResource _currentFryingRecipeResource;




	public override void _Ready() {
		_currentState = State.Idle;

		_Timer.Timeout += Timer_OnTimeout;
	}

	public override void _Process(double delta) {
		float progress = 1f - (float)(_Timer.TimeLeft / _Timer.WaitTime);
		OnProgressChanged?.Invoke(progress);
	}

	private void Timer_OnTimeout() {
		OnFried();
	}




	public override void Interact(Player player) {
		if (KitchenObject == null) {
			// Counter EMPTY
			if (player.KitchenObject != null) {
				// Player HAS object
				if (HasRecipeWithInput(player.KitchenObject._KitchenObjectResource)) {
					// Object has recipe
					//# Player drops the object
					player.KitchenObject.KitchenObjectParent = this;

					CheckKitchenObjectAndStartTimer();
				}
			}
		} else {
			// Counter HAS object
			if (player.KitchenObject == null) {
				// Player EMPTY-handed
				//# Player grabs the object
				KitchenObject.KitchenObjectParent = player;

				CheckKitchenObjectAndStartTimer();
			} else {
				// Player HAS object
				if (player.KitchenObject.TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
					// Player is holding a Plate
					//# Plate
					if (plateKitchenObject.TryAddIngredient(KitchenObject._KitchenObjectResource)) {
						KitchenObject.DestroySelf();
						CheckKitchenObjectAndStartTimer();
					}
				}
			}
		}
	}




	private void OnFried() {
		// GD.Print("FRIED " + KitchenObject);
		KitchenObject.DestroySelf();
		KitchenObject.SpawnKitchenObject(_currentFryingRecipeResource._Output, this);

		CheckKitchenObjectAndStartTimer();
	}

	private void CheckKitchenObjectAndStartTimer() {
		if (KitchenObject == null) {
			//# No object
			_Timer.Stop();
			_currentState = State.Idle;
			return;
		}
		if (HasRecipeWithInput(KitchenObject._KitchenObjectResource)) {
			//# Has recipe
			_currentFryingRecipeResource = GetFryingRecipeResourceWithInput(KitchenObject._KitchenObjectResource);
			_Timer.WaitTime = _currentFryingRecipeResource._FryingTimerMax;
			_Timer.Start();

			if (_currentFryingRecipeResource._IsBurning) {
				_currentState = State.Burning;
			} else {
				_currentState = State.Frying;
			}
		} else {
			//# No recipe
			_Timer.Stop();
			_currentState = State.Idle;
		}
	}





	private bool HasRecipeWithInput(KitchenObjectResource input) {
		return GetFryingRecipeResourceWithInput(input) != null;
	}

	private KitchenObjectResource GetOutputForInput(KitchenObjectResource input) {
		FryingRecipeResource recipe = GetFryingRecipeResourceWithInput(input);
		if (recipe != null)
			return recipe._Output;
		else
			return null;
	}

	private FryingRecipeResource GetFryingRecipeResourceWithInput(KitchenObjectResource input) {
		foreach (FryingRecipeResource recipe in _FryingRecipesListResource._FryingRecipeResources) {
			if (recipe._Input == input) {
				return recipe;
			}
		}
		return null;
	}
}
