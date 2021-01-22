using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace TestTaskCRT.Encryption
{
    public sealed class Vigener
    {
        private readonly string _alphabeth;


        private readonly Regex _regex;


        public Vigener()
        {
            _alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            _regex = new Regex("^[A-Z]+$");
        }


        public string Encrypt(string source, string key)
        {
            if (_regex.IsMatch(source) && _regex.IsMatch(key))
            {
                int maxLength = Math.Max(source.Length, key.Length);

                string result = "";

                for (int i = 0; i < maxLength; i++)
                {
                    int sourceIndex = _alphabeth.IndexOf(source[i % source.Length]);
                    int keyIndex = _alphabeth.IndexOf(key[i % key.Length]);

                    result += _alphabeth[(sourceIndex + keyIndex) % _alphabeth.Length];
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Source or key contains characters outside the alphabeth");
            }
        }


        public string Decrypt(string encrypted, string key)
        {
            if (_regex.IsMatch(encrypted) && _regex.IsMatch(key))
            {
                int maxLength = Math.Max(encrypted.Length, key.Length);

                string result = "";

                for (int i = 0; i < maxLength; i++)
                {
                    int encryptedIndex = _alphabeth.IndexOf(encrypted[i % encrypted.Length]);
                    int keyIndex = _alphabeth.IndexOf(key[i % key.Length]);

                    result += _alphabeth[(encryptedIndex + _alphabeth.Length - keyIndex) % _alphabeth.Length];
                }

                return result;
            }
            else
            {
                throw new ArgumentException("Source or key contains characters outside the alphabeth");
            }
        }


        public IEnumerable<string> Encrypt(IEnumerable<string> source, string key)
        {
            return source.Select(s => Encrypt(s, key));
        }


        public IEnumerable<string> Decrypt(IEnumerable<string> encrypted, string key)
        {
            return encrypted.Select(s => Decrypt(s, key));
        }
    }
}
