// namespace MatchingGame
namespace TableLookGame
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main111()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            // ApplicationConfiguration.Initialize(); //calibrate the graphic parameter to good - why error not exist

            Application.Run(new Form1());
            
        }
    }
}