// namespace MatchingGame
namespace TableLookGame
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            Name = "Form1";
            Text = "MatchingGame";

            tableLayoutPanel1 = new TableLayoutPanel();
            Controls.Add(tableLayoutPanel1);

            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.ColumnCount = 4;
            // tableLayoutPanel1.TabIndex = 0;

            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();

            Random random = new();
            List<string> icons = ["!","!","!","!","N","N","N","N",",",",",",",",","k","k","k","k"];
            int[] loop = new int[16];
            //var iconsCopy = icons; //not work may be same address in memory

            //make into a class - component
            while (icons.Count > 0)
            {
                var label = new Label();
                tableLayoutPanel1.Controls.Add(label);

                int randomNumber = random.Next(icons.Count);
                label.Text = icons[randomNumber];
                icons.RemoveAt(randomNumber);

                //add styling
                var LookingIcons = label;
                LookingIconsStyle(LookingIcons);

                //add event trigger control 
                label.Click += PlayEvent;

                //component did mount, no hook so need keep strict order after styling
                Reset(label);
            }

            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            timer1.Interval = 750;


            //will mount lastest components ??
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        //make the style for component
            ClientSize = new Size(532, 503);
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;

            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            // tableLayoutPanel1.Size = new Size(100, 100);
            // tableLayoutPanel1.Location = new Point(0, 0);
            // tableLayoutPanel1.BackColor = Color.CornflowerBlue;                  

            // tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            // tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            // tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            // tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            // tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            // tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            // tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            // tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));

            void LookingIconsStyle(Label LookingIcons){
                LookingIcons.Dock = DockStyle.Fill;
                LookingIcons.Font = new Font("Webdings", 80);
                LookingIcons.Location = new Point(137, 2);
                LookingIcons.Size = new Size(124, 123);
                LookingIcons.TextAlign = ContentAlignment.MiddleCenter;
                LookingIcons.BackColor = Color.GreenYellow;
            }
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer timer1;


        
    }
}
