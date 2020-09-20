/////////////////////////////////////////////////////////////////////////////////////////
		Start-up
/////////////////////////////////////////////////////////////////////////////////////////

Welcome to the respitory of a simple game I'm currently working on.
The game uses the monogame Framework.

-----------------------------------------------------------------------------------------

Filenames to change: To be able to run the program very small adjustments need to be made:

	-In the File: Game-BlackWhite/Black-White/Black_White/BaseInfo.cs, change the path to ur current where the file BaseFile.json is stored in your system
	-In the file BaseFile.json : Change the base to where the project is located on ur system ending with /Game-BlackWhite/Black-White/Black_White/

If everything is configured correctly you should now be able to execute the program.


/////////////////////////////////////////////////////////////////////////////////////////
		Ingame Features
/////////////////////////////////////////////////////////////////////////////////////////

Current ingame Features (this list be expend as I develop more features):


-------------------Console---------------------

The program currently has a simple ingame that can execute certain commands. To open the console press INSERT on ur keyboard. To hide the console press DELETE.
Now that the console is open you can type in it using your normal keyboard. Press the TAB key to get suggestions of what the console can do. The first word (for example : "Windows"),
is the parent, this indicates which part of the application the command belongs too. When typing "Windows " into the console and pressing TAB again, a lost of commands that the window 
will be printed. After typing a /parent - /Command and pressing TAB, it will display the neccessarry parameters the this specific command requires and of which type it needs to be.

An example of a command:
	"Windows SetSize 1000 1000 16by9"

after typing in ur command press ENTER to have the console execute it.

If Console.SaveHistory is set to TRUE (StandardConfig.json or in Console: Console setSaveHistory) all console input and return messages are saved in a .txt file in the /console/log/ folder. 