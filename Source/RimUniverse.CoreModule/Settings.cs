using UnityEngine;
using Verse;

namespace RimUniverse.CoreModule;

public class Settings : ModSettings
{
    public bool ShowModDesignators = true;

    // ReSharper disable once MemberCanBePrivate.Global
    public bool WaterResponsive = ModLister.OdysseyInstalled;

    public void DoWindowContents(Rect inRect)
    {
        var rect = inRect.width - 50f;
        var listingStandard = new Listing_Standard { ColumnWidth = rect };
        listingStandard.Begin(inRect);
        listingStandard.ButtonImage(Resources.SettingsHeader, 850f, 128f);
        listingStandard.GapLine();
        listingStandard.Gap(5f);
        GUI.color = Color.cyan;
        listingStandard.Label("Settings.CoreModule".Translate());
        GUI.color = Color.green;
        listingStandard.Label("Settings.Submods".Translate());
        listingStandard.Gap(5f);
        GUI.color = Color.white;
        listingStandard.CheckboxLabeled("ShowModDesignators".Translate(), ref ShowModDesignators,
            "ShowModDesignatorsTip".Translate());
        listingStandard.GapLine();
        listingStandard.Gap(10f);


        if (ModLister.GetActiveModWithIdentifier("Mlie.RimUniverseBiomes", true) != null && !ModLister.OdysseyInstalled)
        {
            GUI.color = Color.cyan;
            listingStandard.Label("Settings.BiomesModule".Translate());
            GUI.color = Color.green;
            listingStandard.Label("Settings.Submods".Translate());
            GUI.color = Color.white;
            listingStandard.CheckboxLabeled("WaterResponsive".Translate(), ref WaterResponsive,
                "WaterResponsiveTip".Translate());
            listingStandard.Gap(4f);
            listingStandard.GapLine();
        }
        else
        {
            WaterResponsive = false;
        }

        if (Controller.CurrentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("RimUniverse.Version".Translate(Controller.CurrentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref ShowModDesignators, "ShowModDesignators", true);
        Scribe_Values.Look(ref WaterResponsive, "WaterResponsive", true);
    }
}