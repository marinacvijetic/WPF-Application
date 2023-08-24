/* INSERT naredba - tabela 'Vrste prevoza' */
 insert into tblType (TypeName)
values ('Voz');

insert into tblType(TypeName)
values('Brod');

Insert into tblType (TypeName)
values ('Sopstveni prevoz'); 

/*UPDATE naredba - tabela 'Vrste prevoza' */
update tblType
set TypeName = 'Privatan prevoz'
where TypeID=5;
/*DELETE naredba - tabela 'Vrste revoza'*/
delete from tblType 
where TypeID=4;
/* SELECT naredba - tabela 'Vrste prevoza' */
select TypeID as 'ID Vrste', TypeName as 'Vrsta prevoza'
from tblType; 

/* INSERT naredba - tabela 'Karte' */
insert into tblTicket (TypeID, Destination, SeatNumber, TicketPrice, Departure, Arrival )
values ('1','Berlin', '8-9', '8800', '2021-07-12 14:00', '2021-07-12 12:45');

insert into tblTicket (TypeID, Destination, SeatNumber, TicketPrice, Departure, Arrival)
values ('3','Tivat', '2', '4500', '2020-12-12 13:45', '2021-07-12 12:45');

insert into tblTicket (TypeID, Destination, SeatNumber, TicketPrice, Departure, Arrival)
values ('5','Banja Luka', '1-4', '16000', '2020-11-30 17:20', '2021-07-12 12:45');

insert into tblTicket (TypeID, Destination, SeatNumber, TicketPrice, Departure, Arrival)
values ('3','Zlatibor', '3-5', '9000', '2021-12-29 10:00', '2021-07-12 12:45');

insert into tblTicket (TypeID, Destination, SeatNumber, TicketPrice, Departure, Arrival)
values ('2','Budva', '7A', '5800', '2021-03-22 18:00', '2021-07-12 12:45');  

/*UPDATE naredba - tabela 'Karte' */
update tblTicket 
set TicketPrice = '9000'
where TicketID = 3;

/*DELETE naredba - tabela 'Karte' */
delete from tblTicket
where TicketID = 8;

/*SELECT naredba - tabela 'Karte' */
select TicketID as 'ID Karte', TypeName as 'Vrsta prevoza', Destination as 'Destinacije', SeatNumber as 'Broj Sedista', TicketPrice as 'Cena karte', Timetable as 'Red Voznje'
from tblTicket inner join tblType on tblTicket.TypeID = tblType.TypeID;


/* INSERT naredba - tabela 'Organizaciona jedinica' */

 insert into tblOrganisationUnit (NameOfUnit)
values ('Accounting');

insert into tblOrganisationUnit (NameOfUnit)
values ('Finance');

insert into tblOrganisationUnit (NameOfUnit)
values ('HR');

insert into tblOrganisationUnit (NameOfUnit)
values ('Research & Development');  

/*UPDATE naredba - tabela 'Organizaciona jedinica' */
update tblOrganisationUnit
set NameOfUnit = 'Human Resources'
where OUID = 4;

/*DELETE naredba - tabela 'Organizaciona jedinica' */
delete from tblOrganisationUnit
where OUID=5;

/*SELECT naredba - tabela 'Organizaciona jedinica' */
select OUID as 'ID Org. Jedinice', NameOfUnit as 'Naziv jedinice'
from tblOrganisationUnit;

/* INSERT naredba - tabela 'Destinacije' */

insert into tblDestination (State, City)
values ('Nemacka', 'Berlin');

insert into tblDestination (State, City)
values ('Crna Gora', 'Tivat');

insert into tblDestination (State, City)
values ('BIH', 'Banja Luka');

insert into tblDestination (State, City)
values ('Srbija', 'Zlatibor');

insert into tblDestination (State, City)
values ('Crna Gora', 'Budva');    

/*UPDATE naredba - tabela 'Destinacije' */
update tblDestination
set State='Hrvatska', City='Zagreb'
where DestinationID=8;

/*DELETE naredba - tabela 'Destinacije'*/
delete from tblDestination
where DestinationID=8;

/*SELECT naredba - tabela 'Destinacije' */
select State + ' ' + City as 'Drzava i Grad'
from tblDestination;

/*INSERT naredba -tabela 'Trasport' */
insert into tblTransport(TicketID)
values ('3');

