using InputMgr.Abstract;
using System;

namespace WireFrame.Commands
{
    class CommandUp<T> : Command<T> where T : Map
    {
        public override void Execute(T map)
        {
            Console.WriteLine("UP");
            map.Up();
        }
    }
}
