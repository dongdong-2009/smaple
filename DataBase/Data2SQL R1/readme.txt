Data2SQL数据脚本生成器
功能：批量将数据库表中的数据转换成SQL脚本。
可以配置Data2SQL.d2s，运行程序来生成SQL，也可以通过如下命令行来运行。
命令行：Data2SQL.exe 配置文件 [输出文件]
输出文件：指定导出的SQL保存的文件路径，如果不指定，则在当前目录下生成一文件。
配置文件：标准的windows ini文件，在[DB]段下配置数据库，[Outports]段下配要导成SQL的表，“=”前表示生成数据库将要插入的表名，表后是生成的数据的SQL。
例如：
文件开始：
[DB]
Data Source=127.0.0.1
User ID=sa
Password=1234
Initial Catalog=Northwind
[Outports]
--Categories
Categories=SELECT * FROM Categories
--Orders
Orders=SELECT * FROM Orders WHERE (EmployeeID = 6)
--Shippers
Shippers=SELECT * FROM Shippers

文件结束。

如有问题，可与我联系:
Email:roadbridge@163.com
http://blog.csdn.net/highroad/
喻国军
2005.11.24