insert into tblTransport(TicketID)
values ('4');

insert into tblTransport(TicketID)
values ('5');

insert into tblTransport(TicketID)
values ('6');

insert into tblTransport(TicketID)
values ('7');  


/*DELETE naredba - tabela 'Transport' */
delete from tblTransport 
where TransportID=1;

/*SELECT naredba - tabela 'Transport' */
select TransportID as 'ID Transporta', TypeName as 'Vrsta prevoza', Destination as 'Destinacija', Departure as 'Vreme polaska', Arrival as 'Vreme dolaska'
from tblTransport inner join tblTicket on tblTransport.TicketID = tblTicket.TicketID
	inner join tblType on tblTicket.TypeID=tblType.TypeID;

 
/* INSERT naredba - tabela 'Musterija' */
insert into tblCustomer (NameC, SurnameC, JMBG, City, Adress, Contact, CardNumber)
values ('Milan',  'Simic', '1235974635814', 'Kraljevo', 'Ustanicka bb', '065 237 555', '9873546914987');

insert into tblCustomer (NameC , SurnameC, JMBG, City, Adress, Contact, CardNumber)
values ('Sanja', 'Stojic', '9678425469782', 'Sabac', 'Cvetna 17', '063 257 333', '9751469823645');

insert into tblCustomer (NameC, SurnameC, JMBG, City, Adress, Contact, CardNumber)
values ('Marko', 'Radic', '1754896245874', 'Uzice', 'Petra Kocica 9a', '061 232 855', '697432569847');

insert into tblCustomer (NameC, SurnameC, JMBG, City, Adress, Contact, CardNumber)
values ('Igor',  'Markovic', '0708987236487', 'Novi Sad', 'Koste Racina 24', '067 789 325', '36978542369');

insert into tblCustomer (NameC, SurnameC, JMBG, City, Adress, Contact, CardNumber)
values ('Tijana', 'Lukic', '5874632156987', 'Sremska Mitrovica', 'Vodna 16', '069 323 585', '26547896321');  

/*UPDATE naredba - tabela 'Musterija' */
update tblCustomer
set Contact = '064 499 6106'
where CustomerID = 2;

/*DELETE naredba - tabela 'Musterija' */
delete from tblCustomer
where CustomerID = 7;

/*SELECT naredba - tabela 'Musterija' */
select CustomerID as 'ID Musterije', NameC + ' ' + SurnameC as 'Ime i prezime', JMBG as 'JMBG', City as 'Grad', Adress as 'Adresa',
Contact as 'Kontakt', CardNumber as 'Broj kartice'
from tblCustomer;

/* INSERT naredba - tabela 'Zaposleni' */
insert into tblEmployee (NameE, SurnameE, OUID, IdentificationNumber, City, Adress, PhoneNumber, Email)
values ('Ratko', 'Savic', '3', '1254698743612', 'Beograd', ' ', '069 326 999', 'ratkos2@gmail.com' );  */

insert into tblEmployee (NameE, SurnameE, OUID, IdentificationNumber, City, Adress, PhoneNumber, Email)
values ('Petar', 'Jovanovic', '4', '7895413612632', 'Nis', ' ', '063 745 219', 'jovanovic6@gmail.com' );

insert into tblEmployee (NameE, SurnameE, OUID, IdentificationNumber, City, Adress, PhoneNumber, Email)
values ('Andrea', 'Lalic', '2', '8745696123645', 'Novi Sad', 'Cara Dusana 17', '060 111 787', 'lalic.a22@gmail.com' );

insert into tblEmployee (NameE, SurnameE, OUID, IdentificationNumber, City, Adress, PhoneNumber, Email)
values ('Ana', 'Andjelic', '5', '8745691236458', 'Sombor', 'Kralja Petra 3b', '062 322 669', 'andjelic93@gmail.com' );

insert into tblEmployee (NameE, SurnameE, OUID, IdentificationNumber, City, Adress, PhoneNumber, Email)
values ('Stefan', 'Bojic', '1', '3642178965472', 'Sremska Mitrovica', 'Ozrenska 17', '065 583 262', 'ratkos2@gmail.com' ); 

/*UPDATE naredba - tabela 'Zaposleni' */
update tblEmployee
set Adress = 'Bul. Kralja Aleksandra'
where EmployeeID=5;

