class_name ClearCounter 
extends StaticBody3D


@export var _kitchen_object_res: KitchenObjectRes
@export var _counter_top_point: Node3D

@export var _second_clear_counter: ClearCounter
@export var _testing: bool = false

var _kitchen_object: KitchenObject


func _input(event: InputEvent) -> void:
	if _testing && event.is_action_pressed("test"):
		print("test")
		if _kitchen_object != null:
			_kitchen_object.set_clear_counter(_second_clear_counter)


func interact(player: Player):
	if _kitchen_object == null:
		var kitchen_object_instance = load(_kitchen_object_res.node).instantiate()
		_counter_top_point.add_child(kitchen_object_instance)
		
		kitchen_object_instance.set_clear_counter(self)
	else:
		_kitchen_object.set_clear_counter(player)
		print(_kitchen_object.get_clear_counter())


func get_counter_top_point() -> Node3D:
	return _counter_top_point


func set_kitchen_object(kitchen_object: KitchenObject):
	_kitchen_object = kitchen_object
	

func get_kitchen_object() -> KitchenObject:
	return _kitchen_object
	
	
func clear_kitchen_object():
	_kitchen_object = null
	
	
func has_kitchen_object() -> bool:
	return _kitchen_object != null
