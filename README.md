
<img width="262" alt="GameIcon" src="https://github.com/jackandcarter/Maelstrom2/assets/131922119/e0db474a-305b-4e98-9ae8-0b76d7da7c0a">

# Maelstrom2

Build Revision 7 Development
<BR><BR>
Changes:

 - Moved to 3DHRDP Pipeline in Unity.<BR>
 - Created MainMenu Scene and UI elements.<BR>
 - Introduced Spash Screen and Startup Sound to Main Menu Scene.<BR>
 - Created Fade-in Transitions for UI elements on Main Menu Scene.<BR>
 - Introduced Three Play Modes, Includeing Maelstrom2, Original, and Multiplayer Modes.<BR>
 - Introduced the In-Game Debug Console, which can be shown or hidden using the "/" key.<BR>
 - Created Placeholder M2StartScene scene in Unity, this is the scene that loads when entering Maelstrom2 Mode.<BR>
 - Started Development on Level1 Scene for Maelstrom2 Mode.<BR>
 - Introduced Sphere-Shaped Spaces/Boundaries for Levels by devloping a "LevelZone" prefab with bounds wrapping of objects within the sphere.<BR>
 - Created the Player Controller and Ship Camera scripts for Maelstrom2 Mode. These need further development.<BR>
 - Added LeanTween and DOTween to the project allowing for more advanced animations and transition effects.<BR>
 - Added PauseUI Panel to Original Mode and finished Pause Logic, using the "P" key to pause the game and open the PauseUI panel.<BR>
 - Added buttons for returning to the Main Menu and Quitting the game in Original Mode on the PauseUI panel.<BR>
 - Added placeholder Starfield Skybox in Maelstrom2 Mode.<BR>
   <BR><BR><BR>



Bug Fixes:<BR><BR>

 - Fixed Scroll issue with the in-game debug console.<BR>
 - Fixed a bug where wrapped objects get stuck between the buffer gap on screen edges. Updated Screen Wrap logic to more accurately detect position of objects.<BR>
 - Fixed a Fade-in transition bug in the UI and Button elements that use TextMeshPro. We now use LeanTween in the project instead of using transparency methods.<BR>
 - Fixed Player Controller in Original mode to now work in the 3D pipeline. Logic has been changed to calculate and move in a 3D space instead 2D axis.<BR>
 - Changed UI Canvas in Original Mode to "Screen Space-Camera" from "Screen Space-Overlay," This is needed to allow dynamic UI resolution changes based on screen resolution.<BR>
<BR><BR>

With this revision we have the foundation of the game nearly complete. The original 2D project has been moved to "Original Mode" in the 3DHD Rendering Pipeline.<BR>
The game starts with a retrospective splash screen and original Startup Sound, UI elements then fade-in and the player is given options to choose from.<BR>
<BR>
Selecting Original Mode from the main menu will open a UI panel with additional options. Clicking play will start the loading screen for that mode before entering level 1.
<BR><BR>
Selecting Maelstrom2 Mode will load the M2StartScene, where the player is shown the "galaxy map" and additional features for upgrades and power ups before starting a level.<BR>

Selecting of Multiplayer Mode is not implemented yet, but this will load a Lobby scene of some kind where different online play modes will become available.<BR><BR>


This branch includes the project folders for each play mode of the game. These can be used for reference. You can grab the current client builds from the links in the discord.<BR><BR>
The Project Discord can be found here:
<BR><BR>
https://discord.gg/hP6hMgNCJP
<BR><BR>
You'll find the most recent updates and progress on the discord, the github is here just for reference and archival of files. Any of the scripts or files created here can be used freely in non-commercial use.



