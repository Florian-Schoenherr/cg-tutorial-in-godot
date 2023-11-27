using Godot;
using System;

public partial class Bricks : Node3D
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GetChildCount() == 0)
		{
			GD.Print("You won!");
		}
	}
}
