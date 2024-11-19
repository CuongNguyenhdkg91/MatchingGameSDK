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
            public IRule<S> RuleSet{get;set;}
            public ISetState<S> ProcessSelection{get;set;}
            public ISetState<S> Reset{get;set;}
        }

        public IGameLogic<T, S> GameLogic {get;set;}

        public abstract class BaseGameLogic: IGameLogic<T,S>
        {
            
            public IGameRuleConfig<T, S> GameRuleConfig {get;set;}
            public IGameParams GameParams{get;set;} 
            public S GameState {get;set;}                
            public IGameMechanics<T, S> GameMechanics => GameMechanicsImp;
            public Timer timer {get;}
            public EventHandler PlayEvent => PlayEventImp;

            public BaseGameMechanics GameMechanicsImp{get;set;}

            public abstract void StateUseSelection(S GameState, T selection);
            public abstract void StateReset(S GameState);

            public void PlayEventImp (object? sender, EventArgs e)
            {
                if (sender is T selection)
                {
                    StateUseSelection(GameState, selection);
                    var pause = GameMechanics.PlaySelection(GameRuleConfig.ProcessSelection,GameState,GameParams);
                    if (pause)
                    {
                        var check = GameMechanics.CheckSelections(GameRuleConfig.RuleSet, GameState, GameParams);
                        if (check)
                        {
                            timer.Stop();
                        } else
                        {
                            GameRuleConfig.Reset(GameState);
                        }
                        StateReset(GameState);

                        // GameMechanics.TimerEvent;
                    }
                }
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