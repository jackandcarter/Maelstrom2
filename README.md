# Maelstrom2

This project is dedicated to the development of Maelstrom2, inspired by the classic MacOS game Maelstrom by Ambrosia Software. 
Builds are planned for MacOS Intel and Apple Silicon, along with Windows and eventually iOS. The game is being developed using Unity Game Engine and will feature updated graphics, smoother gameplay mechanics, new features and mechanics, and transitions with many new game elements inspired by the original game. This is here to share the progress made so far.
<BR>
<BR>
There are many things still needing to be finished, but I'm happy to say the project is well on it's way now :)
<br>
Asteroid animations and Spawn points are finished, bullet system and animations are done, and player ship movement is complete. Player shields work now but still need animation. All Power Ups are nearly complete with just a bit of tweaking left, mechanic management is complete, and new features have been implimented. It's mostly graphics and Main Menu, Game Over, and UI elements that are left to be finished.

The Revision 1 Scripts are old game object logic with no new functionality, they are slowly being removed as they are implimented into the revision 3 scipts.
<BR><BR>
Revision 3 Scripts are the newest, they combine alot of the game's logic into three major mechanic systems, Game Manager, Wave Manager, and Event Manager.
<BR><BR>
Event Manager - 
<BR>
Handles the logic for spawning Power Up Events, Bad Guy Events, and Wave Events such as black hole, gamma burst, super nova, et craft, comets, meteor shower, and power ups, etc. Attach the needed prefabs and spawn points after adding this script to an empty game object in the gameplay scene.
<BR><BR>
Game Manager - 
<BR><BR>
Handles logic for holding player stats such as lives, shield, power ups applied, and all points, it's responsible for reporting this info to the UI elements, and works together with the other mechanics scripts that require this information such as the wave manager to determine the win or lose triggers per wave.
<BR><BR>
Wave Manager - 
<BR>BR>
This is holds most of the logic for the game. It is responsible for spawning asteroids, the player after death or win, handles UI window and scene transitions for the wave win UI, pause UI, and game over UI. It handles all spawn points and randomizations for objects, and works together with every other script to work seamlessly during wave progression.
<BR><BR>
Player Controller - 
<BR><BR>
This handles player movement, spawn, Bullet Power up activation for spreader, repeater, long range, and the raw ore pickup to decrease chance of death on next hit (a.k.a Clover) during the Space Junk Event, this works together with the wave manager, bullet controller, and respective power up scripts to handle their mechanics.
<BR><BR>
Asteroid Controller - 
<BR><BR>
This script is attached to each asteroid prefab and handles their hit requirements to split, handles split logic which works together with the wave manager to determine the last small asteroid and if it becomes destroyed to call the win condition. It also works together with player controller and enemy scripting to allow hits from them based on current conditions.
<BR><BR>
ScreenWrapObject -
<BR><BR>
This replaces the old screen wrap system's logic with a more clean version, this script needs to be present in the unity project assets folder, the player controller, asteroid controller, and any other object that wraps the screen will have reference in their scripts to this file and work with it to apply it's mechanics.
<BR><BR>
PowerUp.cs Scripts - 
<BR><BR>
These are the logic for the power up prefabs and are attached respectively. These are still being worked on and need mechanics tweaking but will function.
