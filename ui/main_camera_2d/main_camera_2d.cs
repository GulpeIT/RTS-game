using Godot;
using System;

public partial class main_camera_2d : Camera2D
{
	[Export] private float cameraSpeed = 1.2f;
	[Export] private float cameraEdge = 5f;
	
	[Export] private bool cameraCanMove = true;
	

	public override void _Process(double delta){
		//Позиция курсора на Viewport. || position cursor on Viewport.
		Vector2 localMousePosition = GetViewport().GetMousePosition();

		#region edge move
		if (cameraCanMove){
			//Передвижение влево || move to left
			if (localMousePosition.X <= cameraEdge || Input.IsActionPressed("uc_left")){
				Position -= new Vector2(cameraSpeed, 0);
			}
			//Передвижение в право || move to right
			if (localMousePosition.X >= GetViewportRect().Size.X - cameraEdge || Input.IsActionPressed("uc_right")){
				Position += new Vector2(cameraSpeed, 0);
			}
			//Передвижение в верх || move up
			if (localMousePosition.Y <= cameraEdge || Input.IsActionPressed("uc_up")){
				Position -= new Vector2(0, cameraSpeed);
			}
			//Передвижение вниз || move down
			if (localMousePosition.Y >= GetViewportRect().Size.Y - cameraEdge || Input.IsActionPressed("uc_down")){
				Position += new Vector2(0, cameraSpeed);
			}
		}
		#endregion
	}
	
}
