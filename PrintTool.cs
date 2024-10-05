using Godot;
using System;
namespace NoctemCat.TestLoader;

[Tool]
public partial class PrintTool : Node
{
    [Export]
    public int[] IntsToSave { get; set; } = [];
    [Export]
    public float[] FloatsToSave { get; set; } = [];

    [Export]
    public bool SaveResource
    {
        get => false;
        set
        {
            var resource = ResourceLoader.Load<CustomData>("res://new_resource.ints");
            resource.Ints = new(IntsToSave);
            resource.Floats = [.. FloatsToSave];
            ResourceSaver.Save(resource, "res://new_resource.ints");
        }
    }
    [Export]
    public bool LoadFromResource
    {
        get => false;
        set
        {
            var resource = ResourceLoader.Load<CustomData>("res://new_resource.ints");
            IntsToSave = [.. resource.Ints];
            FloatsToSave = [.. resource.Floats];
        }
    }
    [Export]
    public bool PrintResource
    {
        get => false;
        set
        {
            var resource = ResourceLoader.Load<CustomData>("res://new_resource.ints");
            GD.PrintS("From load:", resource);
        }
    }

}
