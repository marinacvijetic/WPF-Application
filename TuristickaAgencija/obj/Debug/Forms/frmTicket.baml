   M S B A M L   `   `   `  ����M  ITuristickaAgencija, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TuristickaAgencija.FormsTuristickaAgencija.Forms  5   	   (    "TuristickaAgencija.Forms.frmTicket   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:TuristickaAgencija.Forms     5   	   -   5          �Name$  
frmTicket1��5   	    � Title$ Add\Update Ticket��5   	   $	��550��6#   $	��700��60   .��5	      � ��5
   
   �� 5       �� ImageSource$Q K/TuristickaAgencija;component/Graphics/blue_background_picture_2_169441.jpg��6   .+�5   
   �� -   5         ��Name$ lblDestination��5      $��Destination:��6(   $
��Left=�6?   $��	54,60,0,0q�6Z   $	��Top=�6m   $	��250��6�   �� 5   
   -   5        $ lblSeatNumber��5      $��Seat Number:��6'   $
��Left=�6>   $��
54,173,0,0q�6Y   $	��Top=�6m   $	��250��6�   �� 5   
   -   5         ��Name$ txtDestination��5      $
��Left=�6*   $��26��6E   $��
392,60,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6y   $	��250��6�   �� 5   
   -   5        $ txtSeatNumber��5      $
��Left=�6)   $��26��6D   $��392,173,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��250��6�   �� 5   
   -   5         ��Name$ spTimetable��5       �� Orientation$ Vertical=�6*   $��Stretch=�6A   $	��141��6_   $��	0,227,0,0q�6l   $	��Top=�6   .+�5      �� $��64��6   $��0,5,0,0q�6%   $	��Top=�66   .+�5      �� -   5        $ lblDeparture��5      $��
Departure:��6.   $��26��6C   $	��250��6O   $	��Top=�6[   $��
54,0,419,0q�6s   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ dpDeparture��5      	 J� 	AllowDrop	 . 
   SelectedDateFormat$

 Long=�6D   $	��Top=�6^   $��392,-25,50,0q�6v   $��26��6�   5      �� 5      $��64��6   $��0,0,0,0q�6%   $	��Top=�66   .+�5      �� -	   5        $ 
lblArrival��5      $��Arrival:��6,   $��26��6?   $	��Top=�6K   $��
55,0,387,0q�6c     5      -
   5        $ 	dpArrival��5      	 . $

 Long=�6A   $	��Top=�6[   $��392,-25,50,0q�6s   5      5      �� 5   
   -   5        $ lblTicketPrice��5      $��Ticket price:��6(   $
��Left=�6@   $��
54,368,0,0q�6[   $	��Top=�6o   $	��250��6�   �� 5   
   -   5        $ txtTicketPrice��5      $
��Left=�6*   $��26��6E   $��392,368,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��250��6�   �� 5   
   -   5         ��Name$ btnSave��5      $
��Save��6"   $
��Left=�61   $��
54,441,0,0q�6L   $	��Top=�6`   $	��170��6x   $��30��6�   6�   �� 5    
   -   5        $ 	btnCancel��5       $��Cancel��6$   $
��Left=�65   $��472,441,0,0q�6P   $	��Top=�6e   $	��170��6}   $��30��6�   6�   �� 5!   
   -   5        $ TypeName��5!      $��Type of transport��6"   $
��Left=�6>   $��
54,113,0,0q�6Y   $	��Top=�6m   $	��250��6�   �� 5"   
   -   5         ��Name$ cbxType��5"       �� DisplayMemberPath$ Type of transport��6$    �� SelectedValuePath$ TypeID��6J   $
��Left=�6e   $��392,113,0,0q�6�   $	��Top=�6�   $	��250��6�   $��26��6�   5#      5$      