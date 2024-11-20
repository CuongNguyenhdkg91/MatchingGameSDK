namespace MatchingGame{
    using System.Windows.Forms;
    partial class BaseTableGame<T, S>
    {
        public abstract class BaseGameMechanics: IGameMechanics<T, S>
        {
            public IMechanicInit StartGame{get;}
            public IMechanicState<IGameRuleConfig<T,S>, S> PlaySelection => PlaySelectionImp;
            public IMechanicCheck<IGameRuleConfig<T,S>, S> CheckSelections => CheckSelectionsImp;
            public IMechanicTimer<IGameRuleConfig<T,S>, S> NextTurn => NextTurnImp;


            public abstract (bool pause, int selectionCount) PlaySelectionImp (IGameRuleConfig<T,S> GameRuleConfig, S GameState, IGameParams GameParams);            
            public abstract bool CheckSelectionsImp (IGameRuleConfig<T,S> GameRuleConfig, S GameState, IGameParams GameParams);
            public abstract bool NextTurnImp (IGameRuleConfig<T,S> GameRuleConfig, S GameState, IGameParams GameParams, bool[] force);             
             
            public abstract bool SetStateOnSelection(S GameState, IGameParams GameParams); 
            public abstract void StateReset(S GameState);            

        }
    }
}



