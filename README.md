
<img width="262" alt="GameIcon" src="https://github.com/jackandcarter/Maelstrom2/assets/131922119/e0db474a-305b-4e98-9ae8-0b76d7da7c0a">

# Maelstrom2

This project is dedicated to the development of Maelstrom2, inspired by the classic MacOS game Maelstrom by Ambrosia Software. 
Builds are planned for MacOS Intel and Apple Silicon, along with Windows and eventually iOS. The game is being developed using Unity Game Engine and will feature updated graphics, smoother gameplay mechanics, new features, and transitions with many new game elements inspired by the original game. This readme is here to share the progress made so far.
<BR>
<BR>
There are a few things that still need to be finished, <BR>but I'm happy to say the project is near it's fully functioning developer build :)
<br>
<BR>
<BR> The script descriptions below reflect their described mechanics and have fully implemented logic. You can find them in their respective folders.<BR>
As of right now we are at revision 6.1 of the main build and have a developer build available for testing. The next revision is planned to fix current behaviors of the existing mechanics.
<BR><BR>
**Managers**<BR><BR>
     GameManager - Handles game states, level progression, Asteroid count UI, and overall control.<BR>
     EventManager - Manages beneficial and harmful events.<BR>
     AudioManager - Controls audio and sound effects.<BR>
     SaveManager - Handles saving and loading game progress.<BR>
     LevelManager - Probably the biggest script with the most logic for player, level, and UI mechanics, it uses update function together with GameManager to track asteroids and call level win condition.
<BR><BR>
**Player Scripts**<BR><BR>
   PlayerController - Manages player ship movement, input handling, and collision detection.<BR>
   PlayerHealth - Manages player health, shield points, and respawning logic.<BR>
   PlayerAmmo - Handles player's ammo power-ups and their effects.<BR>
   PlayerUI - Updates the player-related UI elements, such as lives, shield meter, and ammo display.<BR>
<BR>
**Asteroid Scripts**<BR><BR>
   LargeAsteroid - Handles asteroid behavior, including splitting logic and collisions as well as player point onDestroy.<BR>
   MediumAsteroid - Handles asteroid behavior, including splitting logic and collisions as well as player point onDestroy.<BR>
   SmallAsteroid - Handles asteroid behavior and collisions with small asteroids as well as player points assigned onDestroy.<BR>
   AsteroidManager - Manages asteroid spawning and wave-related logic.<BR>
<BR>
**Enemy Scripts**<BR>
   EnemyController Scripts - Controls enemy spacecraft movement for each type, shooting behavior, and AI. See the scripts for each type of craft behavior.<BR>
   EnemySpawnManager - Manages enemy spawning, types, and A.I.s.<BR>
<BR>
**Bullet Scripts**<BR><BR>
   BulletManager - Manages bullet pool for spawning, recycling, and collision detection of all bullet types such as enemies, player ammo upgrades, etc.<BR>
   BulletCollision - Handles conditions for bullet vs game objects using triggers.<BR>
<BR>
**Power-Up Scripts**<BR><BR>
   PowerUp Prefab Scripts - Defines power-up behavior, duration, and effects.<BR>
   PowerUpManager - Manages power-up spawning, pickup, and duration tracking.<BR>
<BR>
**Level Scripts**<BR><BR>
   LevelManager - Controls level transitions and overall game pacing.<BR>
<BR>
**Event Scripts**<BR><BR>
   Separate scripts for each event type (`SaveMeEvent`, `CometEvent`, etc.) - Handles specific event behavior. See the individual scripts for their behaviors.<BR>
   EventController - Manages event spawning, timing, and interactions.<BR>
<BR>
**UI Scripts**<BR><BR>
   UIManager - Manages UI elements, updates scores, lives, and wave progress for the Game Play scene’s UI bar.<BR>
  <BR>
**Screen Wrap** - Attached to game objects that require the screen wrap mechanic to stay in screen bounds.<BR>
<BR>
**Sound and Audio**<BR><BR>
    AudioManager - Handles playing of all audio clips when the audio manager is called upon, as an instance it will allow access to audio clips from all other scripts.<BR>
<BR>
**Save/Load System**<BR><BR>
    SaveManager - Handles saving and loading game progress for up to 3 profiles at the moment, with the logic to implement more already in place using PlayerPrefs.<BR>
<BR>
**Effects**<BR><BR>
    CameraShake - For SuperNova effect after explosion, attaches to the main camera but the script’s code needs work.<BR>
    DestroyAfterAnimation - Destroys any animation prefab that doesn’t loop upon last clip playing.<BR>
<BR>
<BR>
With this script layout and organization, each game component is encapsulated within its respective scripts, making it easier to maintain, extend, and debug. This will be the format moving forward for all mechanics or any additional features that will be added in official major updates.<BR>
<BR>
