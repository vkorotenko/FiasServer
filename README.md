# FiasServer

## Описание
Сборный проект связанный с парсингом базы ФИАС. 
* fiasdl - загрузка  данных с сервера ФИАС
* Fias.Loader - обработчик данных занимается вставкой данных в конкретный бэкенд
  * Fias.Loader.EfMsSql - бэкенд для MS SQL   
  * ~~Fias.Loader.EfMySql - бэкенд для My SQL~~ не релизован
  * ~~Fias.Loader.EfPostgres - бэкенд для Postgres~~ не релизован



## Связанные проекты
Связанный репозиторий, офлайн парсер адресов, размер на диске ~180 мб. Размер в памяти ~600 мб.
https://github.com/vkorotenko/NAddressParser
