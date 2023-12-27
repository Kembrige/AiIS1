/*

           m        b       a,n      c        d
    0→     1         0        0        0        0
    1→     1         2        3        0        0
    2→     0         0        0        4        0
    3→     0         0        0        4        0
    4→     0         0        0        4        5
    5→     0         0        0        0        0
    
*/
using System;

class Automata
{
    enum State
    {
        Start,
        M,
        B,
        AorN,
        C,
        D,
        Accept
    }

    public bool CheckString(string input)
    {
        State currentState = State.Start;

        foreach (char c in input)
        {
            switch (currentState)
            {
                case State.Start:
                    if (c == 'm')
                        currentState = State.M;
                    else 
                        return false;
                    break;
                case State.M:
                    if (c == 'b')
                        currentState = State.B;
                    else 
                        return false;
                    break;
                case State.B:
                    if (c == 'a' || c == 'n')
                        currentState = State.AorN;
                    else 
                        return false;
                    break;
                case State.AorN:
                    if (c == 'c')
                        currentState = State.C;
                    else 
                        return false;
                    break;
                case State.C:
                    if (c == 'd')
                        currentState = State.D;
                    break;
                case State.D:
                    break;
                default:
                    return false;
            }
        }

        return currentState == State.D;
    }

    public static void Main()
    {
        Automata automata = new Automata();
        Console.WriteLine(automata.CheckString("mbacd")); // true
        Console.WriteLine(automata.CheckString("mbanncd")); // true
        Console.WriteLine(automata.CheckString("mbadd")); // false
    }
}