using System.Collections.Generic;
using Godot;
namespace NoctemCat.TestLoader;

[GlobalClass]
public partial class CustomData : Resource
{
    public List<int> Ints { get; set; }
}