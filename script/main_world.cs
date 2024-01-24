using Godot;
using System;

public partial class main_world : Node2D
{
	public override void _Process(double delta)
	{
		//Закрытие проекта || close project # Переделать
		if (Input.IsActionJustPressed("ui_close")){
			GetTree().Quit();
		}

	}
}
