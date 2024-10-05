


using System.Globalization;
using System.Linq;
using Godot;
namespace NoctemCat.TestLoader;

[Tool]
public partial class ResourceFormatSaverInts : ResourceFormatSaver
{
    private static readonly Script ScriptResource = GD.Load<Script>("res://CustomData.cs");

    public override Error _Save(Resource resource, string path, uint flags)
    {
        if (resource is not CustomData data)
        {
            return Error.InvalidData;
        }

        string contentInts = string.Join(',', data.Ints);
        string contentFloats = string.Join(',', data.Floats.Select((num) => num.ToString(CultureInfo.InvariantCulture)));
        using var file = FileAccess.Open(path, FileAccess.ModeFlags.Write);
        file.StoreLine(contentInts);
        file.StoreLine(contentFloats);

        return Error.Ok;
    }

    public override bool _Recognize(Resource resource)
    {
        return resource.GetScript().Obj == ScriptResource;
    }

    public override string[] _GetRecognizedExtensions(Resource resource)
    {
        return ["ints"];
    }
}