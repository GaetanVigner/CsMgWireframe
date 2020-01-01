using System;
using WireFrame.Abstract;

namespace WireFrame.Commands
{
    class CommandUp : Command
    {
        public override void Execute(Map map)
        {
            Console.WriteLine("UP");
            map.Up();
        }
    }
}
