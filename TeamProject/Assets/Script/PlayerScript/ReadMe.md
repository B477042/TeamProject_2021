# About This Folder
This folder is collection of codes is made for player.

## Why i decide to take control about player
Because Zheng jun couldn't explain about what he made. So, it is impossible to apply his works to project.

## Code Review
### Overview

- Relationship between GamePlayerController.cs and GamePlayer.cs is like a Commander and Reciever.
Controller order to player such as move, attack. It handle user's input about player object.

- GamePlayerStat : It is component. It represent Player's stat like Hp, Atk, moving speed.
- GamePlayerState : It is component. It help animator. 
- Mag : It is compoenet also manager. It controll objects that player need to attack. All of bullet objects that player use for fire are controled by this script. It is designed the object pooling pattern.

- And BGSpringArm is spring arm connected to back ground image. I calculated to when player move to some point background also follow player like moving landscape when we ride a car.

### What i focus to 
I foucs to seperate functions to components as i can. And to be clearly relationship between controller and player.

Also, i made using object pooling pattern to optimize performance in Mag.cs



---
This ReadME is written by Young Wook Choi