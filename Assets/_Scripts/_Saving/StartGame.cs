using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadCore());
    }

    public IEnumerator LoadCore()
    {
        yield return new WaitForSeconds(1);
        if (!SceneManager.GetSceneByName("Core").isLoaded)
        {
            SceneManager.LoadScene("Core", LoadSceneMode.Additive);
        }
    }
}
