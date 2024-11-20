namespace MatchingGame{
    using System.Windows.Forms;
    
    public class GameState<T>{
        public T Selection {get;set;}
        public T[] Selections {get;set;} = new T[4];
        public int SolveCount {get;set;}
        public int SelectionCount {get;set;}
        public bool Locked {get;set;}
    }
    //use class reference type cannot use struct a value type cannot access sole properties

    public partial class TableGame<T>: BaseTableGame<T,GameState<T>> where T: Control{
        protected GameState<T> gameState;

        public class TableGameLogic: BaseGameLogic{
            public override void StateUseSelection(GameState<T> GameState, T selection)
            {
                GameState.Selection = selection;
            }
        }

        public class TableGameMechanics: BaseGameMechanics
        {
            public override (bool pause, int selectionCount) PlaySelectionImp (IGameRuleConfig<T,GameState<T>> GameRuleConfig, GameState<T> GameState, IGameParams GameParams)
            {
                if (!GameState.Locked)
                {
                    var selection = GameState.Selection;
                    var ProcessSelection = GameRuleConfig.ProcessSelection;
                    var open = ProcessSelection(selection);
                    if(open)
                    {
                        var pause = SetStateOnSelection(GameState, GameParams);
                        return (pause, GameState.SelectionCount);
                    } else
                    {
                        return (false, GameState.SelectionCount);
                    }
                } else
                {
                return (false,GameParams.Params.RuleParams);
                }
            }
            
            public override bool CheckSelectionsImp (IGameRuleConfig<T,GameState<T>> GameRuleConfig, GameState<T> GameState, IGameParams GameParams)
            {
                GameState.Locked = true;
                var RuleSet = GameRuleConfig.RuleSet;
                var Reset = GameRuleConfig.Reset;
                var selections = GameState.Selections;
                var check = RuleSet(selections);
                if (check)
                {
                    GameState.SolveCount += 1;
                }
                return check;
            }

            public override bool NextTurnImp (IGameRuleConfig<T,GameState<T>> GameRuleConfig, GameState<T> GameState, IGameParams GameParams, bool[] force)
            {
                var selections = GameState.Selections;

                // MessageBox.Show(GameState.SelectionCount.ToString());
                
                var Reset = GameRuleConfig.Reset;
                
                if (!force[0])
                {
                    foreach (var item in selections)
                    {
                        if (item !=null)
                        {
                            Reset(item);
                        }
                    }
                }
                StateReset(GameState);

                if (GameState.SolveCount == GameParams.Params.MaxCount)
                {
                    MessageBox.Show("You Win");
                }

                GameState.Locked = false;
                return force[0];                 
            }
            

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
        }
    }
}