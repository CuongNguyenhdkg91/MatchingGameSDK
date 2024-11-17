namespace TableLookGame
{
    public partial class Form1 : TableLookGame<Label>
    {
        public override int RuleParams { get { return 4; } }
        public override int ResetInterval { get { return 850; } }
        public override int maxCount { get { return 4; } }

        public override bool Rule(params Label[] ClickedLables)
        {
            Label firstClicked = ClickedLables[0];
            Label lastClicked = ClickedLables[^1];
            Label secondClicked = ClickedLables[1];
            Label thirdClicked = ClickedLables[2];
            if (firstClicked.Text == lastClicked.Text && secondClicked.Text == thirdClicked.Text && firstClicked.Text != secondClicked.Text)
            {
                return true;
            }
            return false;
        }

        public override void Reset(Label label)
        {
            label.ForeColor = label.BackColor;
        }

        public override bool ProcessEvent(Label clickedLabel)
        {
            if (clickedLabel.ForeColor != Color.Black)
            {
                clickedLabel.ForeColor = Color.Black;
                return true;
            }
            else return false;
        }
    }
}

