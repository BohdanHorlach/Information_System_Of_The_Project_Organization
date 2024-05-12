using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;



namespace Information_System_Of_The_Project_Organization.Models
{
    public partial class Information_System_Of_The_Project_OrganizationContext : DbContext
    {
        public Information_System_Of_The_Project_OrganizationContext()
        {
        }

        public Information_System_Of_The_Project_OrganizationContext(DbContextOptions<Information_System_Of_The_Project_OrganizationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<DepartmentsEmployee> DepartmentsEmployees { get; set; } = null!;
        public virtual DbSet<DepartmentsLeader> DepartmentsLeaders { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<EmployeeCategory> EmployeeCategories { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<EquipmentDepartment> EquipmentDepartments { get; set; } = null!;
        public virtual DbSet<EquipmentUsedInProject> EquipmentUsedInProjects { get; set; } = null!;
        public virtual DbSet<OrdersFromSubcontractor> OrdersFromSubcontractors { get; set; } = null!;
        public virtual DbSet<Pact> Pacts { get; set; } = null!;
        public virtual DbSet<PactProject> PactProjects { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<ProjectEmployee> ProjectEmployees { get; set; } = null!;
        public virtual DbSet<ResponsibilityInTheProject> ResponsibilityInTheProjects { get; set; } = null!;
        public virtual DbSet<Subcontractor> Subcontractors { get; set; } = null!;
        public virtual DbSet<TypeOfOrderInSubcontractor> TypeOfOrderInSubcontractors { get; set; } = null!;
        public virtual DbSet<TypeOfWorkForEquipment> TypeOfWorkForEquipments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Information_System_Of_The_Project_Organization;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName, "IDX_Categories_CategoryName");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DepartamentsName).HasMaxLength(50);
            });

            modelBuilder.Entity<DepartmentsEmployee>(entity =>
            {
                entity.ToTable("DepartmentsEmployee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.DismissalDate).HasColumnType("date");

                entity.Property(e => e.IdDepartaments).HasColumnName("ID_Departaments");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");
            });

            modelBuilder.Entity<DepartmentsLeader>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.DismissalDate).HasColumnType("date");

                entity.Property(e => e.IdDepartaments).HasColumnName("ID_Departaments");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.Education, "IDX_Employees_Education");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Education).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeCategory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssignmentDate).HasColumnType("date");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Destination).HasMaxLength(50);

                entity.Property(e => e.EquipmentName).HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentDepartment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.DismissalDate).HasColumnType("date");

                entity.Property(e => e.IdDepartaments).HasColumnName("ID_Departaments");

                entity.Property(e => e.IdEquipment).HasColumnName("ID_Equipment");
            });

            modelBuilder.Entity<EquipmentUsedInProject>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.DismissalDate).HasColumnType("date");

                entity.Property(e => e.IdEquipment).HasColumnName("ID_Equipment");

                entity.Property(e => e.IdProjects).HasColumnName("ID_Projects");

                entity.Property(e => e.IdTypeOfWork).HasColumnName("ID_TypeOfWork");
            });

            modelBuilder.Entity<OrdersFromSubcontractor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.IdProject).HasColumnName("ID_Project");

                entity.Property(e => e.IdSubcontractors).HasColumnName("ID_Subcontractors");

                entity.Property(e => e.IdTypeOfOrderInSubcontractors).HasColumnName("ID_TypeOfOrderInSubcontractors");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.ReceivedDate).HasColumnType("date");
            });

            modelBuilder.Entity<Pact>(entity =>
            {
                entity.ToTable("Pact");

                entity.HasIndex(e => e.EndDate, "IDX_Pact_EndDate");

                entity.HasIndex(e => e.PactName, "IDX_Pact_PactName");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmailCustomer).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.FullNameCustomer).HasMaxLength(150);

                entity.Property(e => e.PactName).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<PactProject>(entity =>
            {
                entity.ToTable("PactProject");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdPact).HasColumnName("ID_Pact");

                entity.Property(e => e.IdProject).HasColumnName("ID_Project");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasIndex(e => e.NameProject, "IDX_Projects_NameProject");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.NameProject).HasMaxLength(150);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<ProjectEmployee>(entity =>
            {
                entity.ToTable("ProjectEmployee");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.DismissalDate).HasColumnType("date");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdProject).HasColumnName("ID_Project");

                entity.Property(e => e.IdResponsibility).HasColumnName("ID_Responsibility");
            });

            modelBuilder.Entity<ResponsibilityInTheProject>(entity =>
            {
                entity.ToTable("ResponsibilityInTheProject");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ResponsibilityName).HasMaxLength(50);
            });

            modelBuilder.Entity<Subcontractor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameOrganization).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeOfOrderInSubcontractor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TypeOfOrder).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeOfWorkForEquipment>(entity =>
            {
                entity.ToTable("TypeOfWorkForEquipment");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TypeOfWork).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
