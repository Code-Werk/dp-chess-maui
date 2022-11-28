namespace DP.Chess.MAUI.Infrastructure.Memento
{
    /// <summary>
    /// Interface that represents a caretaker in the memento pattern. The
    /// caretaker manages multiple states of a specific memento object.
    /// </summary>
    /// <typeparam name="T">The specific type of the memento object.</typeparam>
    public interface IMementoCaretaker<T>
        where T : IMemento
    {
        /// <summary>
        /// Gets the current state as a memento object.
        /// </summary>
        T Current { get; }

        /// <summary>
        /// Adds a memento object to the list of managed memento states.
        /// </summary>
        /// <param name="memento">The memento object that should be added</param>
        void Add(T memento);

        /// <summary>
        /// Method to reset the caretaker to a new state.
        /// </summary>
        void Clear();

        /// <summary>
        /// Method that sets the <see cref="Current" /> memento to the memento
        /// after and returns the new current.
        /// </summary>
        /// <returns>
        /// The memento after the <see cref="Current" /> one. If the
        /// <see cref="Current" /> is the last added memento, null will be returned.
        /// </returns>
        T? Redo();

        /// <summary>
        /// Method that sets the <see cref="Current" /> memento to the memento
        /// before and that returns the new current.
        /// </summary>
        /// <returns>
        /// The memento before the <see cref="Current" /> one. If the
        /// <see cref="Current" /> is the first added memento, null will be returned.
        /// </returns>
        T? Undo();
    }
}