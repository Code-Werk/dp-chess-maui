namespace DP.Chess.MAUI.Infrastructure.Memento
{
    /// <summary>
    /// Specialized interface of the memento caretaker, that ca persist the
    /// current states.
    /// </summary>
    /// <typeparam name="T">The specific type of the memento object.</typeparam>
    public interface IMementoPersistCaretaker<T> : IMementoCaretaker<T> where T : IMemento
    {
        /// <summary>
        /// Method for loading the states of previous saved mementos.
        /// </summary>
        Task LoadMementos();

        /// <summary>
        /// Method for saving the current states of a caretaker.
        /// </summary>
        /// <returns>
        /// True if the save process was executed successfully. False if an
        /// error happened.
        /// </returns>
        Task<bool> SaveMementos();
    }
}