   M S B A M L   `   `   `  ����  FeedTheSnake    FeedTheSnake.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Feed The Snake��5   	   $	��260��6    $	��270��6-    J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$
 Help��5      6(     5   
   -   5        $	 New��5      6'   .��5	      � $	��250��6!   ��6   Z�  � RowDefinitions 5
   
   �� 5      $	��28* �6   �� 5      $
��193* �6   .+�5   
   o� -   5        $��menu1��5   .   $��23��6   $��	12,5,61,0q�6   $	��Top=�6;   .@�5      m� $��New Game��6    m� Command$	 New��6)   m� 5      $��Level��6   .@�5      m� -   5        $��1��5       m� 	IsChecked .   m� IsCheckable . 6P   m� 5      -   5        $��2��5       .   . 6P   m� 5      -   5        $��3��5       .   . 6P   m� 5      -   5        $��4��5       .   . 6P   5      m� 5      $
��Help��6    .   .  $
 Help��6K   5      �� 5   
   -   5        $��	gamePlace��5   1   $��1��6   $��	15,6,15,0q�6   ���	#FF5C7D2F$	��172��6r   $	��Top=�6    � DataContext 6Z   �� 5      �� 5   
   -	   5        $��result��5   V   $��0��6   $��23��6   $
��Left=�6(   $��	195,5,0,0q�6C   $	��Top=�6d   $��43��6|   ���	#FFEBD0D06�   5      5      