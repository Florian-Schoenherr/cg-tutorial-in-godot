using Godot;
using System;

public partial class GameArea : Node3D
{
	// [Export]
	private PackedScene bricks = GD.Load("res://bricks.tscn") as PackedScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var bricks_instance = bricks.Instantiate();
		AddChild(bricks_instance);
	}
}
