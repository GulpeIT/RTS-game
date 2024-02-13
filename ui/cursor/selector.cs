using Godot;
using Godot.Collections;

public partial class selector : ColorRect
{
	bool _mouseDown = false;
	Vector2 _startMousePositon;
	Vector2 _endMousePosition;
	Array<Node> _nodesInRect = new Array<Node> {};
	
	public override void _Input(InputEvent @event)
	{
		if (Input.IsActionJustPressed("uc_leftMouseButtonClick")){
			if(!_mouseDown){
				_mouseDown = true;
				RemoveUnitInArray();
				_startMousePositon = GetGlobalMousePosition();
			}
			GlobalPosition = _startMousePositon;
		}
		else if(Input.IsActionJustReleased("uc_leftMouseButtonClick")){
			if (_mouseDown){
				_mouseDown = false;
				_endMousePosition = GetGlobalMousePosition();
				AddUnitInArray();
				Size = Vector2.Zero;
			}
		}
		if (@event is InputEventMouseMotion){
			if (_mouseDown){
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

		if(globalMousePos.X  < _startMousePositon.X){
			x = -1;
		}
		else if(globalMousePos.X  > _startMousePositon.X){
			x = 1;
		}
		if(globalMousePos.Y  < _startMousePositon.Y){
			y = -1;
		}
		else if(globalMousePos.Y  > _startMousePositon.Y){
			y = 1;
		}

		Scale = new Vector2(x, y);
		Size = (globalMousePos - _startMousePositon)*Scale;
	}

	/* TODO:
	 1) Сделать метод, добавления "unit" в массив для их управления. ✅
	 2) Очиста выделения. ✅
	 3) Комбинации для динамического добавления.
	*/
	void AddUnitInArray(){
		Array<Node> nodesToGet = GetTree().GetNodesInGroup("Selectable");

		if (nodesToGet != null){
			GD.Print("GetNodesType Success");
			foreach (test_worker_car node in nodesToGet){
				if (GetGlobalRect().HasPoint(node.GlobalPosition)){
					_nodesInRect.Add(node);
					node.Select();
				}

				GD.Print("this node " + node);
				GD.Print("Node pos: " + node.GlobalPosition + " Rect: " + GetGlobalRect());
				GD.Print("Node has point?: " + GetGlobalRect().HasPoint(node.GlobalPosition));
			}
		}

		GD.Print(_nodesInRect);
	}

	void RemoveUnitInArray(){
		foreach (test_worker_car node in _nodesInRect){
			node.UnSelect();
		}
		_nodesInRect.Clear();
		GD.Print("Array clear");
	}
}

