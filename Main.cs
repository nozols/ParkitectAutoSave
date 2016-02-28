using System;
using System.IO;
using UnityEngine;

namespace AutoSave
{
    public class Main : IMod, IModSettings
    {
        private GameObject __go;
        public static int _timeInterval;
        private string _timeString;
        private string _previousTimeString;

        public string Description
        {
            get
            {
                return "Enables autosave";
            }
        }

        public string Name
        {
            get
            {
                return "AutoSave";
            }
        }

        public void onDisabled()
        {
            UnityEngine.Object.Destroy(__go);
        }

        public void onEnabled()
        {
            string pathToFile = Path + @"/seconds.txt";
            bool createFile = true;
            if (File.Exists(pathToFile)) {
                createFile = false;
                try
                {
                    using (StreamReader sr = new StreamReader(pathToFile))
                    {
                        string line = sr.ReadToEnd();
                        int value;
                        bool parsed = int.TryParse(line, out value);
                        if (parsed)
                        {
                            _timeInterval = value;
                        }
                        else {
                            Debug.Log("Corrupted file! Deleting...");
                            File.Delete(pathToFile);
                            createFile = true;
                        }
                    }
                }
                catch (Exception e) {
                    Debug.Log(e);
                    _timeInterval = 300;
                }
            }
            if(createFile)
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(pathToFile))
                    {
                        sw.WriteLine(300);
                    }
                }
                catch (Exception e) {
                    Debug.Log(e);
                }
                _timeInterval = 300;

            }

            _timeString = _timeInterval.ToString();
            _previousTimeString = _timeString;
            __go = new GameObject();
            __go.AddComponent<AutoSaveBehaviour>();
        }

        public void onDrawSettingsUI()
        {
            
            GUILayout.BeginHorizontal();
            GUILayout.Label("Save every");
            _timeString = GUILayout.TextField(_timeString);
            GUILayout.Label("seconds");
            GUILayout.EndHorizontal();
            if (GUILayout.Button("Reset to default"))
            {
                _timeString = 300.ToString();
            }
            GUILayout.BeginHorizontal();
            GUILayout.Label("Please enter the interval between saves in seconds. 1 minute equals 60 seconds. Default is 300 seconds (5 minutes)");
            GUILayout.EndHorizontal();
        }

        public void onSettingsOpened()
        {
            
        }

        public void onSettingsClosed()
        {
            string pathToFile = Path + @"/seconds.txt";
            if (_previousTimeString != _timeString) {

                int value;
                bool parsed = int.TryParse(_timeString, out value);

                if (parsed) {
                    if (value >= 10) {
                        _timeInterval = value;

                        try
                        {
                            using (StreamWriter sw = new StreamWriter(pathToFile))
                            {
                                sw.WriteLine(_timeInterval);
                            }
                            _previousTimeString = _timeString;

                        }catch(Exception e)
                        {
                            Debug.Log(e);
                        }

                    }
                }
                else{
                    _timeString = _previousTimeString;
                }
            }
        }

        public string Identifier { get; set; }

        public string Path { get; set; }
    }
}
