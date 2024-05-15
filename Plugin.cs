using System;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;

namespace LogKeeper
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class LogKeeperPlugin : BaseUnityPlugin
    {
        internal const string ModName = "LogKeeper";
        internal const string ModVersion = "1.0.1";
        internal const string Author = "Azumatt";
        private const string ModGuid = $"{Author}.{ModName}";
        private const string ConfigFileName = $"{ModGuid}.cfg";
        private static readonly string ConfigFileFullPath = Paths.ConfigPath + Path.DirectorySeparatorChar + ConfigFileName;
        private static readonly string LOGOutputPath = Paths.BepInExRootPath + Path.DirectorySeparatorChar + "LogOutput.log";
        private static readonly string LOGKeeperLogsPath = Paths.BepInExRootPath + Path.DirectorySeparatorChar + "LogKeeperLogs";
        private readonly Harmony _harmony = new(ModGuid);
        private static readonly ManualLogSource LogKeeperLogger = BepInEx.Logging.Logger.CreateLogSource(ModName);
        public void Awake()
        {
            _howManyToKeep = config("1 - General", "How Many To Keep", 5, "How many log files to keep in the LogKeeperLogs folder.");
            Assembly assembly = Assembly.GetExecutingAssembly();
            _harmony.PatchAll(assembly);
            SetupWatcher();
        }

        private void OnDestroy()
        {
            DoTheThing();
        }

        private void OnApplicationQuit()
        {
            DoTheThing();
        }

        private void DoTheThing()
        {
            Config.Save();

            // Check if the LogKeeperLogs directory exists, if not, create it
            if (!Directory.Exists(LOGKeeperLogsPath))
            {
                Directory.CreateDirectory(LOGKeeperLogsPath);
            }

            // Generate the new log file name with the current date and time
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string newLogFileName = $"LogOutput_{timestamp}.log";
            string newLogFilePath = Path.Combine(LOGKeeperLogsPath, newLogFileName);

            // Copy the original log file to the new location with the new name
            File.Copy(LOGOutputPath, newLogFilePath, true);

            // Retrieve all log files in the LogKeeperLogs directory
            string[] logFiles = Directory.GetFiles(LOGKeeperLogsPath, "*.log");

            // Determine the number of files to delete based on the howManyToKeep setting
            int excessFileCount = logFiles.Length - _howManyToKeep.Value;

            if (excessFileCount > 0)
            {
                // Order the files by creation time (oldest first) and select the excess number of files
                var filesToDelete = logFiles.OrderBy(f => new FileInfo(f).CreationTime).Take(excessFileCount);

                // Delete the selected files
                foreach (var file in filesToDelete)
                {
                    File.Delete(file);
                }
            }
        }

        private void SetupWatcher()
        {
            FileSystemWatcher watcher = new(Paths.ConfigPath, ConfigFileName);
            watcher.Changed += ReadConfigValues;
            watcher.Created += ReadConfigValues;
            watcher.Renamed += ReadConfigValues;
            watcher.IncludeSubdirectories = true;
            watcher.SynchronizingObject = ThreadingHelper.SynchronizingObject;
            watcher.EnableRaisingEvents = true;
        }

        private void ReadConfigValues(object sender, FileSystemEventArgs e)
        {
            if (!File.Exists(ConfigFileFullPath)) return;
            try
            {
                LogKeeperLogger.LogDebug("ReadConfigValues called");
                Config.Reload();
            }
            catch
            {
                LogKeeperLogger.LogError($"There was an issue loading your {ConfigFileName}");
                LogKeeperLogger.LogError("Please check your config entries for spelling and format!");
            }
        }


        #region ConfigOptions

        private static ConfigEntry<int> _howManyToKeep = null!;

        private ConfigEntry<T> config<T>(string group, string name, T value, ConfigDescription description)
        {
            ConfigEntry<T> configEntry = Config.Bind(group, name, value, description);

            return configEntry;
        }

        private ConfigEntry<T> config<T>(string group, string name, T value, string description)
        {
            return config(group, name, value, new ConfigDescription(description));
        }

        private class ConfigurationManagerAttributes
        {
            [UsedImplicitly] public int? Order = null!;
            [UsedImplicitly] public bool? Browsable = null!;
            [UsedImplicitly] public string? Category = null!;
            [UsedImplicitly] public Action<ConfigEntryBase>? CustomDrawer = null!;
        }

        #endregion
    }
}