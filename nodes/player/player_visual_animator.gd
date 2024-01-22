extends Node3D

const IDLE = "parameters/conditions/idle"
const WALKING = "parameters/conditions/is_walking"

@onready var _animation_tree = $AnimationTree
@export var _player: CharacterBody3D

func _process(_delta):
	update_animation_parameters()

func update_animation_parameters():
	_set_is_walking(_player.is_walking())
	
func _set_is_walking(is_walking: bool):
	_animation_tree[IDLE] = !is_walking
	_animation_tree[WALKING] = is_walking
