   M S B A M L   `   `   `  ����>  :YP5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:YP5YP5  5   	       YP5.Chekiiiii   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:YP5     5   	     � Title$  	Chekiiiii��5   	   $	��450��6   $	��800��6(   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $	��130 �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      �� 5      �� 5      �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ TableSS��5   %   $��10��6      
IsReadOnly . 
�������   AutoGenerateColumns .  $y�Visible=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *OrderNumber+6E     5      $ Дата��6C    6%   �� *	DateOrder+6C     5       $ Почта клиента��6G    6%   �� *Clients.Email+6G     5!      $# Фамилия кассира��6N    6%   �� *Cashiers.CashSurname+6N   5#      �� 5$   
   -   5        $��4��5$      $��
Выход��6!   61   �� 5%   
   $��4��6   $��1��6!   $-��'Введите номер заказа:��61   $��Center=�6N   $��15(�6i   $
��Wrap=�6w   �� 5&   
   $��5��6   $��1��6!   $��Введите дату:��61   $��Center=�6F   $��15(�6a   $
��Wrap=�6o   �� 5'   
   $��6��6   $��1��6!   $%��Выберите кассира��61   $��Center=�6I   $��15(�6d   $
��Wrap=�6r   �� 5(   
   $��7��6   $��1��6!   $0��*Выберите наименование:��61   $��Center=�6O   $��15(�6j   $
��Wrap=�6x   �� 5)   
   -   5        	 ��Name$	 ReadDannie1��5)   /   $��2��6   $��4��6"   6�   (  "System.Windows.Controls.DatePicker  5*   
   -   5        
  Name$
 ReadDannie2��5*   2   $��2��6   $��5��6%      DisplayDateStart$ 
2023-01-01X�6z      DisplayDateEnd$ 
2024-09-27X�6�      SelectedDate 6G   �� *SelectedDate+ �� Mode$ TwoWay=�6�   �� 5+   
   -   5         ��Name$ Combo2��5+   0   $��2��6   $��6��6#    �� DisplayMemberPath$ 
NameOfRole��6@   6_   �� 5,   
   -   5        $ Combo3��5,   0   $��2��6   $��7��6#   $ 
NameOfRole��6@   6_   �� 5-   
   -   5         ��Name$ Dobav��5-   A   $��3��6   $��4��6!   $��Добавить��6.   6Q   �� 5.   
   -   5        $ Izmen��5.   A   $��3��6   $��5��6!   $��Изменить��6.   6P   �� 5/   
   -	   5        $
 Ydal��5/   @   $��3��6   $��6��6!   $��Удалить��6.   6N   �� 50   
   -
   5        $��3��50      $��9��6!   $��Импорт��6.   $��20(�6?   6M   51      52      