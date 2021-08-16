using System;
using System.Linq;
using JetBrains.Annotations;
using RimUniverse.CoreModule;
using RimWorld;
using Verse;

namespace RimUniverse.Submods.ShowModDesignators
{
    [StaticConstructorOnStartup]
    [UsedImplicitly]
    public class ShowModDesignators
    {
        static ShowModDesignators()
        {
            if (Controller.Settings.showModDesignators.Equals(false))
            {
                return;
            }

            foreach (var modContentPack in LoadedModManager.RunningMods.Where(modContentPack =>
                !modContentPack.IsCoreMod))
            foreach (var def in modContentPack.AllDefs)
            {
                try
                {
                    var nameAdd = $"\n({modContentPack.Name})".Replace('[', '(').Replace(']', ')');
                    if (!def.description.NullOrEmpty())
                    {
                        def.description += nameAdd;
                    }

                    switch (def)
                    {
                        case TraitDef traitDef:
                            foreach (var traitDegreeData in traitDef.degreeDatas)
                            {
                                traitDegreeData.description += nameAdd;
                            }

                            break;
                        case ThingDef thingDef:
                            if (thingDef.race != null)
                            {
                                if (thingDef.race.meatDef != null)
                                {
                                    thingDef.race.meatDef.description += nameAdd;
                                }

                                if (thingDef.race.corpseDef != null)
                                {
                                    thingDef.race.corpseDef.description += nameAdd;
                                }

                                if (thingDef.race.leatherDef != null)
                                {
                                    thingDef.race.leatherDef.description += nameAdd;
                                }
                            }

                            break;
                    }

                    if (BackstoryDatabase.allBackstories.TryGetValue(def.defName, out var backStory))
                    {
                        backStory.baseDesc += nameAdd;
                    }
                }
                catch (Exception)
                {
                    Log.Error($"RimUniverse - ShowModDesignator: {def.defName} of {def.GetType()} is evil");
                }
            }
        }
    }
}