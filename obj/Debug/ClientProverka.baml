   M S B A M L   `   `   `  ����>  :YP5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:YP5YP5  5   	       YP5.ClientProverka   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:YP5     5   	     � Title$  ClientProverka��5   	   $	��450��6    $	��800��6-   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $	��200 �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ TableSS��5   $   $��7��6      
IsReadOnly . 
�������   AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$/ )Наименование проверки��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *NameOfThecheck+6H   5      �� 5      -   5        $��4��5      $��
Выход��6%   65   �� 5   
   $��3��6   $��1��6!   $7��1Введите название проверки:��61   $��Center=�6S   $��15(�6n   $
��Wrap=�6|   �� 5    
   -   5        	 ��Name$	 
ReadDannie��5    /   $��2��6   $��3��6"   6h   �� 5!   
   -   5        $��3��5!      $��2��6!   $��Добавить��6.   6A   �� 5"   
   -   5        $��3��5"      $��3��6!   $��Изменить��6.   6A   �� 5#   
   -   5        $��3��5#      $��4��6!   $��Удалить��6.   6@   5$      5%      