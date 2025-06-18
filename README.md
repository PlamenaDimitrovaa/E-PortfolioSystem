# E-PortfolioSystem
Система за управление на електронно портфолио – ASP.NET MVC + Bootstrap + Entity Framework

# **Описание:**
Уеб приложение за управление на студентски портфолиа, включващо:
- Студенти и преподаватели
- Проекти с прикачени документи
- Оценяване от преподаватели
- Нотификации (известия)
- Роли: Администратор, Преподавател, Студент, HR
- Публични профили, CV, препоръки, сертификати, опит и умения
- Модул за комуникация между HR и студенти

# **Технологии:**
-   ASP.NET Core MVC (.NET 9) – backend
-   Entity Framework Core – ORM и работа с база (SQL Server)
-   Identity – управление на потребители/роли
-   Bootstrap – адаптивен дизайн и UI
-   JavaScript/jQuery – модални прозорци, нотификации, AJAX
-   Services – Layered архитектура (Controller → Service → DbContext)
-   Dependency Injection за управление на service dependencies
-   File Upload – съхранение на прикачени файлове в wwwroot/Uploaded/Files
-   PDF генериране за CV
-   Нотификации – съобщения при крайни срокове, оценки, HR контакти

# **Полезни линкове:**
- ASP.NET Core документация - https://learn.microsoft.com/en-us/aspnet/core
- Entity Framework Core - https://learn.microsoft.com/en-us/ef/core
- Bootstrap - https://getbootstrap.com
- Използван Bootstrap Template - https://startbootstrap.com/theme/personal
- MS SQL Server - https://learn.microsoft.com/en-us/sql/sql-server
- ASP.NET Identity & Roles - https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity
- https://dotnet.microsoft.com/en-us/download/dotnet/9.0 - installing .NET 9 SDK
- https://www.microsoft.com/en-us/sql-server/sql-server-downloads - installing SQL Server

# **Основни функционалности:**
1. Роли & потребители
   - Администратор – управление на роли и потребители
   - Преподавател – създава предмети, оценява студенти, управлява записването им
   - Студент – добавя проекти към предмети, вижда оценки и CV
   - HR – разглежда публични профили, изпраща съобщения
     
2. Предмети
   - CRUD операции
   - Студенти се записват/отписват от предмети
   - Прикачване и редакция на документи
     
3. Проекти & Оценяване
   - Преподавателите добавят оценки (SubjectGrade, ProjectGrade), обратна връзка и тип
   - Оценките се записват във Evaluation таблица, агрегирани в Project и Subject
     
4. Нотификации
   - Уведомления към студенти и преподаватели при крайни срокове, оценки, HR съобщения
   - AJAX методи за маркиране на нотификация като прочетена или получаване на брой
     
5. Публични профили & CV генерация
   - HR потребители виждат публичните профили
   - PDF CV се генерира динамично (био, опит, образование, умения, сертификати)
     
6. HR контакт модул
   - HR изпраща съобщения до студенти, които получават нотификация
   - CRUD операции за съобщения
     
7. Препоръки
  - HR потребител може да добави препоръка към публичния профил на студент, като посочи текст с обратна връзка и името си
  - Всички оставени препоръки за даден студент се визуализират в секцията „Препоръки“ в публичния му профил
  - Всеки HR може да редактира или премахне само препоръките, които той е създал. Това се осъществява чрез проверка на собствеността върху препоръката
  - Препоръки могат да се добавят само от влезли HR потребители и само към профили, които са публични
    
8. Вграден чат
  - Позволява на потребителите (напр. студенти и HR, преподаватели и студенти) да комуникират директно
  - Всяко съобщение се записва в базата и е достъпно в историята на чата
  - Възможност за преглед на всички разговори, сортирани по дата и участници

# **Структура на проекта:**
- Controllers/ – MVC контролери по модули: Admin, Teacher, Student, HR, Notifications
- Services/ – бизнес логика, обработва заявки и взаимодействие с БД
- Data/ – модели и EPortfolioDbContext
- ViewModels/ – DTO-та за предаване на данни към View
- Views/ – Razor страници
- wwwroot/Uploaded/Files – съхранение на файлове

# **Как да стартирате:**
1. Клониране:
```
git clone https://github.com/PlamenaDimitrovaa/E-PortfolioSystem.git
cd E-PortfolioSystem
```
2. Конфигуриране на appsettings.json за връзка с база данни (SQL Server)
3. Миграции и update:
```
dotnet ef database update
```
4. Стартиране:
```
dotnet run
```
