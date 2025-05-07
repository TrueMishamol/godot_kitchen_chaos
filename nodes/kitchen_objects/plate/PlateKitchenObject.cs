using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class PlateKitchenObject : KitchenObject {


	public event Action<KitchenObjectResource> OnIngredientAdded;

	[Export] private KitchenObjectsListResource _ValidKitchenObjects;

	private List<KitchenObjectResource> kitchenObjectResourcesList = new List<KitchenObjectResource>();



	public bool TryAddIngredient(KitchenObjectResource kitchenObjectResource) {
		if (!_ValidKitchenObjects._KitchenObjectResources.Contains(kitchenObjectResource)) {
			// Not a valid ingredient
			return false;
		}

		if (kitchenObjectResourcesList.Contains(kitchenObjectResource)) {
			// Already has this type
			return false;
		}

		OnIngredientAdded?.Invoke(kitchenObjectResource);
		kitchenObjectResourcesList.Add(kitchenObjectResource);
		return true;
	}

}
