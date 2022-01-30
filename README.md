Pastebin
========

Main solution file is Pastebin.sln

Configuration

Copy appSettings.json to appSettings.Development.json and

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "default": "server=<Your Database Host>;uid=<Your Database User>;pwd=<Your Database User Password>;database=<Your Database Name>"
  }
}
```

SQL for the database is in /sql


Requirements

- node
- dot

Development

- Develop client-app with Visual Studio Code
- Develop backend with Visual Studio 2022 Community

   npm run dev


Build

   npm run build
   dotnet publish --configuration release --output publish --runtime linux-x64 --self-contained
   


/etc/systemd/system/pastebin.service

```
[Unit]
Description=Pastebin web application

[Service]
Type=simple
ExecStart=/srv/www/pastebin.matthias-luebben.de/app/bin/Pastebin.UI
WorkingDirectory=/srv/www/pastebin.matthias-luebben.de/app/bin
User=www-data
Group=www-data

[Install]
WantedBy=multi-user.target
```


systemctl enable pastebin.service


