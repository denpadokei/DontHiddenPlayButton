using BS_Utils.Utilities;
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
        private static bool _isWIP = false;

        public static bool Prefix(ref bool state, ScoreSaberLeaderboardView __instance)
        {
            var button = __instance.GetField<Button, ScoreSaberLeaderboardView>("_playButton");
            if (_isWIP) {
                button.interactable = false;
            }
            else {
                button.interactable = state;
            }
            return false;
        }

        static SetPlayButtonStatePatch()
        {
            BSEvents.levelSelected += BSEvents_levelSelected;
        }

        private static void BSEvents_levelSelected(LevelCollectionViewController arg1, IPreviewBeatmapLevel arg2)
        {
            _isWIP = arg2.levelID.EndsWith(" WIP");
        }
    }
}
