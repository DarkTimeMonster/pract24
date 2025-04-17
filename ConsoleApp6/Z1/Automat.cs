using System;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class Automat
    {
        public enum State { A, B }
        protected State currentState;
        protected Dictionary<State, Dictionary<string, State>> transitionTable;

        public Automat()
        {
            currentState = State.A;

            transitionTable = new Dictionary<State, Dictionary<string, State>>
            {
                { State.A, new Dictionary<string, State>
                    {
                        { "110", State.A },
                        { "012", State.B },
                        { "210", State.B }
                    }
                },
                { State.B, new Dictionary<string, State>
                    {
                        { "111", State.B },
                        { "012", State.A },
                        { "211", State.A }
                    }
                }
            };
        }

        public virtual void ProcessInput(string input)
        {
            if (transitionTable.ContainsKey(currentState) &&
                transitionTable[currentState].ContainsKey(input))
            {
                State next = transitionTable[currentState][input];
                Console.WriteLine($"Переход: {currentState} --({input})--> {next}");
                currentState = next;
            }
            else
            {
                Console.WriteLine($"Неверный ввод '{input}' для состояния {currentState}");
            }
        }

        public State GetCurrentState() => currentState;

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Текущее состояние: {currentState}");
            Console.WriteLine("Возможные переходы:");
            foreach (var from in transitionTable)
            {
                foreach (var input in from.Value)
                {
                    Console.WriteLine($"  {from.Key} --({input.Key})--> {input.Value}");
                }
            }
        }

        public void Reset()
        {
            currentState = State.A;
            Console.WriteLine("Автомат сброшен в состояние A");
        }
    }
}
