extends RigidBody3D

@export var player2 = false
@export var speed = 0.6

func _process(delta):
	# TODO: dedup Vector stuff maybe
	if !player2:
		if Input.is_action_pressed("move_up1"):
			self.move_and_collide(Vector3(0, speed, 0))
		if Input.is_action_pressed("move_down1"):
			self.move_and_collide(Vector3(0, -speed, 0))
	else:
		if Input.is_action_pressed("move_up2"):
			self.move_and_collide(Vector3(0, speed, 0))
		if Input.is_action_pressed("move_down2"):
			self.move_and_collide(Vector3(0, -speed, 0))
