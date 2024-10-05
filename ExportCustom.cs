using Godot;
using System;
namespace NoctemCat.TestLoader;

public partial class ExportCustom : Node
{
    [Export]
    public CustomData Data;

    public override void _Ready()
    {
        GD.PrintS("From export:", Data);
        Data.Ints = [1, 2, 9, 10];
        ResourceSaver.Save(Data, "res://new_resource_data.ints");
    }
}
