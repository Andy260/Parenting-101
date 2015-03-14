using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour
{
	//Variables
	bool showHighscores;
	bool showMenu;
	//
	
	void Start()
	{
		showHighscores = false;
		showMenu = false;
	}

	void Update()
	{
		if(Input.GetKeyDown("escape") && Application.loadedLevel == 0) // Quit the application if we're on the menu and we press 'Escape'
		{
			Application.Quit();
		}
		else if(Input.GetKeyDown("escape") && showMenu == false) //If we're on the play state and we press escape, display the menu screen
		{
			showMenu = true;
		}
		else if(Input.GetKeyDown("escape") && showMenu == true) //If we're on the play state and we press escape and the menu is open, close it
		{
			showMenu = false;
		}
	}

	void OnGUI()
	{
		switch(Application.loadedLevel)
		{
			case (0): // Menu State
			{
                if(showHighscores == false)
                {
                    GUI.Box(new Rect(10, 10, 200, 120), "Main Menu");

                    if (GUI.Button(new Rect(20, 40, 180, 20), "Play"))
                    {
                        showHighscores = false;
                        Application.LoadLevel(1); //Load the playstate
                    }
                    else if (GUI.Button(new Rect(20, 70, 180, 20), "Show/Hide Highscores"))
                    {
                        showHighscores = true;
                    }
                    else if (GUI.Button(new Rect(20, 100, 180, 20), "Quit"))
                    {
                        print("Application send 'QUIT'");
                        showMenu = false;
                        Application.Quit();
                    }
                }
                else if(showHighscores == true)
				{
					GUI.Box(new Rect(10, 10, 200, 200), "Highscores");
                    if (GUI.Button(new Rect(20, 40, 180, 20), "Back"))
                    {
                        showHighscores = false;
                    }
				}

				break;
			}
			case (1): // Play State
			{
				if(showMenu)
				{
					GUI.Box(new Rect(10,10,200,60), "Play Menu");
		
					if(GUI.Button(new Rect(20,40,180,20), "Return To Menu"))
					{
						Application.LoadLevel(0); //Load the menu
					}
				}
				break;
			}
		}		
	}
}
