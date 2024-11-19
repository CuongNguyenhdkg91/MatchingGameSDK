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

     public delegate bool IRule<T>(T t);
     public delegate bool ISetState<T>(T t);
     public delegate void IMechanicInit(Timer timer, IGameParams p);
     public delegate bool IMechanicState<T, S>(ISetState<T> set, S s, IGameParams p);
     public delegate bool IMechanicCheck<T, S>(IRule<T> r, S s,  IGameParams p);

     public interface IGameRuleConfig<T,S> {
          IRule<S> RuleSet{get;}
          ISetState<S> ProcessSelection{get;}
          ISetState<S> Reset{get;}
     }

     public interface IGameMechanics<T, S>{
          IMechanicInit StartGame{get;}
          IMechanicState<S, S> PlaySelection {get;}
          IMechanicCheck<S, S> CheckSelections{get;}
          IMechanicState<T, S> TimerEvent{get;}
          Timer timer {get;}          
     }


     public interface IGameLogic<T, S>{
          //add set method later in implemtation if want          
          EventHandler PlayEvent{get;}
          IGameMechanics<T, S> GameMechanics {get;}
          IGameRuleConfig<T, S> GameRuleConfig {get;}
          S GameState {get;}
          IGameParams GameParams{get;}  

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

