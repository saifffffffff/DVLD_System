# DVLD System - Driving & Vehicle Licensing Department Management System

## Overview

**DVLD (Driving & Vehicle Licensing Department)** is a comprehensive Windows Forms desktop application built with .NET Framework 4.8 for managing driving license operations. The system handles the complete lifecycle of driving license applications, tests, issuance, renewals, replacements, and international driving licenses.

## Architecture

The solution follows a **3-layer architecture** with clear separation of concerns:

```
DVLD_System.sln
├── DVLD.Presentation (Windows Forms UI Layer)
│   └── DVLD_WindowsForms.csproj         → WinExe (Main Entry Point)
├── DVLD.Application (Business Logic Layer)
│   └── DVLD_Application.csproj          → Library (Entities & Business Rules)
└── DVLD.Data (Data Access Layer)
    └── DVLD_Data.csproj                 → Library (Repositories & DTOs)
```

### Layer Responsibilities

| Layer | Project | Responsibility |
|-------|---------|----------------|
| **Presentation** | `DVLD_WindowsForms` | Windows Forms UI, User Controls, Forms, User Interaction |
| **Application** | `DVLD_Application` | Business Entities, Validation, Business Rules, Entity Management |
| **Data** | `DVLD_Data` | Database Access, Repositories, DTOs, SQL Scripts |

---

## Features

### 🧑 People Management
- **Add/Update/Delete** person records
- **Search & Filter** people by various criteria
- **Person Details** view with photo support
- National number validation and uniqueness

### 🚗 Driving License Applications
#### Local Driving License Applications
- New application creation with license class selection
- Application status tracking (New, Cancelled, Completed)
- **Test Scheduling**: Vision, Written, Street tests
- **Issue License** after passing all required tests
- **Show Application Info** with complete details

#### International Driving License Applications
- Issue international licenses based on valid local licenses
- International license management and tracking

#### License Operations
- **Renew Driving License** - Extend expired licenses
- **Replace Driving License** - Lost/Damaged license replacement
- **Release Detained License** - Handle detained licenses with fines
- **Show License Info** - Complete license details view
- **Person License History** - Full license history per person

### 📝 Test Management
- **Test Types Management** - Vision, Written, Street tests configuration
- **Test Appointments** - Schedule, reschedule, cancel test appointments
- **Take Test** - Record test results (Pass/Fail)
- **Test Results Tracking** - Complete test history per application

### 👥 User Management
- **User Authentication** - Login system with username/password
- **User Management** - Add, update, delete users
- **User Roles & Permissions** - Role-based access control
- **Change Password** - Secure password update
- **Login History** - Track user login activity

### ⚙️ System Configuration
- **Application Types Management** - Configure license application types and fees
- **Test Types Management** - Manage test types, descriptions, and fees
- **License Classes** - Define vehicle categories (Motorcycle, Car, Truck, Bus, etc.)
- **Countries Management** - Nationality/country reference data

### 🔍 Search & Reporting
- **Advanced Filtering** - Multi-criteria search across all entities
- **DataGrid Views** - Sortable, filterable data grids
- **Detail Views** - Comprehensive information screens

---

## Technology Stack

| Component | Technology |
|-----------|------------|
| **Framework** | .NET Framework 4.8 |
| **UI Framework** | Windows Forms (WinForms) |
| **Language** | C# |
| **Database** | Microsoft SQL Server |
| **Data Access** | ADO.NET with Repository Pattern |
| **Architecture** | 3-Layer (Presentation, Business, Data) |
| **Design Patterns** | Repository Pattern, DTO Pattern, Inheritance (Base Forms/Controls) |

---

## Database Schema

The system uses a SQL Server database named **`DVLD`** with the following key tables:

| Table | Description |
|-------|-------------|
| `People` | Person information (applicants, drivers, users) |
| `Users` | System users with roles and permissions |
| `Applications` | Base application records |
| `LocalDrivingLicenseApplications` | Local license applications |
| `InternationalLicenses` | International license records |
| `Licenses` | Issued driving licenses |
| `LicenseClasses` | Vehicle categories (Class 1-7) |
| `TestTypes` | Test configurations (Vision, Written, Street) |
| `TestAppointments` | Scheduled test appointments |
| `Tests` | Test results |
| `DetainedLicenses` | Detained/impounded licenses |
| `Drivers` | Driver information linking people to licenses |
| `Countries` | Nationality/country reference |
| `ApplicationTypes` | Application type definitions with fees |

