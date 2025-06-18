# E-PortfolioSystem
Electronic Portfolio Management System – ASP.NET MVC + Bootstrap + Entity Framework

# **Description:**
- A web application for managing student portfolios, featuring:
- Students and Teachers
- Projects with attached documents
- Teacher evaluations
- Notifications system
- Roles: Administrator, Teacher, Student, HR
- Public profiles, CVs, recommendations, certificates, experience, and skills
- Communication module between HR and students

# **Technologies Used:**
-   ASP.NET Core MVC (.NET 9) – backend
-   Entity Framework Core – ORM and database handling (SQL Server)
-   Identity – user and role management
-   Bootstrap – responsive design and UI
-   JavaScript/jQuery – modals, notifications, AJAX
-   Services – layered architecture (Controller → Service → DbContext)
-   Dependency Injection for managing service dependencies
-   File Upload – storing attached documents in wwwroot/Uploaded/Files
-   PDF generation for CV export
-   Notifications – deadline alerts, evaluation updates, HR messages

# **Useful Links:**
- ASP.NET Core Documentation - https://learn.microsoft.com/en-us/aspnet/core
- Entity Framework Core - https://learn.microsoft.com/en-us/ef/core
- Bootstrap - https://getbootstrap.com
- Bootstrap Template Used - https://startbootstrap.com/theme/personal
- MS SQL Server - https://learn.microsoft.com/en-us/sql/sql-server
- ASP.NET Identity & Roles - https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity
- https://dotnet.microsoft.com/en-us/download/dotnet/9.0 - installing .NET 9 SDK
- https://www.microsoft.com/en-us/sql-server/sql-server-downloads - installing SQL Server

# **Main Features:**
1. Roles & Users
   - Administrator – manages roles and users
   - Teacher – creates subjects, evaluates students, manages enrollment
   - Student – adds projects to subjects, views evaluations and CV
   - HR – browses public profiles, sends messages
     
2. Subjects
   - CRUD operations
   - Students can enroll/unenroll from subjects
   - Uploading and editing of documents
     
3. Projects & Evaluation
   - Teachers add evaluations (SubjectGrade, ProjectGrade), feedback, and evaluation type
   - Evaluations are saved in the Evaluation table and linked to Projects and Subjects
     
4. Notifications
   - Students and teachers receive alerts for deadlines, evaluations, and HR messages
   - AJAX methods for marking as read and checking unread count
     
5. Public Profiles & CV Generation
   - HR users can view student public profiles
   - PDF CVs are generated dynamically (bio, experience, education, skills, certificates)
     
6. HR Contact Module
   - HR users can send messages to students, who receive notifications
   - CRUD operations for messages
     
7. Recommendations
  - HR can add recommendations to a student's public profile, including name and feedback
  - All recommendations are visible in the student’s profile
  - HR can only edit or delete their own recommendations
  - Recommendations are available only for public profiles
    
8. Integrated Chat
  - Allows users (e.g. students and HR, teachers and students) to communicate directly
  - All messages are stored in the database and accessible in chat history
  - Users can view all conversations, sorted by date and participants

# **Project Structure:**
- Controllers/ – MVC controllers per module: Admin, Teacher, Student, HR, Notifications..
- Services/ – Business logic layer handling requests and DB operations
- Data/ – Data models and EPortfolioDbContext
- ViewModels/ – DTOs for passing data to the views
- Views/ – Razor pages
- wwwroot/Uploaded/Files – File storage for uploaded documents

# **How to Run::**
1. Clone the repository:
```
git clone https://github.com/PlamenaDimitrovaa/E-PortfolioSystem.git
cd E-PortfolioSystem
```
2. Configure appsettings.json with your SQL Server connection string
3. Apply migrations and update database:
```
dotnet ef database update
```
4. Run the application:
```
dotnet run
```
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
