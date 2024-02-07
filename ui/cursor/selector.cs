using Godot;

public partial class selector : ColorRect
{
	bool mouseDown = false;
	Vector2 startMousePositon;
	Vector2 endMousePosition;
	
	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustPressed("uc_leftMouseButtonClick")){
			if(!mouseDown){
				mouseDown = true;
				startMousePositon = GetGlobalMousePosition();
			}
			GlobalPosition = startMousePositon;
		}
		else if(Input.IsActionJustReleased("uc_leftMouseButtonClick")){
			if (mouseDown){
				mouseDown = false;
				endMousePosition = GetGlobalMousePosition();
				Size = Vector2.Zero;
			}
		}
		if (@event is InputEventMouseMotion){
			if (mouseDown){
				CreateSelectZone();
			}
		}
	}

	/// <summary>
	/// Метод создания зоны выделения.
	/// </summary>
	void CreateSelectZone(){
		Vector2 globalMousePos = GetGlobalMousePosition();
		float x = 1, y = 1;

		if(globalMousePos.X  < startMousePositon.X){
			x = -1;
		}
		else if(globalMousePos.X  > startMousePositon.X){
			x = 1;
		}
		if(globalMousePos.Y  < startMousePositon.Y){
			y = -1;
		}
		else if(globalMousePos.Y  > startMousePositon.Y){
			y = 1;
		}

		Scale = new Vector2(x, y);
		Size = (globalMousePos - startMousePositon)*Scale;
	}

	/* TODO:
	 1) Сделать метод, добавления "unit" в массив для их управления.
	 2) Очиста выделения.
	 3) Комбинации для динамического добавления.
	*/
	void addIntoArray(){}
}

