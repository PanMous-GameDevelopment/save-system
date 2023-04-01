# save-system
A save system that saves object position, rotation and active state to .json file on game exit and loads data on game start.

1. Open with Unity.
2. In the "Scenes" folder first open the "MainMenu" scene.

The "New Game" button deletes the previous save file if it exists and starts a new game.
The "Continue" button gets deactivated if there is no save file in the path. Otherwise, if there is a save file pressing it will load the saved data, thus loading the scene as it was left before exiting the game.
