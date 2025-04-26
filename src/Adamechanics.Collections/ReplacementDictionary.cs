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
        }

        public string this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// The opening character sequence for the keys contained in this instance
        /// </summary>
        public string Opening { get; }

        /// <summary>
        /// The closing character sequence for the keys contained in this instance
        /// </summary>
        public string Closing { get; }

        /// <summary>
        /// Formats the provided value into a key suitable for use in the calling instance
        /// </summary>
        /// <param name="raw">The raw value to be made into a replacement key</param>
        protected string MakeKey(string raw) => string.Concat(Opening, raw, Closing);

        #region IDictionary

        public ICollection<string> Keys => throw new NotImplementedException();

        public ICollection<string> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(string key, string value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out string value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
