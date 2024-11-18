namespace TableLookGame{

    public partial class Game: TableGame<Label>
    {
        
        public Game()
        {
            InitializeComponent();
            // StartGame();
        }
    }    

    internal static class ProgramXXXX
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
/*             TableGame<Label> TableGame1 = new TableGame<Label> {
                GameParams = 
                {
                    MaxCount = 4,
                    RuleParams = 4,
                    ResetInterval = 850            
                }
            }; */

            // Form1 FormGame = new Form1();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            ApplicationConfiguration.Initialize(); //calibrate the graphic parameter to good

            // Application.Run(TableGame1);
            // Application.Run(new Form1());
            Application.Run(new Game());

        }
    }    
}



                // GameParams = 
                // {
                //     MaxCount = 4,
                //     RuleParams = 4,
                //     ResetInterval = 850            
                // }}