   M S B A M L   `   `   `  ????>  :PR6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PR6.Pages	PR6.Pages  5          PR6.Pages.WorkersPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:PR6.Pages     5        N? Title$  WorkersPage??5	      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??133* ?6   ?? 5      $	??17* ?6   .+?5   
   ? 
???????.+?5      ?? $??Center=?6   .??61   Сотрудники6=   &   System.Windows.Controls.DataGrid  5      -   5          Name$ WorkesDG??5   Z   
???????"   VerticalScrollBarVisibility$
 Auto=?6*   $??0??6M      AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6?   $??Center=?6?   $??Center=?6?   $??0,29,0,0q?6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя??6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   ?? *Name+6Q     5      $ Фамилия??6)   	 6:   ?? *	Surname+6X     5      $ Код должности??6)   	 6@   ?? *
FK_Title+6_     5      $ Код разряда??6)   	 6>   ?? *
FK_grade+6]     5      $ Код зарплаты??6)   	 6?   ?? *fin_salary_id+6c     5      $ Код льгот??6)   	 6<   ?? *FK_extension+6_   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Изменить??6-   
   CellTemplate
 5      ?? 5      .R?5   "   ??  ??Name$ 
BtnForEdit??6)   -   5         ?? CornerRadius$ 5??5   =   ._?5   &   ?? 
???????$??Center=?6D   $??14(?6_   $??Center=?6m   .??6?   Изменить6?   5    #   5!      5#        5$      $ Удалить??6-   
 5%      ?? 5&      .R?5'   "   ?? $ BtnForDelete??6)   -   5        $ 5??5'   ?   ._?5(   &   ?? 
???????$??Center=?6D   $??14(?6_   $??Center=?6m   .??6?   Удалить6?   5)   #   5*      5,      5.      5/      ? 50   
   $??1??6   
???????.+?51      ?? -   5        $ StatusPageOpenBTN??51   ?   $	??175??6K   $??40??6W   $??1??6c   $ 5??6q   $
??Left=?6?   ._?52      ?? 
???????$??Center=?6/   $??16(?6J   $??Center=?6X   .??6|   (&Таблица со статусами6?   53      ?? 54      -   5        $ AddWorkersBTN??54   ~   $	??175??6G   $??40??6S   $??1??6_   $ 5??6m   ._?55      ?? 
???????$??Center=?6/   $??16(?6J   $??Center=?6X   .??6|   '%Добавить сотрудника6?   56      ?? 57      -   5        $ 
PrintToPDF??57   ?   $	??175??6D   $??Right=?6P   $??40??6l   $??1??6x   $ 5??6?   ._?58      ?? 
???????$??Center=?6/   $??16(?6J   $??Center=?6X   .??6|   Экспорт в PDF6?   59      5;      5<      5>      