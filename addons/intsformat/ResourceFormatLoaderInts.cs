

using System;
using System.Linq;
using Godot;
namespace NoctemCat.TestLoader;

[Tool]
public partial class ResourceFormatLoaderInts : ResourceFormatLoader
{
    public override Variant _Load(string path, string originalPath, bool useSubThreads, int cacheMode)
    {
        if (!FileAccess.FileExists(path))
        {
            GD.PrintErr($"File does not exist: {path}");
            return (long)Error.DoesNotExist;
        }

        using var file = FileAccess.Open(path, FileAccess.ModeFlags.Read);
        string content = file.GetAsText();
        string[] nums = content.Split(',');

        var res = new CustomData
        {
            Ints = new(nums.Select((num) => int.Parse(num)))
        };
        return res;
    }

    public override string[] _GetRecognizedExtensions()
    {
        return ["ints"];
    }

    public override string _GetResourceType(string path)
    {
        if (path.EndsWith(".ints", StringComparison.OrdinalIgnoreCase))
        {
            return "Resource";
        }
        return "";
    }
}


