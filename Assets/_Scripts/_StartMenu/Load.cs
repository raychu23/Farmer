using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class Load : MonoBehaviour
{
    public void LoadData()
    {
        SceneManager.LoadScene("Level_Farm");

    }

    public void NewGame()
    {
        Global.loadCore = true;
        SceneManager.LoadScene("Level_Farm");
    }

    public void Tutorial()
	{
        Global.tutorial = true;
		SceneManager.LoadScene("Tutorial_Farm");
	}

    public void Credits()
    { 
      SceneManager.LoadScene("Credits");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Start");
    }

    public void Data()
    {
        OpenLinkJSPlugin("https://www.stat2games.sites.grinnell.edu/data/farmer/farmer.php");
    }

    public void Resources()
    {
        OpenLinkJSPlugin("http://web.grinnell.edu/individuals/kuipers/stat2labs/farmer.html");
    }

    private void OpenLinkJSPlugin(string url)
    {
        #if !UNITY_EDITOR
            openWindow(url);
        #endif
    }

    [DllImport("__Internal")]
    private static extern void openWindow(string url);

}
