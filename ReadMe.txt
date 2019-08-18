Sudoku test

Task:
Implement windows desktop program for solving classic Sudoku puzzle of size 9x9. 
Use your own solver. 
Implement Save/Load function.

Input: 
Manually entered/loaded Sudoku puzzle. 

Output: 
Puzzle solved by your program.

Requirements:
Use following technologies:
-	.NET Framework 4+
-	Windows Forms
-	C#

Send us:
- complete VS project including compiled program.
- saved Game which we can load and solve using your solver


UI
--

Main form - frmMain - btn Clear, New, Save, Solve, Cancel, lstBox Games
gameState - actual state of app
			- opened, closing, new game, loading game, editing game, saving game

opening, closingx, clearingx, loadingx, editingx, savingx

opening frmMain => all txtBoxes set 0 text 
		- btn Clear = btn New = btn Cancel = lstBox Games = enabled
		- btn Save = btn Solve = disabled
		- gameState = opening, editing



create a new game - btn New,
					- insert in all txtBoxes value 0
					- btn Clear = btn Save = btn Cancel = enabled
					- btn Solve = lstBox Games = disabled
					- gameState = editing




list box - list of saved games, shows game's id, 
		- when index changed => check if UI is showing edited game =>
																		True Ask if discard changes => 
																										True fill txtBoxes by values from chosen game 
																										False nothing
																		False fill txtBoxes by values from chosen game
		- gameState = loading, editing




save game - btn Save, parses data from UI & check correctness of input => 
																			True saves into database & update lstBox Games & txtBoxes dont change
																			False shows message
		- btn Clear = btn Load = btn Save = btn Cancel = lstBox Games == enabled
		- btn Solve == disabled
		- gameState = saving


clear UI - btn Clear => all txtBoxes set 0 text
		- btn New = btn Cancel = lstBox Games = enabled
		- btn Save = btn Solve = disabled
		- gameState = clearing, editing


cancel - btn Cancel => frmMain close
					- => check if UI is showing edited game =>
																True Ask if save changes => 
																								True parses data from UI & check correctness of input => 
																																						True saves into database & frmMain close
																																						False shows message Data not correct (no save) & frmMain close
																								False frmMain close
					- gameState = closing



Methods >
setDefaultValues ... all txtBoxes set 0 text & state = editing , void, return void
isEditedState    ... checks if state == editing , void, return bool
setPuzzleValues  ... get data from db, set txtBoxes by value, int, return void
parsingValues    ... get data from all txtBoxes, void, return int [,]
isInputCorrect   ... checks if input from UI is correct int[,], return bool
savePuzzle       ... saving data to database int [,], return void



