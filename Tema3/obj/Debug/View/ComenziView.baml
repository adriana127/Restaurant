   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Tema3.View
Tema3.View  5          Tema3.View.ComenziView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Tema3.View     5      .��5	      � $��
0,0,-6.2,1q�6     J� RenderTransformOrigin$  
0.707,0.67&�6    $��641.4��6D   $��883.2��6S   ��5
   
   �� 5       �� ImageSource$8 2C:\Users\Adriana\Desktop\Restaurant\background.jpg��6    j� Stretch$ UniformToFill=�6Z    � ColumnDefinitions 5   
   �� 5      $	��75* �6   �� 5      $
��615* �6   �� 5      $
��194* �6   .+�5   
   �� ���#ffc815$
��Left=�6#   $	��611��6>   
���   �$	��Top=�6Z   $	��185��6r   $��2��6~   �� 5   
   $2��,C:\Users\Adriana\Desktop\Restaurant\user.png��6   $
��Left=�6G   $��70��6b   $��22,5,0,0q�6n   $	��Top=�6�   $��84��6�   $��1��6�   �� 5   
   $��Stefan Adriana��6   $
��Left=�6)   $��6,5,0,0q�6D   $	��Top=�6U   $��26��6m   $��86��6y   $  0.5,0.5&�6�   $��2��6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 1.411Q�6&   T� 5      5      5      �� 5   
   $
��Left=�60   $��	24,30,0,0q�6K   $	��Top=�6^   $��26��6v   $��51��6�   ��6   �� *User.statut+6�   �� 5    
   $��	Preparate��64   $
��Left=�6H   $��	0,215,0,0q�6c   $	��Top=�6v   $	��185��6�   $��55��6�   $��2��6�   ��6   �� *goToPreparate+6�   �� 5!   
   $��Meniuri��62   $
��Left=�6D   $��	0,275,0,0q�6_   $	��Top=�6r   $	��185��6�   $��55��6�   $��2��6�   ��6   �� *goToMeniuri+6�   �� 5"   
   $	��Cos��6/   $
��Left=�6=   $��	0,465,0,0q�6X   $	��Top=�6k   $	��185��6�   $��55��6�   $��2��6�   ��6   �� *
goToCart+6�   �� 5$   
   $��Alergeni��6V   $
��Left=�6i   $��	0,400,0,0q�6�   $	��Top=�6�   $	��185��6�   $��60��6�   $��2��6�   ��6   �� *goToAlergeni+y�63   �� *
Visibility+6�   �� 5%   
   
���   �$��0q�6%   $
��Left=�69   $��109.8,0,0,0q�6T   $	��Top=�6i   $	��698��6�   $	��611��6�   $��2��6�   $��1��6�   ._�5&      � 
������ $	��710��6,   $	��611��68   .+�5'      �� $��Comenzi��6   $
��Left=�6*   $��	35,45,0,0q�6E   $	��Top=�6X   $��55��6p   $	��238��6|   ���	#FFD4CE11$��24(�6�   �� 5(         comenziTemplate#��[  6�   $
��Left=�6�   $	��365��6�   $��
35,175,0,0q�6�   $	��Top=�6  $	��620��6)  ��6   �� *	Comenzi+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6_   �� *
PtUpdate+$ PropertyChanged=�6)  �� 5)      $��480,119,120,458q�6�   ��6   �� *ModificaStare+$ PropertyChanged=�y�6_   �� *
Visibility+.��6�   Modifica Status6�   �� 5*        categoriiListBox#��[ 6b   $��269,119,266,458q�6�   ��6   �� *ListaStatus+ 6?   �� *	StatusNou+y�6�   �� *
Visibility+6�   5+      5,      �� 5-   
   $��	Categorii��6W   $
��Left=�6k   $��	0,335,0,0q�6�   $	��Top=�6�   $	��185��6�   $��60��6�   $��2��6�   ��6   �� *goToCategorii+y�64   �� *
Visibility+6�   �� 5.   
   $��Comenzi��62   $
��Left=�6D   $��	0,525,0,0q�6_   $	��Top=�6r   $	��185��6�   $��55��6�   $��2��6�   ��6   �� *goToComenzi+6�   50      52      