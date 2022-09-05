using Newtonsoft.Json;

using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace Turtle
{
    /// <summary>
    /// Provides functionality for creating and transforming data.
    /// </summary>
    public static class Data
    {
        // Functions

        /// <summary>
        /// Compresses a string using a specific compression algorithm.
        /// </summary>
        /// <param name="format">The format to use when compressing the string.</param>
        /// <param name="text">The raw (un-compressed) string to compress.</param>
        /// <returns>Compressed string which contains the compressed version of rawstring.</returns>
        public static byte[] Compress(CompressedDataFormat format, string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            byte[] compressed = Array.Empty<byte>();

            switch (format)
            {
                case CompressedDataFormat.Brotli:
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var brotliStream = new BrotliStream(memoryStream, CompressionLevel.Optimal))
                        {
                            brotliStream.Write(bytes, 0, bytes.Length);
                        }

                        compressed = memoryStream.ToArray();
                    }
                    break;
                case CompressedDataFormat.GZip:
                    using (var memoryStream = new MemoryStream())
                    {
                        using (var gzipStream = new GZipStream(memoryStream, CompressionLevel.Optimal))
                        {
                            gzipStream.Write(bytes, 0, bytes.Length);
                        }

                        compressed = memoryStream.ToArray();
                    }
                    break;
            }

            return compressed;
        }

        /// <summary>
        /// Decode Data or a string from any of the EncodeFormats to string.
        /// </summary>
        /// <param name="format">The format of the input data.</param>
        /// <param name="text">The raw (encoded) data to decode.</param>
        /// <returns>String which contains the decoded version of source.</returns>
        public static string Decode(EncodeFormat format, string text)
        {
            string decoded = "";

            switch (format)
            {
                case EncodeFormat.Base64:
                    byte[] base64Bytes = Convert.FromBase64String(text);
                    decoded = Encoding.UTF8.GetString(base64Bytes);
                    break;
                case EncodeFormat.Hex:
                    byte[] hexBytes = Convert.FromHexString(text);
                    decoded = Encoding.UTF8.GetString(hexBytes);
                    break;
            }

            return decoded;
        }

        /// <summary>
        /// Decompresses a compressed string.
        /// </summary>
        /// <param name="format">The format to use when compressing the string.</param>
        /// <param name="bytes">The compressed data to decompress.</param>
        /// <returns>String containing the raw decompressed data.</returns>
        public static string Decompress(CompressedDataFormat format, byte[] bytes)
        {
            byte[] decompressed = Array.Empty<byte>();

            switch (format)
            {
                case CompressedDataFormat.Brotli:
                    using (var memoryStream = new MemoryStream(bytes))
                    {
                        using (var outputStream = new MemoryStream())
                        {
                            using (var decompressStream = new BrotliStream(memoryStream, CompressionMode.Decompress))
                            {
                                decompressStream.CopyTo(outputStream);
                            }

                            decompressed = outputStream.ToArray();
                        }
                    }
                    break;
                case CompressedDataFormat.GZip:
                    using (var memoryStream = new MemoryStream(bytes))
                    {
                        using (var outputStream = new MemoryStream())
                        {
                            using (var decompressStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                            {
                                decompressStream.CopyTo(outputStream);
                            }

                            decompressed = outputStream.ToArray();
                        }
                    }
                    break;
            }

            return Encoding.UTF8.GetString(decompressed);
        }

        /// <summary>
        /// Encode string to a string in one of the EncodeFormats.
        /// </summary>
        /// <param name="format">The format of the output data.</param>
        /// <param name="text">The raw data to encode.</param>
        /// <returns>String which contains the encoded version of source.</returns>
        public static string Encode(EncodeFormat format, string text)
        {
            string encoded = "";

            switch (format)
            {
                case EncodeFormat.Base64:
                    byte[] base64Bytes = Encoding.UTF8.GetBytes(text);
                    encoded = Convert.ToBase64String(base64Bytes);
                    break;
                case EncodeFormat.Hex:
                    byte[] hexBytes = Encoding.UTF8.GetBytes(text);
                    encoded = Convert.ToHexString(hexBytes);
                    break;
            }

            return encoded;
        }

        /// <summary>
        /// Compute message digest using specific hash algorithm.
        /// </summary>
        /// <param name="function">Hash algorithm to use.</param>
        /// <param name="text">String to hash.</param>
        /// <returns>Raw message digest string.</returns>
        public static string Hash(HashFunction function, string text)
        {
            HashAlgorithm algorithm;

            switch (function)
            {
                case HashFunction.Md5:
                    algorithm = MD5.Create();
                    break;
                case HashFunction.Sha1:
                    algorithm = SHA1.Create();
                    break;
                case HashFunction.Sha256:
                    algorithm = SHA256.Create();
                    break;
                case HashFunction.Sha384:
                    algorithm = SHA384.Create();
                    break;
                case HashFunction.Sha512:
                    algorithm = SHA512.Create();
                    break;
                default:
                    algorithm = MD5.Create();
                    break;
            }

            byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sb = new();

            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Packs (serializes) C# objects.
        /// </summary>
        /// <param name="obj">The value to serialize.</param>
        /// <returns>String which contains the serialized data.</returns>
        public static string Pack(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Unpacks (deserializes) a string into a C# object.
        /// </summary>
        /// <typeparam name="T">The type of the deserialized object</typeparam>
        /// <param name="serialized">A string containing the packed (serialized) data.</param>
        /// <returns>The object that was unpacked.</returns>
        public static T? Unpack<T>(string serialized)
        {
            return JsonConvert.DeserializeObject<T>(serialized);
        }
    }
}