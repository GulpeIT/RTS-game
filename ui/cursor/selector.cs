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
		float x = 1;
		float y = 1;


		if(GetGlobalMousePosition().X  < startMousePositon.X){
			x = -1;
		}
		else if(GetGlobalMousePosition().X  > startMousePositon.X){
			x = 1;
		}
		if(GetGlobalMousePosition().Y  < startMousePositon.Y){
			y = -1;
		}
		else if(GetGlobalMousePosition().Y  > startMousePositon.Y){
			y = 1;
		}

		Scale = new Vector2(x, y);

		Size = (GetGlobalMousePosition() - startMousePositon)*Scale;
	}
}

