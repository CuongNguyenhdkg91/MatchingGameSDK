// type system architecture for app

namespace TableLookGame{

     delegate bool IRule<T>(params T[] t);
     delegate bool IProcess<T>(T t);

     interface IGamePlay<T>{
          public IRule<T> RuleSet{get;}
          public IProcess<T> ProcessEvent{get;}
        
     };

     class TableGame: IGamePlay<Label>
     {
          public IProcess<Label> ProcessEvent => 
               (Label clickedLabel) =>
               {
               if (clickedLabel.ForeColor != Color.Black)
               {
                    clickedLabel.ForeColor = Color.Black;
                    return true;
               }
               else return false;
               };

          public IRule<Label> RuleSet => 
          (params Label[] ClickedLabels) =>
          {
               Label firstClicked = ClickedLabels[0];
               Label lastClicked = ClickedLabels[^1];
               Label secondClicked = ClickedLabels[1];
               Label thirdClicked = ClickedLabels[2];
               return false;
          };
     }




        
}
