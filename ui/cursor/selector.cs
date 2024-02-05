using Godot;

public partial class selector : ColorRect
{
	bool mouseDown = false;
	Vector2 startMousePositon;
	Vector2 endMousePosition;

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (Input.IsActionJustPressed("uc_leftButtonClick")){
			if(!mouseDown){
				mouseDown = true;
				startMousePositon = GetGlobalMousePosition();
			}
			GlobalPosition = startMousePositon;


		}
		else if(Input.IsActionJustReleased("uc_leftButtonClick")){
			if (mouseDown){
				mouseDown = false;
				endMousePosition = GetGlobalMousePosition();
				Size = Vector2.Zero;
			}
		}

		if (@event is InputEventMouseMotion){
			if (mouseDown){
				_update();
			}
		}
	}

	void _update(){
		/*
		if(GetGlobalMousePosition().X  < startMousePositon.X){
			Scale.X = 1;
		}
		else if(GetGlobalMousePosition().X  > startMousePositon.X){
			Scale = new Vector2(1, 1);
		}
		if(GetGlobalMousePosition().Y  < startMousePositon.Y){
			Scale = new Vector2(1, -1);
		}
		else if(GetGlobalMousePosition().Y  > startMousePositon.Y){
			Scale = new Vector2(1, 1);
		}*/

		Size = (GetGlobalMousePosition() - startMousePositon)*Scale;
	}
}

