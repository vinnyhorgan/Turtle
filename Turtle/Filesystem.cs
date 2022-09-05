using System;
using System.IO;

namespace Turtle
{
    /// <summary>
    /// Provides an interface to the user's filesystem.
    /// </summary>
    public static class Filesystem
    {
        // Functions

        /// <summary>
        /// Append data to an existing file.
        /// </summary>
        /// <param name="name">The name (and path) of the file.</param>
        /// <param name="data">The string data to append to the file.</param>
        public static void Append(string name, string data)
        {
            File.AppendAllText(name, data);
        }

        /// <summary>
        /// Creates a directory.
        /// </summary>
        /// <param name="name">The directory to create.</param>
        public static void CreateDirectory(string name)
        {
            Directory.CreateDirectory(name);
        }

        /// <summary>
        /// Returns the application data directory (could be the same as getUserDirectory).
        /// </summary>
        /// <returns>The path of the application data directory.</returns>
        public static string GetAppdataDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }

        /// <summary>
        /// Returns all the files and subdirectories in the directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        /// <returns>An array with the names of all files and subdirectories as strings.</returns>
        public static string[] GetDirectoryItems(string directory)
        {
            return Directory.GetFileSystemEntries(directory);
        }

        /// <summary>
        /// Gets information about the specified file or directory.
        /// </summary>
        /// <param name="path">The file or directory path to check.</param>
        /// <returns>A PathInfo object.</returns>
        public static PathInfo GetInfo(string path)
        {
            PathInfo info = new();

            FileAttributes attributes = File.GetAttributes(path);

            switch (attributes)
            {
                case FileAttributes.Directory:
                    if (Directory.Exists(path))
                    {
                        info.Exists = true;

                        if (new DirectoryInfo(path).Attributes.HasFlag(FileAttributes.ReparsePoint))
                        {
                            info.Type = FileType.Symlink;
                        }
                        else
                        {
                            info.Type = FileType.Directory;
                        }
                    }
                    else
                    {
                        info.Exists = false;
                    }
                    break;
                default:
                    if (File.Exists(path))
                    {
                        info.Exists = true;
                        info.ModTime = File.GetLastWriteTime(path);
                        info.Size = new FileInfo(path).Length;

                        if (new FileInfo(path).Attributes.HasFlag(FileAttributes.ReparsePoint))
                        {
                            info.Type = FileType.Symlink;
                        }
                        else
                        {
                            info.Type = FileType.File;
                        }
                    }
                    else
                    {
                        info.Exists = false;
                    }
                    break;
            }

            return info;
        }

        /// <summary>
        /// Gets the absolute path of the directory containing a filepath.
        /// </summary>
        /// <param name="path">The path to get the directory of.</param>
        /// <returns>The full path of the directory containing the path.</returns>
        public static string GetRealDirectory(string path)
        {
            return Path.GetFullPath(path);
        }

        /// <summary>
        /// Returns the path of the user's directory.
        /// </summary>
        /// <returns>The path of the user's directory.</returns>
        public static string GetUserDirectory()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        }

        /// <summary>
        /// Gets the current working directory.
        /// </summary>
        /// <returns>The current working directory.</returns>
        public static string GetWorkingDirectory()
        {
            return Directory.GetCurrentDirectory();
        }

        /// <summary>
        /// Iterate over the lines in a file.
        /// </summary>
        /// <param name="name">The name(and path) of the file</param>
        /// <returns>An array containing all the lines in the file.</returns>
        public static string[] Lines(string name)
        {
            return File.ReadAllLines(name);
        }

        /// <summary>
        /// Read the contents of a file.
        /// </summary>
        /// <param name="name">The name (and path) of the file.</param>
        /// <returns>The file contents.</returns>
        public static string Read(string name)
        {
            return File.ReadAllText(name);
        }

        /// <summary>
        /// Removes a file (or directory).
        /// </summary>
        /// <param name="name">The file or directory to remove.</param>
        public static void Remove(string name)
        {
            FileAttributes attributes = File.GetAttributes(name);

            switch (attributes)
            {
                case FileAttributes.Directory:
                    if (Directory.Exists(name))
                    {
                        Directory.Delete(name, true);
                    }
                    break;
                default:
                    if (File.Exists(name))
                    {
                        File.Delete(name);
                    }
                    break;
            }
        }

        /// <summary>
        /// Write data to a file.
        /// </summary>
        /// <param name="name">The name (and path) of the file.</param>
        /// <param name="data">The string data to write to the file.</param>
        public static void Write(string name, string data)
        {
            File.WriteAllText(name, data);
        }
    }
}