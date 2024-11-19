namespace MatchingGame{
    using System.Windows.Forms;
    
    public class GameState<T>{
        public T Selection {get;set;}
        public T[] Selections {get;set;} = new T[4];
        public int SolveCount {get;set;}
        public int SelectionCount {get;set;}
    }
    //use class refernce type cannot use struct a value type cannot access sole properties

    public partial class TableGame<T>: BaseTableGame<T,GameState<T>> where T: Control{
        //   protected Timer timer=new();
        protected GameState<T> gameState;

        public class TableGameLogic: BaseGameLogic{
            public override void StateUseSelection(GameState<T> GameState, T selection){
                GameState.Selection = selection;
            }

            public override void StateReset (GameState<T> GameState)
            {
                var selections = GameState.Selections;
                for (int k = 0; k < selections.Length; k++)
                {
                    if (selections[k] != null)
                    {
                        selections[k] = default(T);
                    }
                }
                GameState.SelectionCount = 0;
            }


            public override void PlayEventImp (object? sender, EventArgs e)
            {
                bool check = false;
                var timer = GameMechanics.timer;
                var RuleSet = GameRuleConfig.RuleSet;
                var Reset = GameRuleConfig.Reset;
                var ProcessSelection = GameRuleConfig.ProcessSelection;
                if (sender is T selection)
                {
                    StateUseSelection(GameState, selection);
                    var pause = GameMechanics.PlaySelection(ProcessSelection,GameState,GameParams);
                    if (pause)
                    {
                        check = RuleSet(GameState);
                        if (check)
                        {
                            // timer.Stop();
                            GameState.SolveCount += 1;
                            if (GameState.SolveCount == GameParams.Params.MaxCount)
                            {
                                    MessageBox.Show("You Win");
                            }                            
                        } else
                        {
                            Reset(GameState);
                        }                        

                        // GameMechanics.TimerEvent;
                    }
                }
                var stop = GameRuleConfig.ProcessTimer(timer, GameState, check);
                if (stop) StateReset(GameState);  //Reset and StateReset look conflict prone !!!                  
            }

            public override void TimerEventImp(object? sender, EventArgs e)
            {
                var Reset = GameRuleConfig.Reset;                 
                if (sender is Timer timer)
                {
                    timer.Stop();
                    Reset(GameState);
                    StateReset(GameState);  //Reset and StateReset look conflict prone !!!                    
                }
            }
        }

        public class TableGameMechanics: BaseGameMechanics
        {

            public override bool SetStateOnSelection(GameState<T> GameState, IGameParams GameParams)
            {
                GameState.Selections[GameState.SelectionCount]=GameState.Selection;                   
                GameState.SelectionCount += 1;
                if (GameState.SelectionCount == GameParams.Params.RuleParams)
                {
                    GameState.SelectionCount = 0;
                    return true;
                } else
                {
                    return false;
                }
            }
        }
    }
}