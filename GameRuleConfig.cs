namespace MatchingGame{
    using System.Windows.Forms;
    partial class TableGame<T>{

        public bool RuleImp(GameState<T> GameState){
            var selections = GameState.Selections;
            if (selections.Length == 4)
            {
                return Rule4Imp(selections[0],selections[1],selections[2],selections[3]);
            }
            return false;
        }

        public bool Rule4Imp(T first, T second, T third, T last)
        {
            if (first.Text == last.Text && second.Text == third.Text && first.Text != second.Text)
            {
                return true;
            }
            return false;            
        }

        public bool ResetImp(GameState<T> GameState)
        {
            var selections = GameState.Selections;

            foreach (var selection in selections)
            {
                // label.ForeColor = label.BackColor;
                if (selection is Label label)
                {
                    label.ForeColor = Color.Wheat;
                }
            }
            return true;
        }

        public bool ProcessSelectionImp(GameState<T> GameState)
        {
            var clickedLabel = GameState.Selection;
            if (clickedLabel.ForeColor != Color.Black)
            {
                clickedLabel.ForeColor = Color.Black;
                return true;
            }
            else
            {
                // clickedLabel.ForeColor = Color.BlueViolet;
                return false;
            }
        }

        public bool ProcessTimerImp(Timer timer, GameState<T> GameState, params bool[] force){
            if (force[0] == true){
                timer.Stop();
                return true;
            }
            if (GameState.SelectionCount == 1)
            {
                timer.Start();
                return false;
            }
            return false;
        }
    }
}