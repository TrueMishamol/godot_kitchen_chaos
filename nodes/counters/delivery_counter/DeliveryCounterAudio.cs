using Godot;

public partial class DeliveryCounterAudio : BaseCounterAudio {


	[Export] private AudioStream _SfxDeliveryFail;
	[Export] private AudioStream _SfxDeliverySuccess;



	public override void _Ready() {
		// base._Ready();

		DeliveryManager.Instance.OnRecipeSuccess += () => {
			Stream = _SfxDeliverySuccess;
			Play();
		};

		DeliveryManager.Instance.OnRecipeFailed += () => {
			Stream = _SfxDeliveryFail;
			Play();
		};
	}


}
