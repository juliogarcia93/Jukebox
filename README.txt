README

Group 4  
Casey Barbello, Julio Garcia, Mathew Glodack, Christina Morris, Daryl Pham

Accessing the live site:

	Our project is up and running online and can be accessed at www.ucsbjukebox.info. The instructions for using the website are under How to Run the System:

Instructions to execute System:

	To run our project, the first and foremost requirements are to have a windows OS installed on your system and to have Microsoft Visual Studios installed onto your system.  After that, the instructions to run our project 
is quite simple.  
	To start, with the files provided, there is a solutions file titled "Jukebox.sln" that holds the
project together.  Open this file within Visual Studios and all the files will appear on the screen on the right hand side in the solutions explorer.  From there, you can select the many different files that we are working on
to look at the code.  The solutions explorer contains everything that the project uses and keeps each different part of the project within various folders.  
	Once you open the solutions file inside Visual Studios, to run the project is very simple.  The first step is to link the database to the project.  To do this, go to the solutions explorer on the right and click the Entities tab and click on the "Music.edmx" file.  A diagram will open and in the window, right-click and select "Generate Database from Model".  Press finish and yes to all dialog boxes and afterwards, a new file will appear in the workplace window. At the top of this window, there is a different play button that is also green but is empty in the middle.  To the 
right of this there is a set of buttons.  One button looks like a black box connected to a remote by a bar.  Press this and select connect.  Afterwards, in the dropdown menu to the right of this icon, select Jukebox and then press the empty play button back to the left.  This will connect your database.  
	After that step is done, the rest is simple.  Simply go to the very top menu-bar in the program and select BUILD->Build Solution.  This will build the solution that is runnable.  Afterwards, press that play button that is not hollow and is right underneath the top menu bar and the solutions should run.  
	The only library that is needed for our project to function correctly is the "taglib-sharp-master" library that is also provided.  The library is already linked and included within the solution and should work when the solution is built.  



How to Run the System:

	The system is pretty simple to use and is very user-friendly.  When you first start the site, the front page will be displayed with a bar at the top and our home screen.  To start, you should register an account by selecting register in the top right corner of the screen.  Once an account has been created, the site will redirect you to the profile page where you can upload music and play music with an integrated playlist.  Uploading is straight-forward and easy to do.  Just click the upload button and select the files you wish to upload.  The player can take MP3 and M4a format and will return errors for any other format.  After you have uploaded the songs, you can play each song by simply clicking the song you wish to play in the list in the middle of the profile page.  
	Upon logging in, next to the home button at the top left of the site, there will now be a playlist dropdown that, when clicked, will allow users to create a room or search for a room to join. When you select to Create a Room, you will first be prompted with what type of room you wish to create: public or private. Depending upon which option you choose, you will recieve a diffent form to fill out. once you enter in the apprpriate information select Create and a new room will be made you you. There will be no music in the room but you will be added to the list of accounts. To add music to the room, press the AddSongs button in the top left hand corner. A modal will pop up with a list of all the songs in your profile. Select the songs you want to add by putting a checkmark nect to them then select Add. To Join a public room, select join a room from the top dropdown bar. A modal will pop up that will ask you what type of room you wich to join. Again, depending upon which one you choose, you will be asked to fill out different forms. For public rooms, you will be brought to a search page that allows you to look at all the rooms based on the genre you search for. One you select a room, you will be added to the account list and you will be able to add music in the same way that you add music when you create a room. There is a leave a room button that gives you the option to leave a room in order to join another.

When playing music, our music player is set up to be as user-friendly as possible. The music player displays the song and artist and updates every time the current song is changed. If you want to pause or play the song, you can use the button at the bottom left or you can use the spacebar. If you want to go to the next song in the playlist, you can use the right arrow. To go back, use the left arrow. If you want to skip to a specific song, you can click on the songtitle and that song will start playing. If you want to search for a song, just start typing the name or artist of the song and the playlist will update to only show songs that match you search.

Some of the cool features on the website are the edit and like buttons. The edit button on your profile playlist allows you to edit the metadata of your songs. Also, you have the ability to delete songs from your profile. The like button in the rooms allows you to rate songs based on your preference. As songs are liked, the order of the list is updated so that songs with more likes are higher up on the list. Also, the top ten songs with the most likes are displayed on the home page.