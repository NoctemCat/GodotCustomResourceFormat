

using Godot;
namespace NoctemCat.TestLoader;

[Tool]
public partial class RegisterAutoload : Node
{
    static ResourceFormatLoaderInts formatLoaderInts;
    static ResourceFormatSaverInts formatSaverInts;
    public override void _EnterTree()
    {
        formatLoaderInts = new();
        ResourceLoader.AddResourceFormatLoader(formatLoaderInts);
        formatSaverInts = new();
        ResourceSaver.AddResourceFormatSaver(formatSaverInts);
    }

    public override void _ExitTree()
    {
        ResourceLoader.RemoveResourceFormatLoader(formatLoaderInts);
        formatLoaderInts.Dispose();
        ResourceSaver.RemoveResourceFormatSaver(formatSaverInts);
        formatSaverInts.Dispose();
    }
}