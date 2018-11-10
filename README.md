# simple-mysql-viewer
A simple viewer of a table in a mysql database. I needed this and instead of bothering to google it, I made it myself. The need arised when i was dissatisfied with MySQL Workbench's horrible performance, bloated UI, and just being "too powerful", for my needs. I might be making a "simple mysql query"-application, but it will be a separate application, because I want simplicity i tools like these.

## Latest release
[Latest release](https://github.com/frankhaugen/simple-mysql-viewer/releases/latest)

## How it works
Simply open the exe, fill inn server address, database name, table name, username, and pasword, click "submit" and you'll see the table in all it's glory. You can also include a text-file in the same directory as the exe. The file must be named "input.secret", and the values, line-separated.

#### login.secret data format
```
Server address
Database name
Table name
Username
Password
```

### Screenshot
![Screenshot](/Graphics/Screenshot01_ver_1_0.png)