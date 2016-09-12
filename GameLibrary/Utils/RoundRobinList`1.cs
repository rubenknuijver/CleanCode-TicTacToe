namespace GameLibrary.Utils
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoundRobinList<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _head;

        public RoundRobinList(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public RoundRobinList(IEnumerable<T> items)
        {
            if (items == null || items.Count<T>() == 0) {
                throw new ArgumentException("One or more items must be provided", nameof(items));
            }

            // Copy the list to ensure it doesn't change on us (and so we can lock() on our private copy)
            this._items = items.ToArray();
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            int currentHead;
            lock (this._items) {
                currentHead = this._head++;
                if (this._head == this._items.Length) {
                    // Wrap back to the start
                    this._head = 0;
                }
            }

            // If one just wanted to return 1 endpoint as opposed to a list with
            // backup endpoints this 'yield' is all that would be needed.
            // yield return this.endpoints[currentHead];
            // return results [current] ... [last]
            for (int i = currentHead; i < this._items.Length; i++) {
                yield return this._items[i];
            }

            // return wrap-around (if any) [0] ... [current-1]
            for (int i = 0; i < currentHead; i++) {
                yield return this._items[i];
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
