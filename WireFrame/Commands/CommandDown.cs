using InputMgr.Abstract;
using System;

namespace WireFrame.Commands
{
    class CommandDown<T> : Command<T> where T : Map
    {
        public override void Execute(T map)
        {
            Console.WriteLine("Down");
            map.Down();
        }
    }
}
