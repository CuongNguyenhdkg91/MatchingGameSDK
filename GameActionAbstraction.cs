namespace TableLookGame
{
    public abstract class TableLookGame<T> : Form where T : Control
    {
        public abstract bool Rule(params T[] selections);
        public abstract bool ProcessEvent(T control);
        public abstract void Reset(T Control);
        public virtual bool Rule2(T first, T second)
        {
            return false;
        }
        public virtual bool Rule3(T first, T second, T third)
        {
            return false;
        }
        public virtual bool Rule4(T first, T second, T third, T fourth)
        {
            return false;
        }


        private System.Windows.Forms.Timer timer = new(); //check how many timer exist in runtime ? according to number of cell ?
        private T? firstSelection;
        private T? lastSelection;
        private T[]? selections = new T[1];
        private int count = 0;
        private int i = 1;
        public virtual int maxCount { get; }
        public virtual int RuleParams { get; }
        public virtual int ResetInterval { get; }

        private bool CheckPlayerEvent(EventHandler eventHandler)
        {
            if (eventHandler.Target == eventHandler.Target)
            {
                return true;
            }
            else return false;
        }
        public void StartGame()
        {
            timer.Interval = ResetInterval;
            timer.Tick += Timer_Tick;
            Array.Resize<T>(ref selections, RuleParams);
        }

        public void PlayEvent(object? sender, EventArgs args)
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
                            bool check = Rule(selections);
                            if (check)
                            {
                                count += 1;
                                for (int k = 0; k < RuleParams; k++)
                                {
                                    selections[k] = null;
                                }
                                i = 1;
                                if (count == maxCount)
                                {
                                    MessageBox.Show("You Win");
                                    // Close();
                                }
                            }
                            else
                            {
                                timer.Start();
                            }
                        }
                    }
                }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            timer.Stop();
            for (int k = 0; k < RuleParams; k++)
            {
                if (selections[k] != null)
                {
                    Reset(selections[k]);
                    selections[k] = null;
                }
            }
            i = 1;
        }
    }
}
