using Godot;

public partial class player_builder : Node2D
{
	private Vector2 _worldCell = new Vector2(16, 16);

	[Export] public float _maxDistant = 16f;
	[Export] public bool _buildMode = true;


	public override void _Process(double delta){
		Visible = _buildMode;
		MoveByCell();
	}

    private void MoveByCell(){
		Vector2 mousePosition = Position.DirectionTo(GetGlobalMousePosition()).Round();
		if (Position.DistanceTo(GetGlobalMousePosition()) > _maxDistant){
			Position += _worldCell * mousePosition;
		}
	}
}
