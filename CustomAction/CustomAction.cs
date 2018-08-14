using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;

namespace CustomAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult CustomSetupLibrary(Session session)
        {
            session.Log("Begin CustomSetupLibrary");

            string envName = "FooBar";
            string installFolder = session.CustomActionData["INSTALLFOLDER"];

            if (Environment.GetEnvironmentVariable(envName) == null)
            {
                // If it doesn't exist, create it.
                Environment.SetEnvironmentVariable(envName, installFolder);
            }

            envName = "FooBarInit";
            string anotherValue = session.CustomActionData["AnotherValue"];

            session["MyValue"] = anotherValue == "MyCustomAction" ? "1" : "0";

            if (Environment.GetEnvironmentVariable(envName) == null)
            {
                // If it doesn't exist, create it.
                Environment.SetEnvironmentVariable(envName, session["MyValue"]);
            }

            return ActionResult.Success;
        }
    }
}
