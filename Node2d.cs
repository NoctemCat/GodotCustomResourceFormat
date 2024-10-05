using Godot;
using System;
namespace NoctemCat.TestLoader;

public partial class Node2d : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var resource = ResourceLoader.Load<CustomData>("res://new_resource.ints");
		GD.Print(string.Join(',', resource.Ints));
		resource.Ints = [777, 1000, 300];
		ResourceSaver.Save(resource, "res://new_resource.ints");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
