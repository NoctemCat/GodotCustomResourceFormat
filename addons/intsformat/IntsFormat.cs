#if TOOLS
using Godot;
using System;
namespace NoctemCat.TestLoader;

[Tool]
public partial class IntsFormat : EditorPlugin
{
	public override void _EnterTree()
	{
		AddAutoloadSingleton("IntsFormatAutoload", "res://addons/intsformat/RegisterAutoload.cs");
	}

	public override void _ExitTree()
	{
		RemoveAutoloadSingleton("IntsFormatAutoload");
	}
}
#endif
