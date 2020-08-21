-- Transact-SQL Query
-- �������� ���� ������
create database travel_firm_db;
go
use travel_firm_db;

-- �������� ��� ���������� ������ ��������
create table LocationClients
(
id int identity primary key,

Country varchar(30) not null,
City varchar(30) not null,
Street varchar(30) not null,
House varchar(30) not null,
Flat varchar(30) null
);
go

-- ���������� ������ ��������
create table PassClients
(
id int identity primary key,
id_LocationClient int references LocationClients(id) on delete cascade,

Serial int not null,
Number int not null ,
Who_give varchar(40) not null,
When_get date not null
);
go

-- �������
create table Clients
(
id int identity primary key,
id_PassClient int not null references PassClients(id) on delete cascade,

FirstName varchar(20) not null,
MiddleName varchar(20) not null,
LastName varchar(20) not null,
Telephone varchar(20)
);
go

-- �������� ��� ���������� ������ ����������
create table LocationWorkers
(
id int identity primary key,

Country varchar(30) not null,
City varchar(30) not null,
Street varchar(30) not null,
House varchar(30) not null,
Flat varchar(30) null
);
go

-- ���������� ������ ����������
create table PassWorkers
(
id int identity primary key,
id_LocationWorker int references LocationWorkers(id) on delete cascade,

Serial int not null,
Number int not null ,
Who_give varchar(40) not null,
When_get date not null
);
go

--������
create table Departments
(
id int identity primary key,

Department varchar(30) not null
);
go

-- ���������
create table Posts
(
id int identity primary key,
id_Department int not null references Departments(id) on delete cascade,

Post varchar(30) not null
);
go

-- ���������
create table Workers
(
id int identity primary key,
id_PassWorker int not null references PassWorkers(id) on delete cascade,
id_Post int not null references Posts(id) on delete cascade,

Login varchar(40) not null,
Password varchar(40) not null,
Administrator varchar(10) not null,

FirstName varchar(20) not null,
MiddleName varchar(20) not null,
LastName varchar(20) not null,
Telephone varchar(20),
EMail varchar(40),
INN int not null
);
go

-- ������
create table Countries
(
id int identity primary key,

Country varchar(40) not null
);
go

-- ������
create table Cities
(
id int identity primary key,
id_Country int not null references Countries(id) on delete cascade,

City varchar(40) not null
);
go

-- �����
create table Hotels
(
id int identity primary key,
id_City int not null references Cities(id) on delete cascade,

Hotel varchar(40) not null,
Stars int not null
);
go

-- �������
create table Eats
(
id int identity primary key,

Eat varchar(20) not null
);
go

-- ��������� �� ���������
create table Airports
(
id int identity primary key,

Airport varchar(40) not null
);
go

-- ��������� �� �����������
create table BusStations
(
id int identity primary key,

BusStation varchar(40) not null
);
go

-- ����
create table Tours
(
id int identity primary key,
id_Hotel int not null references Hotels(id) on delete cascade,
id_Eat int not null references Eats(id) on delete cascade,
id_Airport int null references Airports(id) on delete cascade,
id_BusStation int null references BusStations(id) on delete cascade,

DateStart date not null,
Nights int default 6 not null,
Tourists int default 2 not null,
Price money not null,
CountTours int not null
);
go

-- ������
create table Orders
(
id int identity primary key,
id_Tour int not null references Tours(id) on delete cascade,
id_Client int not null references Clients(id) on delete cascade,
id_Worker int not null references Workers(id) on delete cascade,

DateOrder date not null
);
go

--��� ��� ���� ��� �� ������ ������������ (admin) ��� ������������ � �� � ���������� � ��������� ��
insert into LocationWorkers values('������','�����','�����','���','��������')
insert into PassWorkers values(1,0000,000000,'��� ������','12-12-2012')
insert into Departments values('����� ������')
insert into Posts values(1,'����������� ��������')
insert into Workers values(1,1,'admin','admin','admin','���','��������','�������','+380710000000','admin@mail.ru',0000)