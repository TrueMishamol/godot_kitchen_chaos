using System;
using Godot;

public partial class PlatesCounter : BaseCounter {


	public event Action OnPlateSpawned;
	public event Action OnPlateRemoved;

	[Export] private KitchenObjectResource _PlateKitchenObjectResource;
	[Export] private Timer _Timer;

	private float _spawnPlateTime = 4f;
	private int _platesSpawnedAmountMax = 4;
	private int _platesSpawnedAmount;



	public override void _Ready() {
		_Timer.Timeout += Timer_OnTimeout;
		_Timer.WaitTime = _spawnPlateTime;
		_Timer.Start();
	}

	private void Timer_OnTimeout() {
		//! Spawn Plate

		_platesSpawnedAmount++;
		OnPlateSpawned?.Invoke();

		CheckPlatesAndStartTimer();
	}

	private void CheckPlatesAndStartTimer() {
		if (_platesSpawnedAmount < _platesSpawnedAmountMax) {
			_Timer.Start();
		} else {
			_Timer.Stop();
		}
	}




	public override void Interact(Player player) {
		CheckPlatesAndStartTimer();




		if (_platesSpawnedAmount > 0) {
			// Counter HAS plates
			if (player.KitchenObject != null) {
				// Player HAS object
				//# Player grabs the plate with object
				//! _platesSpawnedAmount--;
				//! OnPlateRemoved?.Invoke();
				// player.KitchenObject.KitchenObjectParent = this;
			} else {
				// Player EMPTY-handed
				//# Player grabs the plate
				_platesSpawnedAmount--;
				OnPlateRemoved?.Invoke();

				KitchenObject.SpawnKitchenObject(_PlateKitchenObjectResource, player);
			}
		}
	}
}