> **Database Script**: See `DVLD.Data/script.sql` for complete schema creation script.

---

## Project Structure

### DVLD.Presentation (UI Layer)
```
DVLD.Presentation/
├── Program.cs                          # Application Entry Point
├── Assets/                             # Images, Icons, Resources
├── Helpers/
│   ├── clsGlobal.cs                    # Global settings & current user
│   ├── clsUtil.cs                      # Utility functions
│   └── clsValidate.cs                  # Input validation helpers
├── Screens/                            # Windows Forms
│   ├── Core/                           # Base forms (Login, Main, Dialogs)
│   ├── People/                         # People management forms
│   ├── Users/                          # User management forms
│   ├── Applications/
│   │   ├── LocalDrivingLicenseApplication/
│   │   ├── InternationalDrivingLicenseApplication/
│   │   ├── RenewDrivingLicenseApplication/
│   │   ├── ReplaceDrivingLicenseApplication/
│   │   └── ReleaseLicenseApplication/
│   ├── Licenses/                       # License info forms
│   ├── Tests/                          # Test taking forms
│   ├── TestAppointments/               # Test scheduling forms
│   ├── TestTypes/                      # Test type management
│   ├── ApplicationTypes/               # Application type management
│   ├── DetainedLicenses/               # Detained license forms
│   ├── Drivers/                        # Driver management
│   └── InternationalLicenses/          # International license forms
└── UserControls/                       # Reusable UI Components
    ├── PeopleControls/
    ├── ApplicationsControls/
    ├── LicensesControls/
    ├── UsersControls/
    ├── TestsControls/
    ├── InternationalLicensesControls/
    └── DriversControls/
```

### DVLD.Application (Business Layer)
```
DVLD.Application/
├── Entities/                           # Business Entities
│   ├── clsEntity.cs                    # Base entity class
│   ├── clsPerson.cs                    # Person entity
│   ├── clsUser.cs                      # User entity
│   ├── clsApplication.cs               # Base application
│   ├── clsLocalDrivingLicenseApplication.cs
│   ├── clsInternationalLicense.cs
│   ├── clsLicense.cs
│   ├── clsLicenseClass.cs
│   ├── clsTest.cs
│   ├── clsTestAppointment.cs
│   ├── clsTestType.cs
│   ├── clsDriver.cs
│   ├── clsDetainedLicense.cs
│   ├── clsCountry.cs
│   ├── clsApplicationType.cs
│   └── clsAutoMapper.cs                # DTO-Entity mapping
├── Properties/
└── app.config
```

### DVLD.Data (Data Layer)
```
DVLD.Data/
├── Repositories/                       # Repository Implementations
│   ├── PersonRepository.cs
│   ├── UserRepository.cs
│   ├── ApplicationRepository.cs
│   ├── LocalDrivingLicenseApplicationRepository.cs
│   ├── InternationalLicenseRepository.cs
│   ├── LicenseRepository.cs
│   ├── LicenseClassRepository.cs
│   ├── TestRepository.cs
│   ├── TestAppointmentRepository.cs
│   ├── TestTypeRepository.cs
│   ├── DriverRepository.cs
│   ├── DetainedLicenseRepository.cs
│   ├── CountryRepository.cs
│   └── ApplicationTypeRepository.cs
├── Interfaces/                         # Repository Contracts
│   ├── IPersonRepository.cs
│   ├── IUserRepository.cs
│   ├── IGenericRepository.cs
│   └── ... (one per entity)
├── Dtos/                               # Data Transfer Objects
│   ├── PersonDto.cs
│   ├── UserDto.cs
│   ├── ApplicationDto.cs
│   └── ... (one per entity)
├── clsDataSettings.cs                  # Connection string management
├── script.sql                          # Database creation script
└── Properties/
```

---

## Getting Started

### Prerequisites
- **Visual Studio 2022** (or VS 2019 with .NET Framework 4.8 SDK)
- **SQL Server 2019/2022** (Express or higher)
- **.NET Framework 4.8** Runtime

### Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd DVLD_System
   ```

2. **Set up the Database**
   - Open SQL Server Management Studio (SSMS)
   - Run the script: `DVLD.Data/script.sql`
   - This creates the `DVLD` database with all tables, constraints, and sample data

3. **Configure Connection String**
   - Open `DVLD.Data/clsDataSettings.cs`
   - Update the connection string to match your SQL Server instance:
   ```csharp
   public static string ConnectionString = 
       "Server=YOUR_SERVER;Database=DVLD;Trusted_Connection=True;";
   ```

4. **Build the Solution**
   - Open `DVLD_System.sln` in Visual Studio
   - Build Solution (`Ctrl+Shift+B`)
   - Ensure all three projects build successfully

5. **Run the Application**
   - Set `DVLD_WindowsForms` as Startup Project
   - Press `F5` or click **Start**

### Default Login
After first database setup, you may need to create an initial user directly in the database or check the script for default credentials.

---

## Key Design Decisions

### Repository Pattern
- Each entity has a dedicated repository implementing `IGenericRepository<T>`
- Clean separation between data access and business logic
- Easy to mock for unit testing

### Entity Base Class (`clsEntity`)
- Provides common CRUD operations: `Save()`, `Delete()`, `IsExist()`
- Mode tracking: `Add` vs `Update`
- Validation hooks

### DTO Pattern
- Data Transfer Objects decouple database schema from business entities
- Explicit mapping in `clsAutoMapper` and entity constructors
- Prevents over-posting and exposes only required data

### Inheritance-Based UI
- `ScreenToInherit` - Base form with common functionality
- `DialogToInherit` - Base dialog form
- `UserControlToInherite` - Base user control
- Reduces code duplication across 40+ forms

### Global State Management
- `clsGlobal` holds current logged-in user and application settings
- Thread-safe for WinForms single-threaded model

---

## Business Rules Highlights

### License Application Flow
1. **Create Application** → Select License Class
2. **Schedule Tests** → Vision → Written → Street (sequential)
3. **Take Tests** → Record Pass/Fail for each
4. **Issue License** → Only after all required tests pass
5. **License Active** → Valid for 10 years (configurable)

### License Renewal
- Can renew up to 6 months before expiry
- Requires valid medical fitness (vision test)
- Creates new application of type "Renew"

### License Replacement
- **Lost** or **Damaged** options
- Invalidates old license immediately
- Issues new license with same expiry date

### International License
- Requires valid local license of class 3 (Car)
- Valid for 1 year
- Links to original local license

### Detained Licenses
- Traffic violations result in license detention
- Fine fees must be paid
- Release requires "Release Detained License" application

---

## Development Guidelines

### Adding New Features
1. **Data Layer**: Add DTO, Repository Interface, Repository Implementation
2. **Application Layer**: Add Entity class inheriting from `clsEntity`
3. **Presentation Layer**: Add Forms/UserControls as needed

### Coding Standards
- **Naming**: PascalCase for classes/methods, camelCase for fields
- **Prefix**: `cls` for classes (legacy convention), `ctrl` for UserControls
- **Async**: Use async/await for database operations where possible
- **Validation**: Input validation in both UI and Entity layers

### Testing
- Repository layer can be unit tested with mocked interfaces
- Business logic in Entities should be testable independently
- UI testing requires WinForms test framework

---

## Troubleshooting

### Common Issues

| Issue | Solution |
|-------|----------|
| **Build Errors** | Ensure .NET Framework 4.8 Developer Pack is installed |
| **Database Connection Failed** | Check `clsDataSettings.cs` connection string; verify SQL Server is running |
| **Missing References** | Rebuild solution; check Project References between layers |
| **Login Fails** | Verify Users table has records; check password hashing matches |

### Debug Tips
- Enable **SQL Profiler** to trace database calls
- Check **Output Window** in VS for binding errors
- Use **Breakpoints** in Repository layer to inspect DTOs

---

## License

This project is developed for educational/training purposes as part of a Driving License Management System course.

---

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add YourFeature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a Pull Request

---

## Support

For issues or questions:
- Create an issue in the repository
- Check existing issues for known problems
- Review the database script for schema questions

---

*Last Updated: October 2026*