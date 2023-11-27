using Godot;
using System;

public partial class Player : RigidBody3D
{
	[Export]
	private float speed = 0.6f;
	[Export]
	private bool player2 = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!player2)
		{
			if (Input.IsActionPressed("move_up1"))
			{
				this.MoveAndCollide(new Vector3(0, speed, 0));
			}
			if (Input.IsActionPressed("move_down1"))
			{
				this.MoveAndCollide(new Vector3(0, -speed, 0));
			}
		}
		else
		{
			if (Input.IsActionPressed("move_up2"))
			{
				this.MoveAndCollide(new Vector3(0, speed, 0));
			}
			if (Input.IsActionPressed("move_down2"))
			{
				this.MoveAndCollide(new Vector3(0, -speed, 0));
			}
		}
	}
}
