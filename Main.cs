using Godot;
using System;

public partial class Main : Node2D
{
	Label Scorelabel;
	int Score;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Score = 0;
		Scorelabel = GetNode<Label>("CanvasLayer/Score");
	}

	public void OnPlayerCoinCollected()
	{
		Score++;
		Scorelabel.Text = Score.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

}
