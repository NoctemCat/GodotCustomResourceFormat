using Godot;
using System;
namespace NoctemCat.TestLoader;

public partial class Node2d : Node2D
{
	[Export]
	public CustomData Data;

	public override void _Ready()
	{
		var resource = ResourceLoader.Load<CustomData>("res://new_resource.ints");
		GD.PrintS("From load:", resource);
		resource.Ints = [737, 999, 300];
		ResourceSaver.Save(resource, "res://new_resource.ints");

		GD.PrintS("From export:", Data);
		Data.Ints = [1, 2, 9, 10];
		ResourceSaver.Save(Data, "res://new_resource_data.ints");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
