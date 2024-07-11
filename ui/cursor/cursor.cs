using Godot;

public partial class cursor : Node2D
{
	[Export] Sprite2D _sprite;

	public override void _Ready(){
		// Скрытие системного курсора
		DisplayServer.MouseSetMode(DisplayServer.MouseMode.Hidden);
		// Получение "Sprite" собственного курсора
		_sprite = GetNode<Sprite2D>("Sprite");
		Visible = true;
	}

	public override void _Input(InputEvent @event){
		base._Input(@event);

		// Анимация нажатия курсора
		if (Input.IsMouseButtonPressed(MouseButton.Left) || Input.IsMouseButtonPressed(MouseButton.Right)){
			_sprite.Frame = 1;
		}
		else{
			_sprite.Frame = 0;
		}
	}

	public override void _Process(double delta){
		// Присвоение позиции для собственного курсора
		Position = GetGlobalMousePosition();
	}
}
