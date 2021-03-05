using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace XP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                string resource1 = "XP.Ionic.Zip.dll";
                
                EmbeddedAssembly.Load(resource1, "Ionic.Zip.dll");
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            } catch (Exception e)
            {
                MessageBox.Show("Unable to run workshop: " + e.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}