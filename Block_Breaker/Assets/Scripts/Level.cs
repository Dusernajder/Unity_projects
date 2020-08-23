using UnityEngine;

public class Level : MonoBehaviour
{
    private int _breakableBlocks;


    // cached reference
    private SceneLoader _sceneLoader;


    private void Start()
    {
        _sceneLoader = FindObjectOfType<SceneLoader>();
    }


    public void CountBlocks()
    {
        _breakableBlocks++;
    }


    public void DecrementBreakableBlocks()
    {
        _breakableBlocks--;
        if (_breakableBlocks <= 0)
        {
            _sceneLoader.LoadNextScene();
        }
    }
}