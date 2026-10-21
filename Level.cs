using Godot;
using System;

public partial class Level : Node2D
{
	Marker2D SpawnPoint;

	[Export]
	PackedScene LevelPackedScene {get; set;}
	[Signal]
	public delegate void ScoreEventHandler();


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SpawnPoint = GetNode<Marker2D>("LevelSpawnPoint");
	}

    public override void _PhysicsProcess(double delta)
    {
        var mPosition = Position;
		mPosition.X += -200 * (float)delta;

		Position = mPosition;
    }

	public void _on_area_2d_body_entered(Node2D body)
	{
		if (body is Player)
		{
			EmitSignal(SignalName.Score);
		}
	}



	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
 
	public void OnSpawnTimer()
    {
        GD.Print("Spawn LEVEL");
        var Level = LevelPackedScene.Instantiate<Level>();
        Vector2 mPosition = SpawnPoint.Position;
        Random rand = new Random();
        int offset = (rand.Next(20) -10) * 20;
        mPosition.Y += offset;
        Level.Position = mPosition;
       
 
        AddChild(Level);
 
    }


}
