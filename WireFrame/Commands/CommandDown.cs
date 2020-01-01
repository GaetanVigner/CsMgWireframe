using System;
using WireFrame.Abstract;

namespace WireFrame.Commands
{
    class CommandDown : Command
    {
        public override void Execute(Map map)
        {
            Console.WriteLine("Down");
            map.Down();
        }
    }
}
