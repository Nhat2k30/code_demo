create database QLSinhVien

create table Khoa
(
	MaKhoa varchar(10) not null primary key,
	TenKhoa nvarchar(50)
)
create table Lop
(
	MaLop char(7) not null primary key,
	TenLop nvarchar(50),
	MaKhoa varchar(10),
	constraint fk_Lop_Khoa foreign key (MaKhoa) references Khoa(MaKhoa)
)
create table SinhVien
(
	MaSinhVien char(10) not null primary key,
	HoTen nvarchar(50),
	NgaySinh date,
	MaLop char(7),
	constraint fk_SinhVien_Lop foreign key (MaLop) references Lop(MaLop)
)

create table MonHoc
(
	MaMonHoc varchar(20) not null primary key,
	TenMonHoc nvarchar(50)
)
create table Diem
(
	MaSinhVien char(10) not null,
	MaMonHoc varchar(20) not null,
	Diem float,
	constraint pk_Diem primary key (MaSinhVien, MaMonHoc),
	constraint fk_Diem_SinhVien foreign key (MaSinhVien) references SinhVien(MaSinhVien),
	constraint fk_Diem_MonHoc foreign key (MaMonHoc) references MonHoc(MaMonHoc)
)

insert into Khoa values('K01', N'Khoa công nghệ thông tin')
insert into Khoa values('K02', N'Khoa công nghệ thực phẩm')
insert into Khoa values('K03', N'Khoa điện tử')
select * from Khoa

///////
insert into Lop values('09DHTH1', N'09 đại học tin học 1', 'K01')
insert into Lop values('09DHTH2', N'09 đại học tin học 2', 'K01')
insert into Lop values('09DHTH3', N'09 đại học tin học 3', 'K01')

insert into Lop values('09DHTP1', N'09 đại học thực phẩm 1', 'K02')
insert into Lop values('09DHTP2', N'09 đại học thực phẩm 2', 'K02')
insert into Lop values('09DHTP3', N'09 đại học thực phẩm 3', 'K02')

insert into Lop values('09DHDT1', N'09 đại học điện tử 1', 'K03')
insert into Lop values('09DHDT2', N'09 đại học điện tử 2', 'K03')
insert into Lop values('09DHDT3', N'09 đại học điện tử 3', 'K03')
insert into Lop values('09DHTH4', N'09 địa hpcj tin học 4', 'K03')
select * from Lop
//////
set dateformat mdy
insert into SinhVien values('2001180120', N'Phạm Mộng Kha', '06/05/2000', '09DHTH2')
insert into SinhVien values('2001181095', N'Chu Nguyễn Gia Hân', '05/05/2000', '09DHTH1')
insert into SinhVien values('2001180146', N'Nguyễn Sỹ Thành', '04/20/2000', '09DHTH3')
insert into SinhVien values('2001180127', N'Phạm Thiên Nga', '12/18/2000', '09DHTP1')
insert into SinhVien values('2001181025', N'Đào Thị Lài', '04/08/2000', '09DHTP2')
insert into SinhVien values('2001180145', N'Nguyễn Thanh Vy', '06/26/2000', '09DHTP3')
insert into SinhVien values('2001180111', N'Nguyễn Thị Kim Oanh', '07/22/2000', '09DHDT1')
insert into SinhVien values('2001181789', N'Trần Thị Như Yến', '08/16/2000', '09DHDT2')
insert into SinhVien values('2001180226', N'Từ Thanh Phong', '12/24/2000', '09DHDT3')
select * from SinhVien

insert into SinhVien values('2001180117', N'KKKKKKKKKKKKKK', '24/12/2000', '09DHTH1')

insert into MonHoc values('MH001', N'Lập trình hướng đối tượng')
insert into MonHoc values('MH002', N'Công nghệ Java')
insert into MonHoc values('MH003', N'Hóa thực phẩm')
insert into MonHoc values('MH004', N'Anh toàn vệ sinh thực phẩm')
insert into MonHoc values('MH005', N'Điện gia dụng')
insert into MonHoc values('MH006', N'Hệ thống điện')
select * from MonHoc


////
insert into Diem values('2001180120', 'MH001', 7)
insert into Diem values('2001180120', 'MH002', 6)
insert into Diem values('2001181095', 'MH002', 8)
insert into Diem values('2001180146', 'MH001', 9)

insert into Diem values('2001180127', 'MH003', 9)
insert into Diem values('2001180127', 'MH004', 7.5)

insert into Diem values('2001181025', 'MH003', 7.5)

insert into Diem values('2001180145', 'MH004', 6.5)


insert into Diem values('2001180111', 'MH005', 5.5)
insert into Diem values('2001180111', 'MH006', 8)

insert into Diem values('2001181789', 'MH006', 9)

insert into Diem values('2001180226', 'MH006', 10)

select * from Diem
select * from Diem where MaSinhVien = '2001180120' and MaMonHoc = 'MH001'
