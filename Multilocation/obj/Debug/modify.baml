   M S B A M L   `   `   `  ����H  DMultilocation, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MultilocationMultilocation  5   	       Multilocation.modify   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Multilocation     5   	     � Title$  modify��5   	   $	��587��6   $	��543��6%   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��129* �6   �� 5      $
��305* �6   �� 5      $
��103* �6   .+�5   
   �� $��	-3,-1,0,0q�6   $%��Nouvel_informateur_icon (4).png��6#   $
��Fill=�6L   $��3��6[   $
��Left=�6o   $	��540��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $	��559��6�   $	��Top=�6�   z�5      V� 5      .~�5      �� �� 5       �� AngleX$ 0.542Q�6$   �� 5      T� 5       T� X$
 2.45Q�6)   5      5      �� 5   
   -   5         ��Name$ 	modifyBtn��5      $��Go back��6$   $
��Left=�66   $��29��6Q   $��
10,494,0,0q�6]   $	��Top=�6q   $	��106��6�   $��23(�6�   $��Sitka Banner)�6�   ���	#FFBFBFC5���	#FF2E0A0A���	#FF110D0D6  �� 5   
   $�� Multi Rentals Enterprise��6   $
��Left=�64   $��65��6O   $��
-2,26,-1,0q�6[   $	��Top=�6o   $	��540��6�   $��45(�6�   $��Palatino Linotype)�6�   $��5,-4,5,5q�6�   $
��Bold"�6�   ���	#FF020B0E���	#FF7D1818$��3��6  ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      � 	 � Color$	 	#FFCCD1D1��6#   
 � Offset$
 0.935Q�65   � 5      $	 	#FF7AECF3��6#   $	
 0.2Q�65   � 5       $	 	#FF7AECF3��6#   5!      5#      �� 5$   
   $��Modify rental��6   $
��Left=�6(   $��41��6C   $��
0,105,-2,0q�6O   $	��Top=�6c   $	��539��6{   $��25(�6�   $��Palatino Linotype)�6�   $��5,0,5,5q�6�   $
��Bold"�6�   ���	#FF020B0E���	#FF7D1818$��3��6  ��5%      �� 5&      $ 0.5,1&�6&   $ RelativeToBoundingBox=�67   $ 0.5,0&�6[   .��5'      � $	 	#FFCCD1D1��6#   $
 0.935Q�65   � 5(      $	 	#FF7AECF3��6#   $	
 0.2Q�65   � 5)      $	 	#FF7AECF3��6#   5*      5,      �� 5-   
   -   5         ��Name$ rentalIdTextBox��5-      $
��Left=�6+   $��30��6F   $��150,160,0,0q�6R    �� TextWrapping$
 Wrap=�6g   $	��Top=�6{   $	��188��6�   $��16(�6�   $��0,2,0,0q�6�   $��2��6�   $��1��6�   {�.  6�   �� 5.   
   $��Rental ID :��6   $
��Left=�6&   $��30��6A   $��
51,160,0,0q�6M   $	��Top=�6a   $��92��6y   $��17(�6�   $
��Bold"�6�   $��Sitka Banner)�6�   $��1��6�   �� 5/   
   $��Start date :��6   $
��Left=�6'   $��30��6B   $��
51,195,0,0q�6N   $	��Top=�6b   $��92��6z   $��17(�6�   $
��Bold"�6�   $��Sitka Banner)�6�   $��1��6�   �� 50   
   $��1st payment :��6   $
��Left=�6(   $��30��6C   $��
35,230,0,0q�6O   $	��Top=�6c   $	��104��6{   $��17(�6�   $
��Bold"�6�   $��Sitka Banner)�6�   $��1��6�   �� 51   
   -   5        $ _1erPaiement��51      $
��Left=�6(   $��30��6C   $��150,265,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��188��6�   $��16(�6�   $��0,2,0,0q�6�   $��2��6�   $��1��6�   {�.  6�   �� 52   
   $��Amount 1st payment :��6   $
��Left=�6/   $��30��6J   $��105,265,0,0q�6V   $	��Top=�6k   $	��164��6�   $��17(�6�   $
��Bold"�6�   $��Sitka Banner)�6�   $��2��6�   �� 53   
   -   5        $ totalPaiement��53      $
��Left=�6)   $��30��6D   $��150,300,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��188��6�   $��16(�6�   $��0,2,0,0q�6�   $��2��6�   $��1��6�   {�.  6�   �� 54   
   $��Total payments : ��6   $
��Left=�6,   $��30��6G   $��
12,300,0,0q�6S   $	��Top=�6g   $	��131��6   $��17(�6�   $
��Bold"�6�   $��Sitka Banner)�6�   $��1��6�   �� 55   
   -   5        $ Vehicule_vise��55      $
��Left=�6)   $��30��6D   $��150,335,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��188��6�   $��16(�6�   $��0,2,0,0q�6�   $��2��6�   $��1��6�   {�.  6�   �� 56   
   $��Concerned vehicule : ��6   $
��Left=�60   $��30��6K   $��112,335,0,0q�6W   $	��Top=�6l   $	��157��6�   $��17(�6�   $
��Bold"�6�   $��Sitka Banner)�6�   $��2��6�   �� 57   
   -   5        $ concernedClient��57      $
��Left=�6+   $��30��6F   $��150,370,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��188��6�   $��16(�6�   $��0,2,0,0q�6�   $��2��6�   $��1��6�   �� 58   
   $��Concerned client : ��6   $
��Left=�6.   $��30��6I   $��	1,370,0,0q�6U   $	��Top=�6h   $	��142��6�   $��17(�6�   $
��Bold"�6�   $��Sitka Banner)�6�   $��1��6�   �� 59   
   -   5        $ termes_location��59      $
��Left=�6+   $��30��6F   $��150,405,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��188��6�   $��16(�6�   $��0,2,0,0q�6�   $��2��6�   $��1��6�   �� 5:   
   $��Termes and conditions : ��6   $
��Left=�63   $��30��6N   $��
88,405,0,0q�6Z   $	��Top=�6n   $	��184��6�   $��17(�6�   $
��Bold"�6�   $��Sitka Banner)�6�   $��2��6�   (  "System.Windows.Controls.DatePicker  5;   
   -   5          Name$ date1erPaiement��5;      $
��Left=�6.   $��150,230,0,0q�6I   $	��Top=�6^   $��30��6v   $	��191��6�   $��2��6�   $��1��6�   {�.  6�   �� 5<   
   -	   5        $ debut_location��5<      $
��Left=�6*   $��30��6E   $��150,195,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��188��6�   $��16(�6�   $��0,2,0,0q�6�   {�.  $��2��6�   $��1��6�   �� 5=   
   -
   5        $ 	updateBtn��5=      $��2��6$   $��UPDATE��68   $��28��6I   $��239,460,70,0q�6U   $	��Top=�6k   $��20(�6�   $��Sitka Banner)�6�   $ 0.944,0.564&�6�   $��1��6�   ���	#FF1B64CF
�������6	  5?      5@      