README

Group 4  
Casey Barbello, Julio Garcia, Mathew Glodack, Christina Morris, Daryl Pham

Accessing the live site:

	Our project is up and running online and can be accessed at www.ucsbjukebox.info. Create an account and join a public room using the “rooms” tab in the upper left corner to see examples of rooms that we created with music from all of our profiles.

Instructions to execute System:

	To run our project, the first and foremost requirements are to have a windows OS installed on your system and to have Microsoft Visual Studios installed onto your system.  After that, the instructions to run our project 
is quite simple.  
	To start, with the files provided, there is a solutions file titled "Jukebox.sln" that holds the
project together.  Open this file within Visual Studios and all the files will appear on the screen on the right hand side in the solutions explorer.  From there, you can select the many different files that we are working on
to look at the code and is the organizational part of the project.  The solutions explorer contains everything that the project uses and keeps each different part of the project within various folders.  
	Once you open the solutions file inside Visual Studios, to run the project is very simple.  The first step is to link the database to the project.  To do this, go to the solutions explorer on the right and click the Entities tab and click on the "Music.edmx" file.  A diagram will open and in the window, right-click and select "Generate Database from Model".  Press finish and yes to all dialog boxes and afterwards, a new file will appear in the workplace window. At the top of this window, there is a different play button that is also green but is empty in the middle.  To the 
right of this there is a set of buttons.  One button looks like a black box connected to a remote by a bar.  Press this and select connect.  Afterwards, in the dropdown menu to the right of this icon, select Jukebox and then press the empty play button back to the left.  This will connect your database.  
	After that step is done, the rest is simple.  Simply go to the very top menu-bar in the program and select BUILD->Build Solution.  This will build the solution that is runnable.  Afterwards, press that play button that is not hollow and is right underneath the top menu bar and the solutions should run.  
	The only library that is needed for our project to function correctly is the "taglib-sharp-master" library that is also provided.  The library is already linked and included within the solution and should work when the solution is built.  



How to Run the System:

	The system is pretty simple to use and is very user-friendly.  When you first start the site, the front page will be displayed with a bar at the tip and a small home screen layout.  To start, you should register an account by selecting register in the top right corner of the screen.  Once an account has been created, the site will redirect you to the profile page where you can upload music and play music with an integrated playlist.  Uploading is straight-forward and easy to do.  Just click the upload button and select the files you wish to upload.  For now, the player can only take MP3 format and will return errors for any other format.  After you have uploaded the songs, you can play each song by simply clicking the song you wish to play in the list in the middle of the profile page.  
	Upon logging in as well, next to the home button at the top left of the site, there will now be a playlist dropdown that, when clicked, will allow users to create a room or search for a room to join.  As of right now, those two features are functioning, but we are in the process of making them work.  Later when we finish, we plan to have the features that allow users to interact with each other in the rooms by uploading songs to a community-like playlist.