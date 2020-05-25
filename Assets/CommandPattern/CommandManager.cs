using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    public List<ICommand> _commandBuffer = new List<ICommand>();
    private static CommandManager _instance;

    public static CommandManager Instance 
    {
        get
        {
            if (_instance == null)
                Debug.LogError("The Command manager is null!");
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void AddCommand(ICommand command)
    {
        _commandBuffer.Add(command);
    }

    public void Rewind()
    {
        StartCoroutine(RewindRoutine());
    }

    IEnumerator RewindRoutine()
    {
        Debug.Log("Rewind...");
        foreach (var command in Enumerable.Reverse(_commandBuffer))
        {
            command.Undue();
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Finish!...");
    }
}
