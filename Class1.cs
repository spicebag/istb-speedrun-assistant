using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;

namespace boogeraids
{
    public class GravesSRA : MelonMod
    {
        private float timer = 0f; // Declare and initialize the timer variable.

        // When the Game starts...
        public override void OnApplicationStart()
        {
            // Get the user's screen refresh rate.
            int refreshRate = Screen.currentResolution.refreshRate;
            // Set the FPS to the user's screen refresh rate.
            Application.targetFrameRate = refreshRate;
            // Print that the users FPS is locked to refresh rate.
            MelonLogger.Log("FPS Locked to " + refreshRate + " FPS.");
        }

        // Print in the console whenever the user switches to a new level, and what level they switched to.
        public override void OnLevelWasLoaded(int level)
        {
            // The level loaded message, along with it's value.
            MelonLogger.Msg("Level Loaded: " + level);
        }

        public override void OnUpdate()
        {
            // If the user is in a level...
            if (Application.loadedLevelName != "MainMenu")
            {
                // Start the timer.
                timer += Time.deltaTime;
            }
            // If the user is in the main menu...
            else
            {
                // If the timer is greater than 0...
                if (timer > 0)
                {
                    // Every time the level switches, print how long it took to beat it.
                    MelonLogger.Msg("Level " + (Application.loadedLevel - 1) + " took " + timer + " seconds to beat.");
                    // Print how long it took to beat the level.
                    MelonLogger.Msg("Level Completed in: " + timer + " seconds.");
                    // Reset the timer.
                    timer = 0;
                }
            }
            // At the end of the game, print how long it took to beat the game in hours, minutes and seconds.
            if (Application.loadedLevelName == "End")
            {
                // The amount of hours it took to beat the game.
                int hours = (int)(timer / 3600);
                // The amount of minutes it took to beat the game.
                int minutes = (int)(timer / 60);
                // The amount of seconds it took to beat the game.
                int seconds = (int)(timer % 60);
                // Print how long it took to beat the game.
                MelonLogger.Msg("Game Completed in: " + hours + " hours, " + minutes + " minutes, and " + seconds + " seconds.");
                MelonLogger.Msg(" ");
                MelonLogger.Msg("Wall of Fame :");
                MelonLogger.Msg("Escaped Ending Run by noobnoob at 13m 16s");
                // Shoutout to the homies who beat the game in under 15 minutes.
                if (timer < 900)
                {
                    MelonLogger.Msg("Good job, get in touch with Graves if you'd like to be added to the Wall of Fame!");
                }
                
                // Shoutout to the homies Kalico & Mr. Monocle for the continued support of the modding group.
            }
        }
    }
}
