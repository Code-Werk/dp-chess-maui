using System.Text.Json;

namespace DP.Chess.MAUI.Infrastructure.Memento
{
    /// <summary>
    /// Implementation of a persistent memento caretaker interface, that saves
    /// the states into a JSON file.
    /// </summary>
    /// <typeparam name="T">The type of a memento object.</typeparam>
    public class MementoJsonFileCaretaker<T> : IMementoPersistCaretaker<T>
        where T : IMemento
    {
        private readonly PickOptions _filePickerOptions;

        private int _index;
        private IList<T> _mementos;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="MementoJsonFileCaretaker{T}" /> class.
        /// </summary>
        public MementoJsonFileCaretaker()
        {
            _filePickerOptions = new()
            {
                FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] {".json", ".txt"} }
                }),
            };
            _index = -1;
            _mementos = new List<T>();
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public T Current => _mementos[_index];

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void Add(T memento)
        {
            if (_index + 1 < _mementos.Count)
            {
                for (int i = _index + 1; i < _mementos.Count; i++)
                {
                    _mementos.RemoveAt(i);
                }
            }

            _mementos.Add(memento);
            _index++;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void Clear()
        {
            _mementos.Clear();
            _index = -1;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <returns><inheritdoc /></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task LoadMementos()
        {
            FileResult? result = await FilePicker.Default.PickAsync(_filePickerOptions);
            if (result == null)
            {
                return;
            }

            using Stream? stream = await result.OpenReadAsync();
            IList<T>? deserializedSave =
               await JsonSerializer.DeserializeAsync<IList<T>>(stream);

            if (deserializedSave == null)
            {
                throw new ArgumentException("specified save file could not be opened");
            }

            _mementos = deserializedSave;
            _index = _mementos.Count - 1;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <returns><inheritdoc /></returns>
        public T? Redo()
        {
            if (_index + 1 < _mementos.Count)
            {
                _index++;
                return _mementos[_index];
            }
            return default;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <returns><inheritdoc /></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> SaveMementos()
        {
            FileResult? result = await FilePicker.Default.PickAsync(_filePickerOptions);
            // no save file selected (= saving canceled)
            if (result == null)
            {
                return true;
            }

            if (string.IsNullOrEmpty(result.FullPath))
            {
                throw new Exception($"cannot open {result.FullPath}");
            }

            JsonSerializerOptions options = new() { WriteIndented = true };
            using FileStream createStream = File.Create(result.FullPath);
            await JsonSerializer.SerializeAsync(createStream, _mementos, options);
            await createStream.DisposeAsync();

            return true;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        /// <returns><inheritdoc /></returns>
        public T? Undo()
        {
            if (_index > 0)
            {
                _index--;
                return _mementos[_index];
            }
            return default;
        }
    }
}