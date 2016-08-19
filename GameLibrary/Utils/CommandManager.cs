using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Utils
{

    public class CommandManager
    {

        private Stack<ICommand> _undos = new Stack<ICommand>();
        private Stack<ICommand> _redos = new Stack<ICommand>();

        public void executeCommand(ICommand c)
        {
            c.Execute();
            _undos.Push(c);
            _redos.Clear();
        }

        public bool IsUndoAvailable()
        {
            return _undos.Peek() != null;
        }

        public void undo()
        {
            Debug.Assert(IsUndoAvailable());
            ICommand command = _undos.Pop();
            command.Undo();
            _redos.Push(command);
        }

        public bool isRedoAvailable()
        {
            return _redos.Count > 0;
        }

        public void redo()
        {
            Debug.Assert(isRedoAvailable());
            ICommand command = _redos.Pop();
            command.Execute();
            _undos.Push(command);
        }
    }

}
