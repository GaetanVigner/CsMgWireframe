using InputMgr.Abstract;
using System;

namespace WireFrame.Commands
{
    class CommandLeft<T> : Command<T> where T : Map
    {
        public override void Execute(T map)
        {
            Console.WriteLine("Left");
            map.Left();
        }
    }
}
