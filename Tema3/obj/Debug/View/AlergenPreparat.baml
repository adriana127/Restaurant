   M S B A M L   `   `   `  ����@  <Tema3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema3.ViewModelTema3.ViewModel  5   	        Tema3.View.AlergenPreparat   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Tema3.ViewModel     5   	     � Title$  AlergenPreparatView��5	   	   $��266.4��6%   $��338.2��64    � DataContext 5
      .  (Tema3.ViewModel.AlergenPreparatViewModel  5   
   .��5      � .+�5   
   �� -   5         ��Name$ alergen��5      $��8,10,0,56.8q�6$   $
��Left=�6�   $
��Left=�6�   $	��314��6  ��69   �� *
Alergeni+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6   �� *AlergenAles+$ PropertyChanged=� �� View 5      �� 5      .P�5      �� $��Alergen��6%    �� Width$	 250��66    �� DisplayMemberBinding 6B   �� *
denumire+$ PropertyChanged=�5      5      �� 5   
   $��Adauga Alergen��6   $
��Left=�6�   $��105,185,0,0q�6�   $	��Top=�6�   $	��105��6�   $��42��6	   J� RenderTransformOrigin$ 	0.369,0.6&�6  ��6*   �� 	 �� ElementName$	 alergen��
 �� Path$
 SelectedItem���6o   �� *AdaugaAlergen+$ PropertyChanged=�5      5      5      