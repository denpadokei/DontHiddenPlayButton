using HarmonyLib;
using IPA.Utilities;
using ScoreSaber.UI.Other;
using System;
using UnityEngine.UI;

namespace DontHiddenPlayButton.Patches
{
    [HarmonyPatch(typeof(ScoreSaberLeaderboardView),
        nameof(ScoreSaberLeaderboardView.SetPlayButtonState),
        new Type[] { typeof(bool) })]
    public class SetPlayButtonStatePatch
    {
        public static bool Prefix(ref bool state, ScoreSaberLeaderboardView __instance)
        {
            var button = __instance.GetField<Button, ScoreSaberLeaderboardView>("#=zMZIPr5eSY$UN");
            button.interactable = state;
            return false;
        }
    }
}
