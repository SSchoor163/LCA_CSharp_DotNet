Psuedo Code for towers of Hanoi
Write title of towers of hanoi
write rules
ask the user to choose how difficult they want the game, by increasing the number of pieces. 3-10
intialize towers, moveFrom, moveTo, turns, size
set the size and validate it
print board
while loop- While victoryConditions are not met, loop through following code until conditions are met
Ask user which tower they want to move
	if entry is empty or invalid ask again
ask user which tower they want to move to
	if entry is invalid or has a smaller piece in it ask again
move tower piece to the desired piece
reprint board and go back to loop
when victory is achieved print board, say you win and print number of turns

functions
printboard
victoryConditions

dictionary towers: A 4 3 2 1
				   B
				   C
