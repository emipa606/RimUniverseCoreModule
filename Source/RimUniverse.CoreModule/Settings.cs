using UnityEngine;
using Verse;

namespace RimUniverse.CoreModule;

public class Settings : ModSettings
{
    public bool showModDesignators = true;
    public bool waterResponsive = true;

    public void DoWindowContents(Rect inRect)
    {
        var rect = inRect.width - 50f;
        var listing_Standard = new Listing_Standard { ColumnWidth = rect };
        listing_Standard.Begin(inRect);
        listing_Standard.ButtonImage(Resources.SettingsHeader, 850f, 128f);
        listing_Standard.GapLine();
        listing_Standard.Gap(5f);
        GUI.color = Color.cyan;
        listing_Standard.Label("Settings.CoreModule".Translate());
        GUI.color = Color.green;
        listing_Standard.Label("Settings.Submods".Translate());
        listing_Standard.Gap(5f);
        GUI.color = Color.white;
        listing_Standard.CheckboxLabeled("ShowModDesignators".Translate(), ref showModDesignators,
            "ShowModDesignatorsTip".Translate());
        listing_Standard.GapLine();
        listing_Standard.Gap(10f);


        if (ModLister.GetActiveModWithIdentifier("Mlie.RimUniverseBiomes") != null)
        {
            GUI.color = Color.cyan;
            listing_Standard.Label("Settings.BiomesModule".Translate());
            GUI.color = Color.green;
            listing_Standard.Label("Settings.Submods".Translate());
            GUI.color = Color.white;
            listing_Standard.CheckboxLabeled("WaterResponsive".Translate(), ref waterResponsive,
                "WaterResponsiveTip".Translate());
            listing_Standard.Gap(4f);
            listing_Standard.GapLine();
        }

        if (Controller.currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("RimUniverse.Version".Translate(Controller.currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref showModDesignators, "ShowModDesignators", true);
        Scribe_Values.Look(ref waterResponsive, "WaterResponsive", true);
    }
}