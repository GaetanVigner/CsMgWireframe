using InputMgr.Abstract;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace InputMgr
{
    public class InputManager<T>
    {
        private Dictionary<Keys, Command<T>> KeyBindingsKeyboard;
        private Dictionary<Buttons, Command<T>> KeyBindingsController;

        public InputManager(Dictionary<Keys, Command<T>> _keyBindingsKeyboard,
            Dictionary<Buttons, Command<T>> _keyBindingsController)
        {
            KeyBindingsKeyboard = _keyBindingsKeyboard;
            KeyBindingsController = _keyBindingsController;
        }

        public void HandleInput(T arg)
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();
            foreach (Keys key in pressed)
            {
                if (KeyBindingsKeyboard.ContainsKey(key))
                {
                    KeyBindingsKeyboard[key].Execute(arg);
                }
            }
            //TODO : add controller supprt
        }
    }
}
