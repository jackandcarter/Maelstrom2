# Maelstrom2

This project is dedicated to the development of Maelstrom2, inspired by the classic MacOS game Maelstrom by Ambrosia Software. 
Builds are planned for MacOS x86 and ARM, along with Windows and eventually iOS. The game is being developed using Unity Game Engine and will feature updated graphics, smoother gameplay mechanics and transitions, and many new game elements inspired by the original game.

There are many things sill needing to be finished, including animation logic, textures and UI images, Sprites, and some extra scripting for some game events
such as Super Novas, New Gamma Ray bursts events, Black holes, and X/times score multplier coins.


The Revision 1 Scripts are fully functional game object logic with placeholders for addition features to be added later.

Features currently being worked on:
Settings UI panel - though it exists it is not finsihed and has zero logic written.
Animations for gameplay background
Sprites - Sprites for Asteroids, Player Ship, and Bullets are complete, still need sprites for enemies and events.
UI design - as of right now only developer UI is present for debugging purposes.

Game Object assets are available on request along with the full project build for Unity.

The project is still in it's infancy but is being constantly worked on by myself. Feel free to modify these scripts and report back if you wish.
If you would like to help contribute to the project it would be more than welcomed. As of right now the full build is not 
tangable enough to put up here without a full explaination of the game objects and their structure within Unity, the project is currently buildable with working gameplay elements.

All contributors to the project development will be credited in the final release. Currently A development build is in the works and a release can be expected within
the next few months or faster if I can get game art finished faster.

This will be an open project to welcome all developers who hold a special place in their hearts for the original Maelstrom game.

Definition of files:
<br><br>
AsteroidController.cs - Handles asteroid movements, spawning increase per wave, and is attached to asteroid prefab.
<BR><br>
Current Build Assets.zip - This holds the scripts, sprites, and other development files, this will only be updated when major mechanics change.
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
IScreenWrappable.cs - Handles logic for making screen wrappable for all objects other than ET craft. Attached to empyt game object in scene.
<BR><br>
MainMenuController.cs - Handle button logic and UI mechanics for the main menu screen.
<BR><br>
PlayerController.cs - Handles input logic, player movement, thrust, shield logic, and state updates for powerups, and score saving.
<BR><br>
PowerUpController.cs - Handles all power up logic for long range, repeater, and spreader logic including distance and rate of fire. Also masks canister object to include random powerup.
<BR><br>
RandomEvenController.cs - Logic for chance rate per wave and rays for spawn points in gameplay scene for Events such as supernova, comets, and black holes, etc.
<BR><br>
SceneTransition.cs - Handles all loading of scenes for the OnClick funcitons.
<BR><br>
ScreenUtils.cs - This will eventually have all the logic for the settings UI panel for desktop versions of the game.
<BR><br>
SettingsPanelController.cs - this includes all logic for player input settings and sliders in the settings UI panel.
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
