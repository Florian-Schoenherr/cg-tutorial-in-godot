using Godot;
using System;

public partial class Ball : CharacterBody3D
{
	[Export]
	private float speed = 20f;
	[Export]
	private float direction_x = -1f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Vector3 velocity = Velocity;
		velocity.X = (float) GD.RandRange(0.3, 0.5) * direction_x;
		velocity.Y = (float) GD.RandRange(-0.5, 0.5);
		Velocity = velocity;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var collision = this.MoveAndCollide(Velocity * speed * (float) delta);
		if (collision != null)
		{
			speed += 1;
			Velocity = Velocity.Bounce(collision.GetNormal());
			var collider = collision.GetCollider();
			var bricks = GetParent().GetNode("bricks");
			foreach (var child in bricks.GetChildren())
			{
				if (collider == child)
				{
					bricks.RemoveChild((Node) collider);
				}
			}
		}
	}

	private void _on_out_left_body_entered(Node3D body)
	{
		reset();
	}

	private void _on_out_right_body_entered(Node3D body)
	{
		reset();
	}

	private void reset()
	{
		GetParent().QueueFree();
		var child = GD.Load("res://game_area.tscn") as PackedScene;
		GetParent().GetParent().AddChild(child.Instantiate());
	}
}
