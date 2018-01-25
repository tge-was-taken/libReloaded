﻿using System;
using System.IO;
using System.Reflection;

namespace SonicHeroes.Misc
{
    /// <summary>
    /// Class which helps with the retrieval of a certain folder locations for DLLs such as mods
    /// that are currently injected into a target process.
    /// </summary>
    public static class LoaderPaths
    {
        /// <summary>
        /// Specifies the location of the file which informs injected DLLs of the 
        /// current location of the mod loader in question. 
        /// </summary>
        private static string MOD_LOADER_LINK_FILE = Path.GetTempPath() + "\\Mod-Loader-Link.txt";

        /// <summary>
        /// Specifies the relative location of the main configuration file for the loader.
        /// </summary>
        private static string RELATIVELOCATION_CONFIGFILE = "\\Mod-Loader-Config\\Config.ini";

        /// <summary>
        /// Specifies the relative location of the configuration directory for the loader.
        /// </summary>
        private static string RELATIVELOCATION_CONFIG = "\\Mod-Loader-Config";

        /// <summary>
        /// Specifies the relative location of the individual game backup files relative to the mod loader.
        /// </summary>
        private static string RELATIVELOCATION_BACKUP = "\\Mod-Loader-Backup";

        /// <summary>
        /// Specifies the relative location of the mod loader's mod directory.
        /// </summary>
        private static string RELATIVELOCATION_MODS = "\\Mod-Loader-Mods";

        /// <summary>
        /// Specifies the relative location of the mod loader libraries relative to the mod loader.
        /// </summary>
        private static string RELATIVELOCATION_LIBRARIES = "\\Mod-Loader-Libraries";

        /// <summary>
        /// Specifies the relative location of the mod loader libraries relative to the mod loader.
        /// </summary>
        private static string RELATIVELOCATION_GAMES = "\\Mod-Loader-Config\\Games";

        /// <summary>
        /// Retrieves the directory of the current process where the DLL resides in. i.e. the game directory.
        /// </summary>
        public static string GetProcessDirectory()
        {
            return Environment.CurrentDirectory;
        }


        /// <summary>
        /// Retrieves the directory where the mod DLL (main.dll) is stored.
        /// </summary>
        public static string GetModDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Retrieves the directory of the mod loader itself, useful for reading configuration
        /// files by modifications, mod loader libraries and other programs.
        /// </summary>
        public static string GetModLoaderDirectory()
        {
            return File.ReadAllText(MOD_LOADER_LINK_FILE);
        }

        /// <summary>
        /// Retrieves the location of the text file where the link file to be written which defines the loader location is stored.
        /// </summary>
        public static string GetModLoaderLinkLocation()
        {
            return MOD_LOADER_LINK_FILE;
        }

        /// <summary>
        /// Retrieves the mod loader's main config as an array of strings.
        /// </summary>
        public static string GetModLoaderConfig()
        {
            return GetModLoaderDirectory() + RELATIVELOCATION_CONFIGFILE;
        }

        /// <summary>
        /// Retrieves the mod loader's main config directory.
        /// </summary>
        public static string GetModLoaderConfigDirectory()
        {
            return GetModLoaderDirectory() + RELATIVELOCATION_CONFIG;
        }

        /// <summary>
        /// Retrieves the mod loader's main library directory.
        /// </summary>
        public static string GetModLoaderLibraryDirectory()
        {
            return GetModLoaderDirectory() + RELATIVELOCATION_LIBRARIES;
        }

        /// <summary>
        /// Retrieves the mod loader's game configuration directory.
        /// </summary>
        public static string GetModLoaderGameDirectory()
        {
            return GetModLoaderDirectory() + RELATIVELOCATION_GAMES;
        }

        /// <summary>
        /// Retrieves the mod loader's main mod directory.
        /// </summary>
        public static string GetModLoaderModDirectory()
        {
            return GetModLoaderDirectory() + RELATIVELOCATION_MODS;
        }

        /// <summary>
        /// Returns a path relative to the mod loader directory.
        /// e.g. D:/Stuff/ModLoader/Mod-Loader-Mods => Mod-Loader-Mods
        /// </summary>
        /// <param name="path">The path inside the mod loader configuration.</param>
        public static string GetModLoaderRelativePath(string path)
        {
            // Note: Last character will be a backslash, do not include.
            return path.Substring(GetModLoaderDirectory().Length + 1);
        }

    }
}
