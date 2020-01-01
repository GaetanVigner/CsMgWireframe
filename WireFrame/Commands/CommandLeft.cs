using System;
using WireFrame.Abstract;

namespace WireFrame.Commands
{
    class CommandLeft : Command
    {
        public override void Execute(Map map)
        {
            Console.WriteLine("Left");
            map.Left();
        }
    }
}
