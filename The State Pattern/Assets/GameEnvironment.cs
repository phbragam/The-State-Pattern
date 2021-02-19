using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironment 
{
    private static GameEnvironment instance;
    private List<GameObject> checkpoints = new List<GameObject>();
    public List<GameObject> Checkpoints { get { return checkpoints; } }

    public GameEnvironment Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnvironment();
                instance.Checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
            }
            return instance;
        }
    }

    public void AddChechpoint(GameObject c)
    {
        Instance.checkpoints.Add(c);
    }

    public void RemoveCheckpoint(GameObject c)
    {
        Instance.checkpoints.Remove(c);
    }
   
}
