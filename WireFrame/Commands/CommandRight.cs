using InputMgr.Abstract;
using System;

namespace WireFrame.Commands
{
    class CommandRight<T> : Command<T> where T : Map
    {
        public override void Execute(T map)
        {
            Console.WriteLine("Right");
            map.Right();
        }
    }
}
