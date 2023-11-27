extends CharacterBody3D

@export var direction_x: float

var speed = 20

func _ready():
	# maybe only randomize direction instead
	velocity.x = randf_range(0.3, 0.5) * direction_x
	velocity.y = randf_range(-0.5, 0.5)

func _process(delta):
	var collision = self.move_and_collide(velocity * speed * delta)
	if collision:
		speed += 1
		velocity = velocity.bounce(collision.get_normal())
		var collider = collision.get_collider()
		var bricks = get_parent().get_node("bricks")
		for child in bricks.get_children():
			if collider == child:
				bricks.remove_child(collider)

func _on_out_left_body_entered(body):
	reset()

func _on_out_right_body_entered(body):
	reset()

func reset():
	get_parent().queue_free()
	get_parent().get_parent().add_child(load("res://game_area.tscn").instantiate())
	# we could instead just reset the position
	# position = Vector3(0,8,0)
