class_name ClearCounter 
extends StaticBody3D


@export var _kitchen_object_parent: KitchenObjectParent
@export var _kitchen_object_res: KitchenObjectRes


func interact(new_kitchen_object_parent: KitchenObjectParent):
	if !_kitchen_object_parent.has_kitchen_object():
		var kitchen_object_instance: KitchenObject = load(_kitchen_object_res.node).instantiate()
		_kitchen_object_parent.add_child(kitchen_object_instance)
		
		kitchen_object_instance.set_kitchen_object_parent(_kitchen_object_parent)
	else:
		_kitchen_object_parent.get_kitchen_object().set_kitchen_object_parent(new_kitchen_object_parent)


func get_kitchen_object_parent() -> Node3D:
	return _kitchen_object_parent