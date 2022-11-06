using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Interview : MonoBehaviour
{
    [SerializeField] int factorial;


    delegate void a() ;
    a del;



    UnityAction unityAction;

    Action action;

    private void Start()
    {
        del = () => print("x");
        del += () => print("y");

        del();

        action += () => print("Primer método de action");
        action += () => print("Segundo método de action");

        action();
    }


    int Factorial(int factorial)
    {
        if (factorial <= 0) return 1;
        int result = factorial * Factorial(factorial - 1);
        return result;
    }
}
