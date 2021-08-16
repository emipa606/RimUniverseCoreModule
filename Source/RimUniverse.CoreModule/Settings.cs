using UnityEngine;
using Verse;

namespace RimUniverse.CoreModule
{
    public class Settings : ModSettings
    {
        public static Vector2 scrollPosition = Vector2.zero;

        public bool showModDesignators = true;
        public bool waterResponsive = true;

        public void DoWindowContents(Rect inRect)
        {
            var rect = inRect.width - 50f;
            var listing_Standard = new Listing_Standard {ColumnWidth = rect};
            var outRect = new Rect(inRect.x, inRect.y, inRect.width, inRect.height);
            var scrollRect = new Rect(0f, 0f, inRect.width - 15f, inRect.height * 2f);
            Widgets.BeginScrollView(outRect, ref scrollPosition, scrollRect);
            listing_Standard.Begin(scrollRect);
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


            if (ModLister.GetActiveModWithIdentifier("Balthoraz.RimUniverse.BiomesModule") != null)
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

            listing_Standard.End();
            Widgets.EndScrollView();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref showModDesignators, "ShowModDesignators", true);
            Scribe_Values.Look(ref waterResponsive, "WaterResponsive", true);
        }
    }
}