using Godot;
using System;

public partial class main_world : Node2D
{

	public override void _Process(double delta){
		if (Input.IsActionJustPressed("ui_close")){
			GetTree().Quit();
		}
	}
}

