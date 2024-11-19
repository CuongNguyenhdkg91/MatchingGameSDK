namespace MatchingGame{
    using System.Windows.Forms;
    partial class BaseTableGame<T, S>
    {
        public abstract class BaseGameMechanics: IGameMechanics<T, S>
        {
            public IMechanicInit StartGame{get;}
            public IMechanicState<S, S> PlaySelection => PlaySelectionImp;
            public IMechanicCheck<S, S> CheckSelections{get;}
            public Timer timer {get;set;}

            public abstract bool SetStateOnSelection(S GameState, IGameParams GameParams);  
                 

/*         public void StartGameImp(Timer timer, IGameParams gameParams)
        {
            timer.Interval = gameParams.Params.ResetInterval;
            // timer.Tick += Timer_Tick;
            // Array.Resize(ref selections, gameParams.Params.RuleParams);
        } */

            public bool PlaySelectionImp (ISetState<S> ProcessSelection, S GameState, IGameParams GameParams)
            {
                var open = ProcessSelection(GameState);
                if(open)
                {
                    var pause = SetStateOnSelection(GameState, GameParams);
                    return pause;
                } else
                {
                    return false;
                }
                
            }

/*             public bool CheckSelectionsImp (IRule<S> RuleSet, S GameState,  IGameParams p)
            {
                var check = RuleSet(GameState);
                if (check)
                {
                    timer.Stop();
                } else
                {
                    GameRuleConfig.Reset(GameState);
                }
                return true;
            } */


/*         public int PlayEvent(int SelectedCount, T selection, Timer timer, IGameParams gameParams, IGameRuleConfig<T> GameRuleConfig)
        {
                var RuleParams = gameParams.Params.RuleParams;
                var MaxCount = gameParams.Params.MaxCount;
                var RuleSet = GameRuleConfig.RuleSet;
                var ProcessEvent = GameRuleConfig.ProcessEvent;

                timer.Start();
        } */


/*         public EventHandler PlayEvent111(T selection, T firstSelection, T lastSelection, Timer timer, IGameParams gameParams, IGameRuleConfig<T> GameRuleConfig)
        {
                var RuleParams = gameParams.Params.RuleParams;
                var MaxCount = gameParams.Params.MaxCount;
                var RuleSet = GameRuleConfig.RuleSet;
                var ProcessEvent = GameRuleConfig.ProcessEvent;

                if (lastSelection == null)
                        if (ProcessEvent(selection))
                        {
                            if (firstSelection == null && RuleParams > 1)
                            {
                            firstSelection = selection;
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
        } */
        }
    }
}



