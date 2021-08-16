using UnityEngine;
using Verse;

namespace RimUniverse.CoreModule
{
    [StaticConstructorOnStartup]
    public static class Resources
    {
        public static readonly Texture2D SettingsHeader = ContentFinder<Texture2D>.Get("Things/Misc/SettingsHeader");

        static Resources()
        {
        }
    }
}