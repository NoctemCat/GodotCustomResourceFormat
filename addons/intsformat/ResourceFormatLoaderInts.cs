

using System;
using System.Globalization;
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
        string contentInts = file.GetLine();
        string[] numsInts = contentInts.Split(',').Where((num) => !string.IsNullOrWhiteSpace(num)).ToArray();
        string contentFloats = file.GetLine();
        string[] numsFloats = contentFloats.Split(',').Where((num) => !string.IsNullOrWhiteSpace(num)).ToArray();

        var res = new CustomData
        {
            Ints = new(numsInts.Length > 0 ? numsInts.Select((num) => int.Parse(num)) : []),
            Floats = numsFloats.Length > 0 ? numsFloats.Select((num) => float.Parse(num, CultureInfo.InvariantCulture)).ToArray() : []
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


