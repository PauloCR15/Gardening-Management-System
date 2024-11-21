-- Crear la base de datos si no existe
create database Empresa_Jardineria;
go

-- Usar la base de datos creada
use [Empresa_Jardineria];
go

-- Crear la tabla MowingPreferenceType para normalizar las preferencias
create table MowingPreferenceType (
    MowingPreferenceID int PRIMARY KEY,
    Preference varchar(50) not null
);

-- Insertar los valores posibles en la tabla MowingPreferenceType
insert into MowingPreferenceType (MowingPreferenceID, Preference) values
(1, 'Quincenal'),
(2, 'Mensual');

-- Crear la tabla StatusType
create table StatusType(
    StatusID int PRIMARY KEY,
    StatusMeaning varchar(50)
);
go

-- Insertar valores en la tabla StatusType
insert into StatusType(StatusID, StatusMeaning) values
(1, 'Facturado'),
(2, 'Agendado'),
(3, 'En Proceso');

-- Crear la tabla Employees
create table Employees (
    EmployeeID int PRIMARY KEY not null,
    EmployeeBirthdate date not null,
    EmployeeLaterality varchar(255) not null,
    EmployeeStartDate date not null,
    EmployeeSalaryxHour decimal(10, 2) not null
);

-- Crear la tabla Clients
create table Clients (
    ClientID int PRIMARY KEY not null,
    ClientFullName varchar(255) not null,
    ClientFullDirection varchar(255) not null,
    Province varchar(255) not null,
    Canton varchar(255) not null,
    District varchar(255) not null,
    SummerMowingPreferenceID int not null,
    WinterMowingPreferenceID int not null,
    foreign key (SummerMowingPreferenceID) references MowingPreferenceType(MowingPreferenceID),
    foreign key (WinterMowingPreferenceID) references MowingPreferenceType(MowingPreferenceID)
);

-- Crear la tabla Maintenances
create table Maintenances (
    MaintenanceID int PRIMARY KEY identity(1,1) not null,
    ClientID int FOREIGN KEY REFERENCES Clients(ClientID) not null,
    MaintenanceExecutedDate date not null,
    MaintenanceScheduledDate date not null,
    PropertyAreaSize float not null,
    HedgeArea float,
    DaysWithoutMowing int not null,
    MowingPreferenceID int FOREIGN KEY REFERENCES MowingPreferenceType(MowingPreferenceID) not null,
    GrassType varchar(255) not null,
    HasAppliedProducts bit not null,
    AppliedProductName varchar(255),
    AppliedProductPrice float,
    MowingCostPerSquareMeter float not null,
	TotalCost float not null,
    ProductApplicationCostPerSquareMeter float,
    MaintenanceStatus int FOREIGN KEY REFERENCES StatusType(StatusID),
	NextMowingDate datetime not null
	);
	

-- Crear la tabla Machinery
create table Machinery (
    MachineryID int PRIMARY KEY identity(1,1) not null,
    MachineryDescription varchar(500) not null,
    MachineryType varchar(250) not null,
    MachineryActualUseTime float not null default 0,
    MachineryMaxHoursPerDay float not null,
	MaintenanceHours float not null
);
