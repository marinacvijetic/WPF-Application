   M S B A M L   `   `   `  ����M  ITuristickaAgencija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TuristickaAgencijaTuristickaAgencija  5   	   #    TuristickaAgencija.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TuristickaAgencija     5   	   -   5          �Name$  dataGrid��5   	    � Title$ Travel Agency��5      $	��550��6   $	��950��6)   .��5      � ��5   
   �� 5       �� ImageSource$ Graphics/tourism.jpg��6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGridCentral��5      $��Center=�6,   $
��auto��6I   $��Center=�6X   $
��auto��6s      AlternatingRowBackground
 ��� �   
IsReadOnly .    CanUserAddRows .     SelectionUnit$ FullRow=�5         SelectionMode$ Single=�6+   �� 5   
   $��Center=�6   $��50��62   $	��Top=�6?   $
��auto��6W   	 �� Orientation$	 
Horizontal=�6d   .+�5      �� -   5        
 ��Name$
 
btnBooking��5      $��Booking��6)   $��15(�6;   $
��Left=�6I   $	��Top=�6d   $��90��6|   $��45��6�   ��5      �� 5      $ Graphics/$RMW034V.png��6!    � BindingGroup 5      &   System.Windows.Data.BindingGroup  5      5      �� 5      -   5        $
 	btnHotels��5      $��Hotels��6(   $��15(�69   $
��Left=�6G   $	��Top=�6b   $��90��6z   $��45��6�   ��5      �� 5      $ Graphics/$RMW034V.png��6!   5       �� 5!      -   5        $
 btnCustomers��5!      $��	Customers��6+   $��15(�6?   $
��Left=�6M   $	��Top=�6h   $��90��6�   $��45��6�   ��5"      �� 5#      $ Graphics/$RMW034V.png��6!   5%      �� 5&      -   5        $
 
btnTickets��5&      $��Tickets��6)   $��15(�6;   $
��Left=�6I   $	��Top=�6d   $��90��6|   $��45��6�   ��5'      �� 5(      $ Graphics/$RMW034V.png��6!   5*      �� 5+      -   5        $
 btnEmployees��5+      $��	Employees��6+   $��15(�6?   $
��Left=�6M   $��95��6h   $��0,0,0,5q�6s   ��5,      �� 5-      $ Graphics/$RMW034V.png��6!   5/      �� 50      -   5        $
 btnTypes��50      $��Types of transport��6'   $��15(�6D   $
��Left=�6R   $	��140��6m   $��0,0,0,5q�6y   ��51      �� 52      $ Graphics/$RMW034V.png��6!   54      �� 55      -	   5        $
 btnTransport��55      $��	Transport��6+   $��15(�6?   $
��Left=�6M   $��90��6h   $��0,0,0,5q�6s   ��56      �� 57      $ Graphics/$RMW034V.png��6!   59      �� 5:      -
   5        $
 btnOU��5:      $��Oranisational Units��6$   $��15(�6B   $
��Left=�6P   $	��Top=�6k   $	��145��6�   $��45��6�   ��5;      �� 5<      $ Graphics/$RMW034V.png��6!   5>      �� 5?      -   5        $
 btnDestinations��5?      $��Destinations��6.   $��15(�6E   $
��Left=�6S   $	��Top=�6n   $	��100��6�   $��45��6�   ��5@      �� 5A      $ Graphics/$RMW034V.png��6!   5C      5D      �� 5E   
   $	 
Horizontal=�6   $��Center=�6.   $
��auto��6K   $��Bottom=�6Z   $
��auto��6u   .+�5F      �� -   5        $
 btnAdd��5F      $	��Add��6%   $��18(�63   $	��130��6A   $��40��6M   ��5G      �� 5H      $ Graphics/$RMW034V.png��6!   5J      �� 5K      -   5        $
 	btnUpdate��5K      $��Update��6(   $��18(�69   $	��130��6G   $��40��6S   ��5L      �� 5M      $ Graphics/$RMW034V.png��6!   5O      �� 5P      -   5        $
 	btnDelete��5P      $��Delete��6(   $��18(�69   $	��130��6G   $��40��6S   ��5Q      �� 5R      $ Graphics/$RMW034V.png��6!   5T      5U      5X      5Y      