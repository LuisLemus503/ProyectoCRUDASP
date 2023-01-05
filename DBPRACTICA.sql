create database DBPRACTICA;
GO
use DBPRACTICA
go

drop table EMPLEADO
create table EMPLEADO(
IdEmpleado int primary key identity,
Nombre varchar(500),
Edad int,
Salario decimal,
FechadeIngreso date
)

set dateformat dmy
go

insert into EMPLEADO(nombre,edad,salario,fechadeingreso)values('Luis',25,500.42,CONVERT(date,'14/01/1998'))
insert into EMPLEADO(nombre,edad,salario,fechadeingreso)values('Miguel',30,250.20,CONVERT(date,'12/05/1994'))
insert into EMPLEADO(nombre,edad,salario,fechadeingreso)values('Jose',25,500.42,CONVERT(date,'10/08/1993'))
insert into EMPLEADO(nombre,edad,salario,fechadeingreso)values('Karen',25,500.42,CONVERT(date,'13/07/2000'))
insert into EMPLEADO(nombre,edad,salario,fechadeingreso)values('Felipe',25,500.42,CONVERT(date,'14/09/2005'))


select*from EMPLEADO