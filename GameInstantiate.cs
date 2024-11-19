namespace MatchingGame{
    using System.Windows.Forms;

    public partial class Game: TableGame<Label>
    {
        public Game(int maxCount, int ruleParams, int resetInterval)
        {

            // TGameLogic GameLogicProps = new TGameLogic(maxCount,ruleParams,resetInterval);
            BaseGameLogic GameLogicProps = new TableGameLogic
            {
                GameMechanics = new TableGameMechanics{},
                GameRuleConfig = new TGameRuleConfig{ProcessSelection=ProcessSelectionImp, Reset=ResetImp, RuleSet=RuleImp},
                GameParams = new GameProps{Params = new Props{MaxCount=maxCount, ResetInterval=resetInterval, RuleParams=ruleParams}},
                GameState = new GameState<Label>()
            };
            GameLogic = GameLogicProps;

            InitializeComponent(); //must after props assigned because the mistake-prone use 'outside' variable in form design context             
            GameLogic.Timer = timer1;
            var timer = GameLogic.Timer; //must assign after get method
            timer.Interval = GameLogic.GameParams.Params.ResetInterval;
            timer.Tick += GameLogic.TimerEvent;
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            ApplicationConfiguration.Initialize(); //calibrate the graphic parameter to good

            // Application.Run(TableGame1);
            // Application.Run(new Form1());

           
            Application.Run(new Game(4,4,3400));

        }
    }    
}

