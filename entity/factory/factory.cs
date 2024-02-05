
using Godot;
using System;

public partial class factory : StaticBody2D
{
	[Export] public float income = 5f;
	[Export] public bool isTrunOn = false;

	[Export] private GpuParticles2D smoke;

	Sprite2D sprite;

	public override void _Ready() {}

	public override void _PhysicsProcess(double delta)
	{
		//Управление частицами дыма || Controle smoke particle
		smoke.Emitting = isTrunOn;
	}
}
