namespace MatchingGame{
    using System.Windows.Forms;

    public abstract partial class BaseTableGame<T, S>: Form, ITableGame<T, S>
    {
        public class Props: IParams
        {
            public int MaxCount { get;set;}
            public int RuleParams {get; set;}
            public int ResetInterval {get;set;}    
        }

        public class GameProps: IGameParams
        {
            public IParams Params{get;set;}
        }

        public class TGameRuleConfig: IGameRuleConfig<T,S> {
            public IRule<T> RuleSet{get;set;}
            public ISetState<T> ProcessSelection{get;set;}
            public ISetState<T> Reset{get;set;}
        }

        public IGameLogic<T, S> GameLogic {get;set;}

        public abstract class BaseGameLogic: IGameLogic<T,S>
        {
            
            public IGameParams GameParams{get;set;} 
            public IGameRuleConfig<T, S> GameRuleConfig {get;set;}
            public IGameMechanics<T, S> GameMechanics {get;set;}
            public S GameState {get;set;}
            public Timer Timer {get;set;}            
            public EventHandler PlayEvent => PlayEventImp;
            public EventHandler TimerEvent => TimerEventImp;            
            public abstract void StateUseSelection(S GameState, T selection);
            // public abstract void TimerEventImp (object? sender, EventArgs e);            

            // public BaseGameMechanics GameMechanicsImp{get;set;}


            // public abstract void PlayEventImp (object? sender, EventArgs e);
            public void PlayEventImp (object? sender, EventArgs e)
            {
                if (sender is T selection)
                {
                    StateUseSelection(GameState, selection);
                    var result = GameMechanics.PlaySelection(GameRuleConfig,GameState,GameParams);
                    if (result.selectionCount == 1){Timer.Start();}
                    if (result.pause)
                    {
                        var check = GameMechanics.CheckSelections(GameRuleConfig, GameState, GameParams);
                        if (check)
                        {
                            Timer.Stop();
                            GameMechanics.NextTurn(GameRuleConfig, GameState, GameParams, check);
                        } 
                    }
                }
            }

            public void TimerEventImp(object? sender, EventArgs e)
            {
                Timer.Stop();
                GameMechanics.NextTurn(GameRuleConfig, GameState, GameParams, false);
            }            

        }

        public ITestPartial<T> TestPartial{get;set;}
        public class TTestPartial<T>:ITestPartial<T>{
        public int check {get;set;}              
          public EventHandler PlayEvent =>
            (object? sender, EventArgs e) =>
            {
                if (sender is T selection)
                {
                    if(ProcessEvent(selection))
                    {

                    }
                }
            };
          public ISetState<T> ProcessEvent{get;set;}                     
        }

    }


}