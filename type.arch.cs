// type system architecture for app

namespace MatchingGame{

     using System.Windows.Forms;

     //Params like Props
     public interface IParams{
          int MaxCount { get;set;}
          int RuleParams {get; set;}
          int ResetInterval {get;set;}          
     }

     public interface IGameParams{
          IParams Params{get;set;}
     }     

     public delegate bool IRule<T>(T[] t);
     public delegate bool ISetState<T>(T t);
     public delegate void IMechanicInit(Timer timer, IGameParams p);
     public delegate (bool pause, int selectionCount) IMechanicState<C, S>(C config, S s, IGameParams p);
     public delegate bool IMechanicCheck<C, S>(C config, S s,  IGameParams p);
     public delegate bool IMechanicTimer<C, S>(C config, S s, params bool[] force);

     public interface IGameRuleConfig<T,S> {
          IRule<T> RuleSet{get;}
          ISetState<T> ProcessSelection{get;}
          ISetState<T> Reset{get;}
     }

     public interface IGameMechanics<T, S>{
          IMechanicInit StartGame{get;}
          IMechanicState<IGameRuleConfig<T,S>, S> PlaySelection {get;}
          IMechanicCheck<IGameRuleConfig<T,S>, S> CheckSelections{get;}
          IMechanicTimer<IGameRuleConfig<T,S>, S> NextTurn{get;}
     }


     public interface IGameLogic<T, S>{
          //add set method later in implemtation if want          
          EventHandler PlayEvent {get;}
          EventHandler TimerEvent {get;}
          IGameMechanics<T, S> GameMechanics {get;}
          IGameRuleConfig<T, S> GameRuleConfig {get;}
          S GameState {get;}
          IGameParams GameParams{get;}
          Timer Timer {get;set;}    //not set here cannot use GameMechanics.timer          

     }

     public interface ITableGame<T, S>{
          IGameLogic<T, S> GameLogic {get;}
          ITestPartial<T> TestPartial{get;set;}
     }

     public interface ITestPartial<T>{
          EventHandler PlayEvent{get;}
          ISetState<T> ProcessEvent{get;}          
          int check {get;set;}          
     }
     
}

