using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    static SquareDetection squarePressedInvoker = new SquareDetection();
    static List<UnityAction<Alpha,int>> squarePressedListeners = 
        new List<UnityAction<Alpha,int>>();

    public static void AddSquarePressedInvoker(SquareDetection invoker)
    {
        squarePressedInvoker = invoker;
        foreach (UnityAction<Alpha,int> listener in squarePressedListeners)
        {
            invoker.AddSquarePressedListener(listener);
        }
    }

    public static void AddSquarePressedListener(UnityAction<Alpha,int> listener)
    {
        squarePressedListeners.Add(listener);
        squarePressedInvoker.AddSquarePressedListener(listener);
    }

}
