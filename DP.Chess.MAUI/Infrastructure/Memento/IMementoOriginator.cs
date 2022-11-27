namespace DP.Chess.MAUI.Infrastructure.Memento
{
    /// <summary>
    /// Interface that represents an originator in the memento pattern. This
    /// will be the class that will be stored into a <see cref="IMemento" /> object.
    /// </summary>
    /// <typeparam name="T">
    /// The concrete object type of the <see cref="IMemento" /> interface.
    /// </typeparam>
    public interface IMementoOriginator<T> where T : IMemento
    {
        /// <summary>
        /// Takes a memento object and overrides the current state with this object.
        /// </summary>
        /// <param name="memento">
        /// The object that will be used as base for the new state.
        /// </param>
        void RestoreMemento(T memento);

        /// <summary>
        /// Save the current object into a <see cref="IMemento" /> object, that
        /// can be handled by the <see cref="IMementoCaretaker{T}" />.
        /// </summary>
        /// <returns>A new memento object, based on the current state.</returns>
        T SaveMemento();
    }
}