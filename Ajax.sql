USE [AjaxRevision]
GO
/****** Object:  Table [dbo].[tbl_student]    Script Date: 4/23/2024 6:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_student](
	[sr] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[email] [varchar](100) NULL,
	[mobno] [bigint] NULL,
	[clg] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[sr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_student] ON 

INSERT [dbo].[tbl_student] ([sr], [name], [email], [mobno], [clg]) VALUES (1, N'Nitesh Srivastava', N'nitesh@gmail.com', 8948508636, N'Gp Shahjahanpur')
INSERT [dbo].[tbl_student] ([sr], [name], [email], [mobno], [clg]) VALUES (2, N'Priyanshu Srivastava', N'priyanshu@gmail.com', 45678987654, N'GP SPN')
INSERT [dbo].[tbl_student] ([sr], [name], [email], [mobno], [clg]) VALUES (3, N'Atul  pal', N'atul@gmail.com', 98765434, N'GP Aurai')
INSERT [dbo].[tbl_student] ([sr], [name], [email], [mobno], [clg]) VALUES (4, N'Raj', N'raj@gmail.com', 85767476543636, N'CSJM')
INSERT [dbo].[tbl_student] ([sr], [name], [email], [mobno], [clg]) VALUES (5, N'Harshit Pandey', N'harshit@gmail.com', 57767536576, N'GPMK')
SET IDENTITY_INSERT [dbo].[tbl_student] OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_crudAjax]    Script Date: 4/23/2024 6:10:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_crudAjax]
@name varchar(100)=null,
@email varchar(100)=null,
@mobno bigint=0,
@clg varchar(100)=null,
@sr int=0,
@action int=0
as
begin 
if(@action=1)
begin
insert into tbl_student values(@name,@email,@mobno,@clg)
end
if(@action=2)
begin
select * from tbl_student order by sr asc
end
if(@action=3)
begin
update tbl_student set name=@name,email=@email,mobno=@mobno,clg=@clg where sr=@sr
end
if(@action=4)
begin
delete from tbl_student where sr=@sr
end
end
GO
