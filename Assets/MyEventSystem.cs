using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class MyEventSystem
{
  
    public static System.Action<int> gameStarted;
    public static System.Action<int> gameOver;
    public static System.Action<int> indexFound;
    public static System.Action<int> testOver;
    
}
