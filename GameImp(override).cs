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