class_name CameraFollow
extends Node


@export var camera: Camera3D
@export var target: Node3D

@export var _distance = 21.0
@export var _height = 21.0
@export var _lerp_weight = 0.04


func _ready() -> void:
	if !camera:
		camera = get_parent()
		

func _physics_process(_delta: float) -> void:
	if !target: return
	
	var target_position = target.global_transform.origin
	var offset: Vector3 = Vector3(0, _height, _distance)
	camera.global_transform.origin = camera.global_transform.origin.lerp(offset + target_position, _lerp_weight)
	
	camera.look_at(target_position)
