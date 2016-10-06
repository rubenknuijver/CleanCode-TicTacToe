namespace GameLibrary.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class CommandManager
    {
        private readonly Stack<ICommand> _undos = new Stack<ICommand>();
        private readonly Stack<ICommand> _redos = new Stack<ICommand>();

        public void ExecuteCommand(ICommand c)
        {
            c.Execute();
            this._undos.Push(c);
            this._redos.Clear();
        }

        public bool IsUndoAvailable()
        {
            return this._undos.Peek() != null;
        }

        public void Undo()
        {
            Debug.Assert(this.IsUndoAvailable());
            ICommand command = this._undos.Pop();
            command.Undo();
            this._redos.Push(command);
        }

        public bool IsRedoAvailable()
        {
            return this._redos.Count > 0;
        }

        public void Redo()
        {
            Debug.Assert(this.IsRedoAvailable());
            ICommand command = this._redos.Pop();
            command.Execute();
            this._undos.Push(command);
        }
    }
}
