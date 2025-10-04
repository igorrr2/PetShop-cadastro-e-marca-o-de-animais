using System;

namespace Util.Criptografia
{
    public struct ShortGuid
    {
        private readonly Guid _guid;

        public ShortGuid(Guid guid)
        {
            _guid = guid;
        }

        public ShortGuid(string shortGuid)
        {
            _guid = FromShortGuid(shortGuid);
        }

        public Guid Guid => _guid;

        /// <summary>
        /// Converte Guid → ShortGuid (string Base64).
        /// </summary>
        private static string ToShortGuid(Guid guid)
        {
            string encoded = Convert.ToBase64String(guid.ToByteArray());
            encoded = encoded.Replace("/", "_").Replace("+", "-"); // URL safe
            return encoded.Substring(0, 22); // remove "=="
        }

        /// <summary>
        /// Converte ShortGuid (string Base64) → Guid.
        /// </summary>
        private static Guid FromShortGuid(string shortGuid)
        {
            string value = shortGuid.Replace("_", "/").Replace("-", "+") + "==";
            byte[] bytes = Convert.FromBase64String(value);
            return new Guid(bytes);
        }

        public override string ToString() => ToShortGuid(_guid);

        // Conversões implícitas
        public static implicit operator Guid(ShortGuid shortGuid) => shortGuid._guid;
        public static implicit operator ShortGuid(Guid guid) => new ShortGuid(guid);
        public static implicit operator string(ShortGuid shortGuid) => shortGuid.ToString();
        public static implicit operator ShortGuid(string shortGuid) => new ShortGuid(shortGuid);
    }
}
