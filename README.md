# TeamCheck
Team Check, Site Restrict

![image](https://github.com/user-attachments/assets/dc3a1962-3410-4b66-ba76-2a53abc88003)

This simple plugin shows on the screen whether the game is played on both sites or only on site A, depending on the number of players on the teams at the beginning of each round.
The config is created automatically when the plugin is first started where you can configure the minimum number of players, how many seconds after the start of the round the message should appear and how long the message should last on the screen

Example config:
 ```css
{
  "MinPlayersPerTeam": 5,  //if players < 5 show Play ONLY A
  "InitialDelaySeconds": 7, // delay from start round
  "RepeatDelaySeconds": 2.5, // Repeat after 2.5 sec
  "Version": 1
}
