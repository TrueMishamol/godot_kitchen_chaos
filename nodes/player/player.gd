class_name Player
extends CharacterBody3D


@export var _raycast: RayCast3D
@export var _kitchen_object_parent: KitchenObjectParent

const MAX_SPEED = 7
const ACCELERATION = 30
const FRICTION = 30
const ROTATION_ACCELERATION = 10

signal on_selected_counter_changed(selected_counter: ClearCounter)

var _is_walking: bool = true
var _selected_counter: ClearCounter;


func _init():
	Singleton.player = self


func  _physics_process(delta):
	_handle_movement(delta)
	_handle_interactions()


func  _handle_movement(delta):
	var input_direction = Input.get_vector("left", "right", "up", "down").normalized()
	var output_velocity: Vector2 = Vector2(velocity.x, velocity.z)
	
	if input_direction == Vector2.ZERO:
		#^ Slows
		if output_velocity.length() > (FRICTION * delta):
			output_velocity -= output_velocity.normalized() * (FRICTION * delta)
		else:
			output_velocity = Vector2.ZERO
	else:
		#^ Speeds
		output_velocity += (input_direction * ACCELERATION * delta)
		output_velocity = output_velocity.limit_length(MAX_SPEED)
		
	velocity = Vector3(output_velocity.x, 0, output_velocity.y)
	move_and_slide()
	
	#^ Rotate
	if input_direction != Vector2.ZERO:
		rotation.y = lerp_angle(rotation.y, atan2(input_direction.x * 100, input_direction.y * 100), delta * ROTATION_ACCELERATION)

	_is_walking = output_velocity != Vector2.ZERO


func is_walking() -> bool:
	return _is_walking


func _handle_interactions():
	var collider: ClearCounter = _raycast.get_collider() as ClearCounter
	
	if collider != null:
		if collider != _selected_counter:
			_set_selected_counter(collider)
		if Input.is_action_just_pressed("interact"):
			#! Give _kitchen_object_parent
			collider.interact(_kitchen_object_parent)
	else:
		if _selected_counter != null:
			_set_selected_counter(null)


func _set_selected_counter(counter):
	_selected_counter = counter
	on_selected_counter_changed.emit(_selected_counter)
