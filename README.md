# Maelstrom2

This project is dedicated to the development of Maelstrom2, inspired by the classic MacOS game Maelstrom by Ambrosia Software. 
Builds are planned for MacOS x86 and ARM, along with Windows and eventually iOS. The game is being developed using Unity Game Engine and will feature updated graphics, smoother gameplay mechanics and transitions, and many new game elements inspired by the original game.

There are many things sill needing to be finished, including animation logic, textures and UI images, Sprites, and some extra scripting for some game events
such as Super Novas, New Gamma Ray bursts events, Black holes, and X/times score multplier coins.


Features near completeion:

Canisters - these hold ammo upgrades much like the original, plus shield refill.

Enemy Logic - Scripts are finished to handle the three types of ET enemy Craft logic.

Player Mechanics - Scripts are nearly finished to handle respawn, location, and status updates.

The scripts are about 90% finished with some missing logic for future mechanics and some animations which haven't been created yet.

Features waiting to be worked on:
Settings UI panel, though it exists it is not finsihed and has zero logic written.
Animations
Sprites
UI design

As of right now I am only including the scripts for people to disect and pick apart, I will add a build folder with the project's assests
once the project is easier to maintain.

The project is still in it's infancy but is being constantly worked on by myself. Feel free to modify these scripts and report back if you wish.
If you would like to help contribute to the project I am always looking for help. I can give the full project build files per request, but as of right now they are not 
tangable enough to put up here without a full explaination of the game objects and their structure within Unity.

All contributors to the project development will be credited in the final release. Currently A development build is in the works and a release can be expected within
the next few months or faster if I can get game art finished faster.

This will be an open project to welcome all developers who hold a special place in their hears for the original Maelstrom game.

Definition of of finished files:
<br>
Asteroid.cs - Handles asteroid movements, spawning increase per wave, and wrap code for screen edge wrapping.
<BR>
Bullet.cs - Handles all ammo logic for bullet speed, distance, and friendly/enemy fire logic.
<br>
Comet.cs - Handles comet logic including chance of spawn, comet duration, and comet colider logic.
<BR>
ETCraftEnemy.cs - Handles movement for Purple, Green, and new Blue ET enemy craft, disables screen wrap logic on this object so they can pass through wave in defined pattern.
<BR>
GameManager.cs - This file handles most of the game logic interacitons between prefabs and UI elements and their objects.
<BR>
PlayerController.cs - Handles input logic, player movement, thrust, shield logic, and state updates for powerups, and score saving.
<BR>
PowerUp.cs - Handles all power up logic for long range, repeater, and spreader logic including distance and rate of fire. Also masks canister object to include random powerup.
<BR>
SaveMeEvent.cs - This is the logic for stranded ship spawn rate, position, and animations as well as on player collision logic. Extra Life modifier logic.
<BR>
SuperNovaEvent.cs - This handles the supernova logic, screen shake logic, and object fling logic for when the explosion goes off, also has new mechanic logic.


Old scripts (do not use)
<BR>
WaveEndManager.cs - This is broken and no longer needed as wave logic is included in the finished GameManager.cs script.
<BR>
StartScreenManager.cs - This is a different approach for logic on the start screen and UI menu elements. It is not needed as this is included in the Scene Game Manager script.
<BR>
SettingsManager.cs - May not be used, logic to bring up settings specific to Mac intel and ARM builds. Not finished.
<BR>
HighScoreManager.cs - This is broken and it's updated code is now part of PlayerController.cs script.
<BR>
GameManager.cs - The first script build of the game manager object, this is very broken and any usable code is brought to the revised version.
