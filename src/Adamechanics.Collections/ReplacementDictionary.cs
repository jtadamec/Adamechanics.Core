using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adamechanics.Collections
{
    /// <summary>
    /// Defines a collection of replacement strings and their substitution values
    /// </summary>
    public class ReplacementDictionary : IDictionary<string, string>
    {
        /// <summary>
        /// Constructs a new <see cref="ReplacementDictionary"/>
        /// </summary>
        /// <param name="opening">The opening characters of a replacement key</param>
        /// <param name="closing">The closing characters of a replacement key</param>
        /// <exception cref="ArgumentException">One of the provided arguments was a <see langword="null"/> or entirely whitespace string</exception>
        public ReplacementDictionary(string opening, string closing)
        {
            if (string.IsNullOrEmpty(opening))
            {
                throw new ArgumentException($"'{nameof(opening)}' cannot be null or empty.", nameof(opening));
            }

            if (string.IsNullOrEmpty(closing))
            {
                throw new ArgumentException($"'{nameof(closing)}' cannot be null or empty.", nameof(closing));
            }

            Opening = opening;
            Closing = closing;
            Dictionary = new Dictionary<string, string>();
        }   

        /// <summary>
        /// The opening character sequence for the keys contained in this instance
        /// </summary>
        public string Opening { get; }

        /// <summary>
        /// The closing character sequence for the keys contained in this instance
        /// </summary>
        public string Closing { get; }

        /// <summary>
        /// The underlying dictionary
        /// </summary>
        private Dictionary<string,string> Dictionary { get; }

        /// <summary>
        /// Formats the provided value into a key suitable for use in the calling instance
        /// </summary>
        /// <param name="raw">The raw value to be made into a replacement key</param>
        protected string MakeKey(string raw) => string.Concat(Opening, raw, Closing);

        #region IDictionary

        /// <inheritdoc/>
        public int Count => Dictionary.Count;

        /// <inheritdoc/>
        public bool IsReadOnly => false;

        /// <inheritdoc/>
        public string this[string key] 
        {
            get
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(key);
                return Dictionary[MakeKey(key)];
            }
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(key);
                Dictionary[MakeKey(key)] = value;
            }
        }

        /// <inheritdoc/>
        public void Add(string key, string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            Dictionary.Add(MakeKey(key), value);
        }

        /// <inheritdoc/>
        public bool ContainsKey(string key)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            return Dictionary.ContainsKey(MakeKey(key));
        }

        /// <inheritdoc/>
        public bool Remove(string key)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            return Dictionary.Remove(MakeKey(key));
        }

        /// <inheritdoc/>
        public void Clear() => Dictionary.Clear();

        /// <inheritdoc/>
        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            return Dictionary.TryGetValue(MakeKey(key), out value);
        }

        #region Explicit Interface Implementations 

        /// <inheritdoc/>
        void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item)
        {
            ((ICollection<KeyValuePair<string, string>>)Dictionary).Add(item);
        }

        /// <inheritdoc/>
        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item)
        {
            return ((ICollection<KeyValuePair<string, string>>)Dictionary).Contains(item);
        }

        /// <inheritdoc/>
        void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, string>>)Dictionary).CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item)
        {
            return ((ICollection<KeyValuePair<string, string>>)Dictionary).Remove(item);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, string>>)Dictionary).GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Dictionary).GetEnumerator();
        }

        /// <inheritdoc/>
        ICollection<string> IDictionary<string,string>.Keys => Dictionary.Keys;

        /// <inheritdoc/>
        ICollection<string> IDictionary<string,string>.Values => Dictionary.Values;

        #endregion

        #endregion
    }
}
