# Roll a Cube Project

In this practice we are going to create a game with a cube in Unity. Specifically this game consists of the following:

1. Scene whit the menu, contain 1 button to start the game

  - Here you can strat the game by hitting the `Start` button.

2. Scene `1st level`

  - First (and only, by the moment) level of the game. You have to paint the floor of the scene with 3 differents colors. You will get each color when you get the collectables. Each color has a different point value. Game is done when you finish painting all the floor segments.
  
  
3. Scene `Game Over`

  - When all the floor is painted, you will be send to this scene where you will have a resume of the game points. 

## Getting Started 🚀

In order to develop this game, the following steps have been taken:
  - Completing the tutorial hosted on the Unity platform.
  - Researching to add new elements in the game, such as jumping, swapping between scenes, adding textures....


### Pre-requisites 📋

Have Unity and Visual Studio installed.
Aspects to take into account: so that visual studio detects the variables and can perform the autocompletion. You must close the IDE and in the Unity program, go to Edit/Preferences/External Tools and in the External Script Editor option, choose Visual Studio.

## Built with 🛠️

- Unity 

## Additional Elements added after the tutorial 🎁

- Jump cube.
- Roll movement for the cube
- Change floor color after ´player´ collides with it
- Avoid getting out of the map without RigidBody 
- Go to another scene, after all the floor is painted
- The menu scene that after pressing the button, allows you to start playing the game.


## Notes :notebook:

  Because i decided to take other way and make my own idea, there are several differences between the original tutorial and my final game. First all, my player is a cube instead a ball, so i have had to research a lot to make the physics works normaly. 
  Jump is just implemented to get all the points in the activity correction, but IS NOT RECOMENDED TO USE. Mostly of the time, the movement of the cube is make by a adding of rotation and displacement to the player. There are no forces in this movements, just maths added to the position of the player. When RigidBody use the physics, this positions can change and make the game not efficient. So thats why JUMP COULD MAKE A MESS in the game graphics and game gameplay.


Made whit 💜 by `Néstor Lorenzo Artiles`
