// type system architecture for app

namespace TableLookGame{

     using System.Windows.Forms;

     public delegate bool IRule<T>(params T[] t);
     public delegate bool IEvent<T>(T t);



     public interface IGamePlay<T> where T:Control{
          IRule<T> RuleSet{get;set;}
          IEvent<T> ProcessEvent{get;set;}
          IEvent<T> Reset{get;set;}
          Action<Timer, IGameParams> StartGame{get;}
          Action<IEvent<T>, Timer> TimerEvent{get;}
          EventHandler PlayEvent{get;}
     }

     public interface IParams{
          int MaxCount { get;set;}
          int RuleParams {get; set;}
          int ResetInterval {get;set;}          
     }

     public interface IGameParams{
          IParams GameParams{get;set;}
     }

     public class ITableGame<T>: Form{
          protected Timer timer=new();
          protected T? firstSelection;
          protected T? lastSelection;
          protected T[]? selections = new T[1];
          protected int count=0;
          protected int i=1;
     }

     public class TableGame<T>: ITableGame<T>, IGamePlay<T>,IGameParams  where T:Control
     {
          public IRule<T> RuleSet{get;set;}
          public IEvent<T> ProcessEvent{get;set;}
          public IEvent<T> Reset{get;set;}
          public IParams GameParams{get;set;}

          public int MaxCount { get; set;}
          public int RuleParams { get; set ;}
          public int ResetInterval { get; set;}

/*           public TableGame(IRule<T> RuleSetImp, IEvent<T> ProcessEventImp, IEvent<T> ResetImp, 
          // int MaxCountSet, int RuleParamsSet, int ResetIntervalSet
          IParams GameParamsSet
          )

          {
               RuleSet = RuleSetImp;
               ProcessEvent = ProcessEventImp;
               Reset = ResetImp;

               // MaxCount = MaxCountSet;
               // RuleParams = RuleParamsSet;
               // ResetInterval = ResetIntervalSet;
               GameParams = GameParamsSet;
          } */
          
          public Action<Timer, IGameParams> StartGame =>
          (timer, GameParams) =>
          {
               IParams gameParams = GameParams.GameParams;
               timer.Interval = gameParams.ResetInterval;
               // timer.Tick += Timer_Tick;
               Array.Resize(ref selections, gameParams.RuleParams);
          };

          public Action<IEvent<T>, Timer> TimerEvent =>
          (Reset, timer) =>
          {
            timer.Stop();
            for (int k = 0; k < RuleParams; k++)
            {
                if (selections[k] != null)
                {
                    Reset(selections[k]);
                    selections[k] = default(T);
                }
            }
            i = 1;
          };          

          public EventHandler PlayEvent =>
          (object? sender, EventArgs args) =>
          {
               if (sender is T selection && selections[^1] == null)
                    if (ProcessEvent(selection))
                    {
                         if (selections[0] == null && RuleParams > 1)
                         {
                         selections[0] = selection;
                         timer.Start();
                         }
                         else
                         {
                         if (i < (RuleParams - 1))
                         {
                              selections[i] = selection;
                              i++;
                         }
                         else
                         {
                              timer.Stop();
                              selections[^1] = selection;
                              bool check = RuleSet(selections);
                              if (check)
                              {
                                   count += 1;
                                   for (int k = 0; k < RuleParams; k++)
                                   {
                                        selections[k] =  default(T);
                                   }
                                   i = 1;
                                   if (count == MaxCount)
                                   {
                                        MessageBox.Show("You Win");
                                   }
                              }
                              else
                              {
                                   timer.Start();
                              }
                         }
                         }
                    }
          };


     }


     
}

