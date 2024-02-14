class_name ClearCounter 
extends StaticBody3D


@export var kitchen_object_parent: KitchenObjectParent
@export var _counter_top_point: Node3D


@export var _kitchen_object_res: KitchenObjectRes

@export var _second_clear_counter: ClearCounter
@export var _testing: bool = false
	

func _input(event: InputEvent) -> void:
	if _testing && event.is_action_pressed("test"):
		print("test")
		if kitchen_object_parent.kitchen_object != null:
			kitchen_object_parent.kitchen_object.set_kitchen_object_parent(_second_clear_counter.kitchen_object_parent)


func interact(new_kitchen_object_parent: KitchenObjectParent):
	if kitchen_object_parent.kitchen_object == null:
		var kitchen_object_instance: KitchenObject = load(_kitchen_object_res.node).instantiate()
		_counter_top_point.add_child(kitchen_object_instance)
		
		kitchen_object_instance.set_kitchen_object_parent(kitchen_object_parent)
	else:
		kitchen_object_parent.kitchen_object.set_kitchen_object_parent(new_kitchen_object_parent)


func get_counter_top_point() -> Node3D:
	return _counter_top_point


func set_kitchen_object(kitchen_object: KitchenObject):
	kitchen_object_parent.kitchen_object = kitchen_object
	

func get_kitchen_object() -> KitchenObject:
	return kitchen_object_parent.kitchen_object
	
	
func clear_kitchen_object():
	kitchen_object_parent.kitchen_object = null
	
	
func has_kitchen_object() -> bool:
	return kitchen_object_parent.kitchen_object != null
