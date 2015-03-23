using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;

public class GUIBehaviour : MonoBehaviour 
{
    Text _highscoreDisplay;             // Reference to Highscore display text object
    public int _displayHighscore;       // Score display within Main Menu
    public int _savedHighscore;         // Saved score within PlayerPref
    string _playerPref_key;             // Key used to save score within PlayerPref

	void Start () 
    {
        _playerPref_key = "p101_highscore";

        // Delete playerPrefs on editor playback
        EditorPrefs.DeleteKey(_playerPref_key);

        // Deletes playerPrefs for debugging purposes
        EditorPrefs.DeleteKey(_playerPref_key);

        // Load highscore
	    if (PlayerPrefs.HasKey(_playerPref_key))
        {
            // Player score present
            _savedHighscore = PlayerPrefs.GetInt(_playerPref_key);
        }
        else
        {
            // Player score not present, create new one
            _savedHighscore = 0;

            PlayerPrefs.SetInt(_playerPref_key, _savedHighscore);
            PlayerPrefs.Save();
        }

        // Update public variables, so they are visible within the inspector
        _displayHighscore = _savedHighscore;

        // Get Player's Score game object, by going through hierarchy 
        GameObject gameObject = GameObject.Find("Menu Canvas");
        gameObject = gameObject.transform.FindChild("Highscore Panel").gameObject;
        gameObject = gameObject.transform.FindChild("Player's Score").gameObject;

        // Get Highscore display reference
        _highscoreDisplay = gameObject.GetComponent<Text>();

        // Set highscore display within main menu
        _highscoreDisplay.text = _displayHighscore.ToString();
    }
	
	void Update () 
    {
	    
	}

    /// <summary>
    /// Sets new highscore and saves it
    /// </summary>
    /// <param name="a_score">Score to save</param>
    public void SetPlayerScore(int a_score)
    {
        _displayHighscore = a_score;
        _savedHighscore = _displayHighscore;

        PlayerPrefs.SetInt(_playerPref_key, _displayHighscore);
    }

    /// <summary>
    /// Changes scenes to the game scene
    /// </summary>
    public void StartGame()
    {
        Application.LoadLevel("PlayState");
    }
}
