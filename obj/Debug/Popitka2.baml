   M S B A M L   `   `   `  ����>  :YP5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:YP5YP5  5   	       YP5.Popitka2   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:YP5     5   	     � Title$  Popitka2��5   	   $	��450��6   $	��800��6'   .��5	      � 
������� � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5      $��60 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ TableSS��5         
IsReadOnly . 
�������   AutoGenerateColumns .  $��2��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Имя питомца��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	PetName+6A     5      $) #Наличие документов��6C    6%   �� *	Documents+6C     5      $ Цена питомца��6?    6%   �� *Price+6?     5      $ Порода��6P    6%   �� *BreedOfPet.NameOfBreed+6P     5      $$ Местонахождение��6O    6%   �� *Shelter.TownOfShelter+6O     5      $ Наименование��6X    6%   �� * NaimenovaniePetsa.Naimenovanie+6X   5      �� 5   
   -   5         ��Name$ Combo1��5      	 J� Opacity$	 0Q�6#   $��	0,434,0,0q�6/   $��0��6B   $��0��6M   �� 5   
   -   5        $ Combo2��5      $	 0Q�6#   $��	0,434,0,0q�6/   $��0��6B   $��0��6M   �� 5   
   -   5        $ Combo3��5      $	 0Q�6#   $��	0,434,0,0q�6/   $��0��6B   $��0��6M   �� 5   
   -   5        $��4��5      $��
Выход��6!   
����� �6F   5      5      