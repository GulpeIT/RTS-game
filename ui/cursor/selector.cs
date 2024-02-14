using Godot;
using Godot.Collections;

public partial class selector : ColorRect
{
	bool _mouseDown = false;

	Vector2 _startMousePositon;
	Vector2 _endMousePosition;


	// TODO:
	// 1) Сделать выделение с помощью Rect2. 🟡
	Rect2 _selectRect = new Rect2();

	Array<Node> _nodesInRect = new Array<Node> {};

	public override void _UnhandledInput(InputEvent @event){
		base._UnhandledInput(@event);

		if (Input.IsActionJustPressed("uc_leftMouseButtonClick")){
			if(!_mouseDown){
				_mouseDown = true;
				//RemoveUnitInArray();

				_startMousePositon = GetGlobalMousePosition();
			}

			GlobalPosition = _startMousePositon;
		}

		else if(Input.IsActionJustReleased("uc_leftMouseButtonClick")){
			if (_mouseDown){
				_mouseDown = false;

				_endMousePosition = GetGlobalMousePosition();
				//AddUnitInArray();
			}
		}


		if (@event is InputEventMouseMotion){
			if (_mouseDown){
				//CreateSelectZone();
			}
		}
	}

	/*
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
		Size = (globalMousePos - _startMousePositon) * Scale;
	}

	
	void AddUnitInArray(){
		Array<Node> nodesToGet = GetTree().GetNodesInGroup("Selectable");

		Rect2 rect2 = GetGlobalRect();
		rect2.Size *= Scale;

		if (nodesToGet != null){
			foreach (test_worker_car node in nodesToGet){
				if (GetGlobalRect().HasPoint(node.GlobalPosition)){
					_nodesInRect.Add(node);
					node.Select();
				}
			}
		}
		GD.Print(_nodesInRect);
	}

	void RemoveUnitInArray(){
		foreach (test_worker_car node in _nodesInRect){
			node.UnSelect();
		}
		_nodesInRect.Clear();
	}
	*/
}

