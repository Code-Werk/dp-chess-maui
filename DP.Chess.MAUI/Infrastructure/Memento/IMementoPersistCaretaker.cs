namespace DP.Chess.MAUI.Infrastructure.Memento
{
    /// <summary>
    /// Specialized interface of the memento caretaker, that can persist the
    /// current states.
    /// </summary>
    /// <typeparam name="T">The specific type of the memento object.</typeparam>
    public interface IMementoPersistCaretaker<T> : IMementoCaretaker<T>
        where T : IMemento
    {
        /// <summary>
        /// Method for loading the states of previous saved mementos.
        /// </summary>
        /// <returns>The finished task.</returns>
        Task LoadMementos();

        /// <summary>
        /// Method for saving the current states of a caretaker.
        /// </summary>
        /// <returns>
        /// The finished task containing true if the save process
        /// was executed successfully, otherwise false.
        /// </returns>
        Task<bool> SaveMementos();
    }
}