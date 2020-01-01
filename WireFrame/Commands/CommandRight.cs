using System;
using WireFrame.Abstract;

namespace WireFrame.Commands
{
    class CommandRight : Command
    {
        public override void Execute(Map map)
        {
            Console.WriteLine("Right");
            map.Right();
        }
    }
}
