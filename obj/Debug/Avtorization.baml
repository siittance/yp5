   M S B A M L   `   `   `  ����>  :YP5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:YP5YP5  5   	       YP5.Avtorization   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:YP5     5   	     � Title$  Avtorization��5   	   $	��450��6   $	��800��6+   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      $��3* �6   �� 5      $	��130 �6   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ TableSS��5   $   $��7��6      
IsReadOnly . 
�������   AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$- 'Никнейм пользователя��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
Username+6B     5      $+ %Пароль пользователя��6C    6%   �� *	Passwordd+6C     5      $ Роль��6J    6%   �� *Rolee.NameOfRole+6J   5      �� 5    
   -   5        $��4��5       $��
Выход��6!   61   �� 5!   
   $��2��6   $��1��6!   $ ��Введите логин:��61   $��Center=�6G   $��15(�6b   $
��Wrap=�6p   �� 5"   
   $��3��6   $��1��6!   $"��Введите пароль:��61   $��Center=�6H   $��15(�6c   $
��Wrap=�6q   �� 5#   
   $��4��6   $��1��6!   $ ��Выберите роль:��61   $��Center=�6G   $��15(�6b   $
��Wrap=�6p   �� 5$   
   -   5        	 ��Name$	 
ReadDannie��5$   /   $��2��6   $��2��6"   6h   �� 5%   
   -   5        $	 ReadDannie1��5%   /   $��2��6   $��3��6"   6j   �� 5&   
   -   5        
 ��Name$
 ReadDannie2��5&   0   $��2��6   $��4��6#    �� DisplayMemberPath$ 
NameOfRole��6E   �� 5'   
   -   5         ��Name$ Dobav��5'   A   $��3��6   $��2��6!   $��Добавить��6.   $��40��6h   $��2��6u   $	��Top=�6�   �� 5(   
   -   5        $ Izmen��5(   A   $��3��6   $��2��6!   $��Изменить��6.   $��0,40,0,0q�6g   $��2��6y   �� 5)   
   -   5        $
 Ydal��5)   @   $��3��6   $��4��6!   $��Удалить��6.   6N   5+      5,      