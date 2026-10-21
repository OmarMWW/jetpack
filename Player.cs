using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Signal]
	public delegate void CoinCollectedEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override void _PhysicsProcess(double delta)
    {
        var mVelocity = Velocity;

		if (!IsOnFloor())
		{
			mVelocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionPressed("Jump"))
		{
			mVelocity.Y =- 400;
		}

		Velocity = mVelocity;
		MoveAndSlide();
    }


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnAreaEntered(Area2D area)
	{
		GD.Print(area.Name);
		if(area.Name =="Coin")
		{
			EmitSignal(SignalName.CoinCollected);
			area.QueueFree();
		}
	}
}
