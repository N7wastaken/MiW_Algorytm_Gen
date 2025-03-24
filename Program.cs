using System;
using System.Windows.Forms;
using DywanikReal;

namespace DywanikDebug
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Standardowe WinForms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Globalna obsluga wyjatkow
            Application.ThreadException += (sender, e) =>
            {
                // Blad w okienku zamiast zamkniecia apki przez ex
                MessageBox.Show(
                    "Nieobsłużony wyjątek (ThreadException):\n\n" + e.Exception,
                    "Błąd w wątku UI",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            };


            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                MessageBox.Show(
                    "Nieobsłużony wyjątek (UnhandledException):\n\n" + e.ExceptionObject,
                    "Błąd domeny aplikacji",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            };

            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Wyjątek złapany w Main():\n\n" + ex,
                    "Błąd krytyczny",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
