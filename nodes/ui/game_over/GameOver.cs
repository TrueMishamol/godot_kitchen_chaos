using Godot;

public partial class GameOver : Control {



	[Export] private Label _RecipesDeliveredCountLabel;



	public override void _Ready() {
		GameStates.Instance.OnStateChanged += GameStates_OnStateChanged;

		Hide();
	}

	private void GameStates_OnStateChanged() {
		if (GameStates.Instance.IsGameOver) {
			_RecipesDeliveredCountLabel.Text = DeliveryManager.Instance.SuccessfullRecipesAmount.ToString();
			Show();
		} else {
			Hide();
		}
	}

}
