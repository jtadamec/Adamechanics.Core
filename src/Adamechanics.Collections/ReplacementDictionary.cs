using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adamechanics.Collections
{
    public class ReplacementDictionary : IDictionary<string, string>
    {
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

        public int Count => Dictionary.Count;

        public bool IsReadOnly => false;

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

        public void Add(string key, string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            Dictionary.Add(MakeKey(key), value);
        }

        public bool ContainsKey(string key)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            return Dictionary.ContainsKey(MakeKey(key));
        }

        public bool Remove(string key)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            return Dictionary.Remove(MakeKey(key));
        }

        public void Clear() => Dictionary.Clear();

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(key);
            return Dictionary.TryGetValue(MakeKey(key), out value);
        }

        #region Explicit Interface Implementations 

        void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item)
        {
            ((ICollection<KeyValuePair<string, string>>)Dictionary).Add(item);
        }

        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item)
        {
            return ((ICollection<KeyValuePair<string, string>>)Dictionary).Contains(item);
        }

        void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            ((ICollection<KeyValuePair<string, string>>)Dictionary).CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item)
        {
            return ((ICollection<KeyValuePair<string, string>>)Dictionary).Remove(item);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, string>>)Dictionary).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Dictionary).GetEnumerator();
        }

        ICollection<string> IDictionary<string,string>.Keys => Dictionary.Keys;

        ICollection<string> IDictionary<string,string>.Values => Dictionary.Values;

        #endregion

        #endregion
    }
}
