using System;
using System.ComponentModel;
using xiApi.NET;
using xiApi;
using System.Collections.Generic;
using System.Reactive;
using System.IO;
using System.Linq;

namespace Bonsai.Ximea
{
    [Description("Configures and initializes a custom instance of a XimeaCapture operator. It will set/get the specified settings and dump to a log file.")]
    public class CustomXimeaCapture : XimeaCapture
    {
        public string logFilePath = "log.txt";

        [Description("The name of the output log file.")]
        [Editor("Bonsai.Design.SaveFileNameEditor, Bonsai.Design", DesignTypes.UITypeEditor)]
        public string LogFilePath
        {
            get { return logFilePath; }
            set { logFilePath = value; }
        }

        protected override void Configure(xiCam camera)
        {
            //Set additional parameters
            try
            {
                camera.SetParam(PRM.SHUTTER_TYPE, SHUTTER_TYPE.SHUTTER_GLOBAL);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            base.Configure(camera);

            //Query and export settings
            ExportSettings(camera, LogFilePath);
        }

        private static void ExportSettings(xiCam camera, string logFilePath)
        {
            var settings = new Dictionary<string, int>
            {
                {"Width", QueryParam(camera, PRM.WIDTH) },
                {"Height", QueryParam(camera, PRM.HEIGHT) },
                {"ShutterType", QueryParam(camera, PRM.SHUTTER_TYPE) },

            };
            File.WriteAllLines(logFilePath,
                settings.Select(x => x.Key + "," + x.Value).ToArray());
        }

        private static int QueryParam(xiCam camera, string prm)
        {
            camera.GetParam(prm, out int val);
            return val;
        }
    }
}
