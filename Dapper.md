# Dapper

## 安装



```
Install-Package Dapper
```





## 建数据库和表

```mysql
create database dappertest;


use dappertest;


create table users(
	id int primary key auto_increment,
    name varchar(20),
    email varchar(100),
    address varchar(100)
);
```





## 创建asp.net core 3.1 webapi项目



创建项目

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319092433610.png" alt="image-20200319092433610" style="zoom: 67%;" />



添加数据库连接字符串

![image-20200319092342797](C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319092342797.png)



添加 `ColumnAttributeTypeMapper` 和 `ColumnMapper` 类

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319094215845.png" alt="image-20200319094215845" style="zoom:67%;" />





在Startup类中注册

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319094337333.png" alt="image-20200319094337333" style="zoom:67%;" />



创建User类并加上注解

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319094636813.png" alt="image-20200319094636813" style="zoom:67%;" />



## Dapper创建mysql连接



<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319102215527.png" alt="image-20200319102215527" style="zoom:67%;" />



## 数据操作



### 添加数据

#### 插入单条数据

![image-20200319104413790](C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319104413790.png)

结果

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319102300755.png" alt="image-20200319102300755" style="zoom:67%;" />



#### 批量插入

![image-20200319104432116](C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319104432116.png)

结果

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319104459430.png" alt="image-20200319104459430" style="zoom:67%;" />





### 删除数据



<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319105408483.png" alt="image-20200319105408483" style="zoom:80%;" />

结果，id为6的数据已经删除

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319105431959.png" alt="image-20200319105431959" style="zoom:67%;" />







### 修改数据

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319105833879.png" alt="image-20200319105833879" style="zoom:80%;" />





结果 id为5的user的name修改成了ppp

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319105744933.png" alt="image-20200319105744933" style="zoom:67%;" />





### 查询数据



<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319110333892.png" alt="image-20200319110333892" style="zoom:67%;" />



结果

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319110310527.png" alt="image-20200319110310527" style="zoom: 50%;" />





<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319110528683.png" alt="image-20200319110528683" style="zoom: 67%;" />



结果

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319110623027.png" alt="image-20200319110623027" style="zoom:50%;" />





<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319111302880.png" alt="image-20200319111302880" style="zoom:67%;" />

结果

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319111239623.png" alt="image-20200319111239623" style="zoom:50%;" />



多表查询

添加一个project表

```
create table project(
	id int primary key auto_increment,
	user_id int,
    name varchar(20) 
);

insert into project(user_id,name) values(1,'项目1');
insert into project(user_id,name) values(1,'项目2');
insert into project(user_id,name) values(2,'项目3');
insert into project(user_id,name) values(2,'项目4');
insert into project(user_id,name) values(3,'项目5');
insert into project(user_id,name) values(3,'项目6');

```



<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319115500189.png" alt="image-20200319115500189" style="zoom:50%;" />

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319115433109.png" alt="image-20200319115433109" style="zoom:67%;" />



结果

<img src="C:\Users\gzh\Desktop\个人\文档\Dapper.assets\image-20200319115544254.png" alt="image-20200319115544254" style="zoom:67%;" />