/*DELETE naredba - tabela 'Zaposleni'*/
delete from tblEmployee
where City='Novi Sad';

/*SELECT naredba - tabela 'Zaposleni' */
select * 
from tblEmployee;


/*INSERT naredba -tabela 'Hotel' */
insert into tblHotel (Name, Adress, RoomNumber, Contact, PricePerNight, DestinationID)
values ('Indigo', 'Friedrichshain 58', '208', '+491 59089745', '25', '3' );  

insert into tblHotel (Name, Adress, RoomNumber, Contact, PricePerNight, DestinationID)
values ('Helada', 'Belani bb', '302', '+382 3255987', '50', '4');

insert into tblHotel (Name, Adress, RoomNumber, Contact, PricePerNight, DestinationID)
values ('Astoria', 'Marsala Tita 15', '101', '+382 32789546', '63', '4');

insert into tblHotel (Name, Adress, RoomNumber, Contact, PricePerNight, DestinationID)
values ('Talija', 'Srpska 9', '25', '+387 675589', '43', '5');

insert into tblHotel (Name, Adress, RoomNumber, Contact, PricePerNight, DestinationID)
values ('Tre Canne', 'Donji Bulevar bb', '605', '+382 569742', '67', '7');

insert into tblHotel (Name, Adress, RoomNumber, Contact, PricePerNight, DestinationID)
values ('Mona', 'Naselje Jezero 26', '302', '+381 65879554', '70', '6'); 

/*UPDATE naredba - tabela 'Hotel' */
update tblHotel
set PricePerNight = '80'
where DestinationID = 7;

/*DELETE naredba - tabela 'Hotel' */
delete from tblHotel
where HotelID=6;

/*SELECTE naredba - tabela 'Hotel' */
select Name as 'Naziv hotela', Adress as 'Adresa', RoomNumber as 'Broj sobe', Contact as 'Kontakt',
	   PricePerNight as 'Cena po nocenju', State + ' ' + City as 'Drzava i grad'
from tblHotel inner join tblDestination on tblHotel.DestinationID = tblDestination.DestinationID;

/* INSERT naredba - tabela 'Rezervacije' */
insert into tblBooking (EmployeeID, CustomerID, NumberOfPassengers, HotelID, ReservationDate, TransportID, TotalPrice)
values('4', '10', '4', '7', '2020-11-30 21:40', '5', '32000');

insert into tblBooking (EmployeeID, CustomerID, NumberOfPassengers, HotelID, ReservationDate, TransportID, TotalPrice)
values('9', '3', '2', '3', '2021-07-13 14:40', '3', '20000');

insert into tblBooking (EmployeeID, CustomerID, NumberOfPassengers, HotelID, ReservationDate, TransportID, TotalPrice)
values('9', '9', '3', '9', '2021-12-29 19:00', '6', '45000');

insert into tblBooking (EmployeeID, CustomerID, NumberOfPassengers, HotelID, ReservationDate, TransportID, TotalPrice)
values('4', '4', '2', '8', '2021-03-23 10:00', '7', '35000');

insert into tblBooking (EmployeeID, CustomerID, NumberOfPassengers, HotelID, ReservationDate, TransportID, TotalPrice)
values('9', '8', '1', '5', '2020-12-12 14:20', '4', '15000'); 

/*UPDATE naredba = tabela 'Rezervacije' */
update tblBooking
set TotalPrice = '45000'
where TransportID= 7;

/*DELETE naredba - tabela 'Rezervacije' */
delete from tblBooking
where CustomerID=1;

/*SELECT naredba - tabela 'Rezervacije' */
select NameC + ' ' + SurnameC as 'Musterija', NameE + ' ' + SurnameE as 'Zaposleni', Name as 'Naziv Hotela', TypeName as 'Vrsta Prevoza'

from tblBooking inner join tblCustomer on tblBooking.CustomerID=tblCustomer.CustomerID
inner join tblEmployee on tblBooking.EmployeeID=tblEmployee.EmployeeID
inner join tblHotel on tblBooking.HotelID=tblHotel.HotelID
inner join tblTransport on tblBooking.TransportID=tblTransport.TransportID
inner join tblTicket on tblTransport.TicketID=tblTicket.TicketID
inner join tblType on tblTicket.TypeID=tblType.TypeID;



