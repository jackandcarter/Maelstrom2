# Maelstrom2

This project is dedicated to the development of Maelstrom2, inspired by the classic MacOS game Maelstrom by Ambrosia Software. 
Builds are planned for MacOS x86 and ARM, along with Windows and eventually iOS. The game is being developed using Unity Game Engine and will feature updated graphics, smoother gameplay mechanics and transitions, and many new game elements inspired by the original game. This is here to share the progress made so far.
<BR>
There are many things still needing to be finished, but I'm happy to say the project is well on it's way now :)
<br>
Asteroid animations and Spawn points are finished, bullet system and animations are done, and player ship movement is complete. Player shields work now but still need animation.

The Revision 1 Scripts are fully functional game object logic with placeholders for additional features to be added later.

Features currently being worked on:
<br>
Settings UI panel - though it exists it is not finsihed and has zero logic written.
<br>
Animations for gameplay background
<br>
Sprites - Sprites for Asteroids, Player Ship, and Bullets are complete, still need sprites for enemies and events.
<br>
UI design - as of right now only developer UI is present for debugging purposes.
<br><br>
Game Object assets are available on request along with the full project build for Unity.
<br><br>
If you would like to help contribute to the project it would be more than welcome. The build itself is fully functional on MacOS Ventura but should also work on earlier systems.
<br><br>
All contributors to the project development will be credited in the final release, naturally. Currently A development build is in the works and a release can be expected within
the next few months or faster if I can get game art finished faster.
<br><br>
This will be an open project to welcome all developers who hold a special place in their hearts for the original Maelstrom game. If you have any questions just ask.
<br><br>
Definition of files:
<br><br>
AsteroidController.cs - Handles asteroid movement, spawning increase per wave, and is attached to asteroid prefab.
<BR><br>
Current Build Assets.zip - This holds the scripts, sprites, and other development files, this will only be updated when major mechanics change or are added.
<BR><br>
ETCraftEnemy.cs - Handles movement for Purple, Green, and new Blue ET enemy craft, disables screen wrap logic on this object so they can pass through wave in defined pattern.
<BR><br>
EnemyController.cs - Controls Enemy movement, spawn rate, and points.
<BR><br>
GameManager.cs - This file handles most of the game logic interacitons between prefabs, UI elements, and their objects.
<BR><br>
GameOverUIController.cs - Handles logic for Game Over screen when a player is out of lives, Shows total High Score, and applies to high score list if in top 10 scores.
<BR><br>
GameplayUIController.cs - Handles logic for displaying player stats, Power ups, and Bonus points in gameplay scene.
<BR><br>
HighScoreDisplay.cs - Main Menu High Score list logic.
<BR><br>
IScreenWrappable.cs - Handles logic for making screen wrappable for all objects other than ET craft. Attached to empty game object in scene.
<BR><br>
MainMenuController.cs - Handles button logic and UI mechanics for the main menu screen.
<BR><br>
PlayerController.cs - Handles input logic, player movement, thrust modifyer, shield logic, state updates for powerups, and score saving. Attach to PlayerShip Prefab.
<BR><br>
PowerUpController.cs - Handles all power up logic for long range, repeater, and spreader logic including distance and rate of fire. Also masks canister object to include random powerup.
<BR><br>
RandomEvenController.cs - Logic for chance-rate-per-wave and rays for spawn points in gameplay scene for Events such as supernova, comets, and black holes, etc.
<BR><br>
SceneTransition.cs - Handles all loading of scenes for the OnClick funcitons.
<BR><br>
ScreenUtils.cs - This will eventually have all the logic for the settings UI panel for desktop versions of the game.
<BR><br>
SettingsPanelController.cs - this includes all logic for player input settings and sliders in the settings UI panel. Should also work in iOS versions.
<BR><br>
StartScreenManager.cs - This holds the screen transitions between game over, pause, and main menu UI panels.
<BR><br>
UIcontroller.cs - Holds all logic for UI interactions.
<BR><br>
WaveEndManager.cs - This logic handles the wave win requirements, adds additional asteroids per successive wave, and adds player score and bonus points to main score.
<BR><br>
WaveManager.cs - handles logic for asteroid, enemy, and player respawn points along with rays for asteroid splitting.
<BR><br>
backbuttonscript.cs - developer build only, helps us move between scenese that do not have a funcitoning UI.
<BR><br>
quitgameonclick.cs - self explainatory, this is only used for the quit game button on the main menu.
<br>

Old scripts (do not use)
These uploads are mostly broken now with the addition of newer fully functional scripts. They are only for reference at this point.
