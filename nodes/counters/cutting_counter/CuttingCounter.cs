using Godot;
using System;

public partial class CuttingCounter : BaseCounter, IHasProgress {

	// IHasProgress
	public event Action<float> OnProgressChanged;
	public event Action OnCut;

	[Export] public CuttingRecipesListResource _CuttingRecipesListResource;

	private int _cuttingProgress;



	public override void Interact(Player player) {
		if (KitchenObject == null) {
			// Counter EMPTY
			if (player.KitchenObject != null) {
				// Player HAS object
				if (HasRecipeWithInput(player.KitchenObject._KitchenObjectResource)) {
					// Object has recipe
					//# Player drops the object
					player.KitchenObject.KitchenObjectParent = this;
					_cuttingProgress = 0;

					CuttingRecipeResource cuttingRecipeResource = GetCuttingRecipeResourceWithInput(KitchenObject._KitchenObjectResource);
					OnProgressChanged?.Invoke((float)_cuttingProgress / cuttingRecipeResource._CuttingProgressMax);
				}
			}
		} else {
			// Counter HAS object
			if (player.KitchenObject == null) {
				// Player EMPTY-handed
				//# Player grabs the object
				KitchenObject.KitchenObjectParent = player;
			} else {
				// Player HAS object
				if (player.KitchenObject.TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
					// Player is holding a Plate
					//# Plate
					if (plateKitchenObject.TryAddIngredient(KitchenObject._KitchenObjectResource)) {
						KitchenObject.DestroySelf();
					}
				}
			}
		}
	}

	public override void InteractAlternate(Player player) {
		if (KitchenObject != null && HasRecipeWithInput(KitchenObject._KitchenObjectResource)) {
			_cuttingProgress++;

			CuttingRecipeResource cuttingRecipeResource = GetCuttingRecipeResourceWithInput(KitchenObject._KitchenObjectResource);

			OnProgressChanged?.Invoke((float)_cuttingProgress / cuttingRecipeResource._CuttingProgressMax);
			OnCut?.Invoke();
			
			if (_cuttingProgress >= cuttingRecipeResource._CuttingProgressMax) {
				KitchenObjectResource outputKitchenObjectResource = GetOutputForInput(KitchenObject._KitchenObjectResource);
				// if (outputKitchenObjectResource == null)
				// 	return;

				KitchenObject.DestroySelf();
				KitchenObject.SpawnKitchenObject(outputKitchenObjectResource, this);
			}
		}
	}

	private bool HasRecipeWithInput(KitchenObjectResource input) {
		return GetCuttingRecipeResourceWithInput(input) != null;
	}

	private KitchenObjectResource GetOutputForInput(KitchenObjectResource input) {
		CuttingRecipeResource recipe = GetCuttingRecipeResourceWithInput(input);
		if (recipe != null)
			return recipe._Output;
		else
			return null;
	}

	private CuttingRecipeResource GetCuttingRecipeResourceWithInput(KitchenObjectResource input) {
		foreach (CuttingRecipeResource recipe in _CuttingRecipesListResource._CuttingRecipeResources) {
			if (recipe._Input == input) {
				return recipe;
			}
		}
		return null;
	}
}
