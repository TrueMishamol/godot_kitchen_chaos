using Godot;
using System;
using System.Collections.Generic;

public partial class DeliveryManager : Node {


	public event Action OnRecipeSpawned;
	public event Action OnRecipeCompleted;
	public event Action OnRecipeSuccess;
	public event Action OnRecipeFailed;

	public static DeliveryManager Instance { get; private set; }

	public int SuccessfullRecipesAmount { get; private set; } = 0;

	[Export] private RecipesListResource _RecipesListResource;
	[Export] private Timer _SpawnRecipeTimer;

	public List<RecipeResource> WaitingRecipeResourcesList { get; private set; } = new List<RecipeResource>();
	private int _waitingRecipesMax = 4;
	private RandomNumberGenerator _randomNumberGenerator = new RandomNumberGenerator();



	public override void _EnterTree() {
		Instance = this;
	}

	public override void _Ready() {
		_SpawnRecipeTimer.Timeout += SpawnRecipeTimer_OnTimeout;
	}

	private void SpawnRecipeTimer_OnTimeout() {
		if (WaitingRecipeResourcesList.Count < _waitingRecipesMax) {
			int randomIndex = _randomNumberGenerator.RandiRange(0, _RecipesListResource._Recipes.Length - 1);
			RecipeResource waitingRecipeResource = _RecipesListResource._Recipes[randomIndex];
			WaitingRecipeResourcesList.Add(waitingRecipeResource);

			OnRecipeSpawned?.Invoke();

			// GD.Print("Recipe " + randomIndex + " " + waitingRecipeResource._Name);
		}
	}

	public void DeliverRecipe(PlateKitchenObject plateKitchenObject) {
		foreach (RecipeResource waitingRecipeResource in _RecipesListResource._Recipes) {
			// GD.Print(waitingRecipeResource + " " + waitingRecipeResource._Name);

			if (waitingRecipeResource._KitchenObjectResourcesList.Length == plateKitchenObject.KitchenObjectResourcesList.Count) {
				// Has the same NUMBER of ingredients
				bool isPlateContentMatchesRecipe = true;
				foreach (KitchenObjectResource recipeKitchenObjectResource in waitingRecipeResource._KitchenObjectResourcesList) {
					// Cycling through all ingredients in the RECIPE
					bool isIngredientFound = false;
					foreach (KitchenObjectResource plateKitchenObjectResource in plateKitchenObject.KitchenObjectResourcesList) {
						// Cycling through all ingredients on the PLATE
						if (plateKitchenObjectResource == recipeKitchenObjectResource) {
							//# Ingredient matches!
							isIngredientFound = true;
							break;
						}
					}
					if (!isIngredientFound) {
						//This Recipe ingredient was not found on the Plate
						isPlateContentMatchesRecipe = false;
					}
				}
				if (isPlateContentMatchesRecipe) {
					//# Player delivered the correct recipe!
					// GD.Print("Player delivered the correct recipe!");

					WaitingRecipeResourcesList.Remove(waitingRecipeResource);
					SuccessfullRecipesAmount++;
					OnRecipeCompleted?.Invoke();
					OnRecipeSuccess?.Invoke();

					return;
				}
			}
		}

		//# No matches found!
		// Player did NOT deliver a correct recipe!
		// GD.Print("Player did NOT deliver a correct recipe!");

		OnRecipeFailed?.Invoke();
	}
}
