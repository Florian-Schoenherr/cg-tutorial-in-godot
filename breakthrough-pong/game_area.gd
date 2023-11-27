extends Node3D

@onready var bricks: PackedScene = preload("res://bricks.tscn")

func _ready():
	var bricks_instance = bricks.instantiate()
	bricks_instance.set_position(Vector3.ZERO)
	add_child(bricks_instance)
