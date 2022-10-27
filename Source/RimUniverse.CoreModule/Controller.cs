using Mlie;
using UnityEngine;
using Verse;

namespace RimUniverse.CoreModule;

[StaticConstructorOnStartup]
public class Controller : Mod
{
    public static Settings Settings;
    public static string currentVersion;

    public Controller(ModContentPack content) : base(content)
    {
        Settings = GetSettings<Settings>();
        Log.Message("RimUniverse: Loaded successfully");
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(
                ModLister.GetActiveModWithIdentifier("Mlie.RimUniverseCoreModule"));
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        Settings.DoWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "RimUniverse".Translate();
    }
}