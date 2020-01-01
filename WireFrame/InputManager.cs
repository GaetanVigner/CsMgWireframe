using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using WireFrame.Abstract;

namespace WireFrame
{
    public class InputManager
    {
        private Dictionary<Keys, Command> KeyBindingsKeyboard;
        private Dictionary<Buttons, Command> KeyBindingsController;

        public InputManager(Dictionary<Keys, Command> _keyBindingsKeyboard,
            Dictionary<Buttons, Command> _keyBindingsController)
        {
            KeyBindingsKeyboard = _keyBindingsKeyboard;
            KeyBindingsController = _keyBindingsController;
        }

        public void HandleInput(List<Map> maps)
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressed)
            {
                if (KeyBindingsKeyboard.ContainsKey(key))
                {
                    KeyBindingsKeyboard[key].Execute(maps.FirstOrDefault());
                }
            }
            //TODO : add controller supprt
        }
    }
}
