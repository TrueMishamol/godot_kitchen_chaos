using Godot;

public partial class StoveCounter : BaseCounter {


	[Export] private FryingRecipesListResource _FryingRecipesListResource;
	[Export] private Timer _Timer;

	// private float _fryingProgress;

	private FryingRecipeResource _currentFryingRecipeResource;




	public override void _Ready() {
		_Timer.Timeout += Timer_OnTimeout;
	}

	public override void _Process(double delta) {
		//! Display ProgressBar
	}

	private void Timer_OnTimeout() {
		//! Fried
		GD.Print("FRIED");

		_Timer.Stop();

		KitchenObject.DestroySelf();
		KitchenObject.SpawnKitchenObject(_currentFryingRecipeResource._Output, this);

		CheckKitchenObjectAndStartTimer();
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
			}
		}
	}



	private void CheckKitchenObjectAndStartTimer() {
		if (KitchenObject == null)
			return;
		if (HasRecipeWithInput(KitchenObject._KitchenObjectResource)) {
			_currentFryingRecipeResource = GetFryingRecipeResourceWithInput(KitchenObject._KitchenObjectResource);
			_Timer.WaitTime = _currentFryingRecipeResource._FryingTimerMax;
			_Timer.Start();
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
