using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


namespace ProjectSpacer
{
    public class LoadSceneOnClick : MonoBehaviour
    {

        public void LoadByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
