# save-system
A save system that takes a list of game objects and saves their position, rotation and active state to a .json file on game exit and loads data on game start.
File name : save.json

1. Open with Unity.
2. In the "Scenes" folder first open the "MainMenu" scene.
3. Start the application.

The "New Game" button deletes the previous save file if it exists and starts a new game.

The "Continue" button gets deactivated if there is no save file in the path. Otherwise, if there is a save file in the computer, it will load the saved data, thus loading the scene as it was left before exiting the game.

When the scene scene loads, a message will appear in the console indicating the path of the save file in the computer.

Note: Press E to grab and throw items and left click to deactivate items. If while opening the project an error appears about an FBX, ignore it.

Interactable items: chair, ball, box, and some of the coffee table items.

![Screenshot_36](https://user-images.githubusercontent.com/129271569/229304932-70e8aa1a-7c14-4510-9c3b-766bef64829f.png)

