using System.Collections.Generic;
using Godot;
namespace NoctemCat.TestLoader;

[GlobalClass]
public partial class CustomData : Resource
{
    public List<int> Ints { get; set; } = [];

    [Export]
    public float[] Floats { get; set; } = [];

    public override string ToString()
    {
        return $"{string.Join(',', Ints)} | {string.Join(',', Floats)}";
    }
}