   M S B A M L   `   `   `  ????>  :PR6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PR6.Pages	PR6.Pages  5          PR6.Pages.StatusPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:PR6.Pages     5        N? Title$  
StatusPage??5	      .??5      ?  ? RowDefinitions 5   
   ?? 5      $	??22* ?6   ?? 5      $??3* ?6   .+?5   
   ? $??2??6   .+?5      &   System.Windows.Controls.DataGrid  -   5          Name$ StatusDG??5   Z   
???????"   VerticalScrollBarVisibility$
 Auto=?6*   $??0??6M      AutoGenerateColumns .     
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6?   $??Center=?6?   $??Center=?6?   $??0,0,0,54q?6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! Код сотрудника??6)   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6A   ?? *	Worker_id+6a     5      $ Код зарплаты??6)   	 6?   ?? *Salaries_id+6a     5      $ Накопления??6)   	 6=   ?? *	accrued+6[     5      $ Удержания??6)   	 6<   ?? *
Withheld+6[     5      $ к Выплате??6)   	 6<   ?? *	payable+6Z   5      5      ? 5   
   $??1??6   
???????.+?5      ?? -   5        
 ??Name$
 BackBTN??5   >   $	??175??6   $??50??6!    ?? CornerRadius$ 5??6-   ._?5      ?? 
???????$??Center=?6/   $??Center=?6L   .??6g   Вернуться6r   5       5#      5$      5%      