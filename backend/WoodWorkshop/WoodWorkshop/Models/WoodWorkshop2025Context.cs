using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WoodWorkshop.Models;

public partial class WoodWorkshop2025Context : DbContext
{
    public WoodWorkshop2025Context()
    {
    }

    public WoodWorkshop2025Context(DbContextOptions<WoodWorkshop2025Context> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionType> ActionTypes { get; set; }

    public virtual DbSet<Advancesalary> Advancesalaries { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<EmployeeMaterial> EmployeeMaterials { get; set; }

    public virtual DbSet<ForgotPassword> ForgotPasswords { get; set; }

    public virtual DbSet<InformationUser> InformationUsers { get; set; }

    public virtual DbSet<InputSubMaterial> InputSubMaterials { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<ProcessProductError> ProcessProductErrors { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductRequestImage> ProductRequestImages { get; set; }

    public virtual DbSet<ProductSubMaterial> ProductSubMaterials { get; set; }

    public virtual DbSet<Productimage> Productimages { get; set; }

    public virtual DbSet<RefundOrderStatus> RefundOrderStatuses { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestImage> RequestImages { get; set; }

    public virtual DbSet<RequestProduct> RequestProducts { get; set; }

    public virtual DbSet<RequestProductsSubmaterial> RequestProductsSubmaterials { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<StatusJob> StatusJobs { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<StatusProduct> StatusProducts { get; set; }

    public virtual DbSet<StatusRequest> StatusRequests { get; set; }

    public virtual DbSet<StatusUser> StatusUsers { get; set; }

    public virtual DbSet<SubMaterial> SubMaterials { get; set; }

    public virtual DbSet<Suppliermaterial> Suppliermaterials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Whitelist> Whitelists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=sqlwoodmanagement.c6dyskm0mbo0.us-east-1.rds.amazonaws.com;port=3306;database=WoodWorkshop2025;user=admin;password=Laptrinh2025", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<ActionType>(entity =>
        {
            entity.HasKey(e => e.ActionTypeId).HasName("PRIMARY");

            entity.ToTable("action_type");

            entity.Property(e => e.ActionTypeId).HasColumnName("action_type_id");
            entity.Property(e => e.ActionName)
                .HasMaxLength(255)
                .HasColumnName("action_name");
        });

        modelBuilder.Entity<Advancesalary>(entity =>
        {
            entity.HasKey(e => e.AdvanceSalaryId).HasName("PRIMARY");

            entity.ToTable("advancesalary");

            entity.HasIndex(e => e.JobId, "FKh7ti9am409kr7he0i7ovkgg9s");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.AdvanceSalaryId).HasColumnName("advance_salary_id");
            entity.Property(e => e.Amount)
                .HasPrecision(38, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IsAdvanceSuccess)
                .HasColumnType("bit(1)")
                .HasColumnName("is_advance_success");
            entity.Property(e => e.IsApprove)
                .HasColumnType("bit(1)")
                .HasColumnName("is_approve");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.PaymentDate)
                .HasMaxLength(6)
                .HasColumnName("payment_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Job).WithMany(p => p.Advancesalaries)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FKh7ti9am409kr7he0i7ovkgg9s");

            entity.HasOne(d => d.User).WithMany(p => p.Advancesalaries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("advancesalary_ibfk_1");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<EmployeeMaterial>(entity =>
        {
            entity.HasKey(e => e.EmpMaterialId).HasName("PRIMARY");

            entity.ToTable("employee_materials");

            entity.HasIndex(e => e.JobId, "FK6w32wv1jekvi16tlgvlqnbpjk");

            entity.HasIndex(e => e.ProductSubMaterialId, "FK8ust13b9nhy5dkbfi0nss97dc");

            entity.HasIndex(e => e.RequestProductsSubmaterialsId, "FK93s1hhmqpwwk8sxbxrsmv9om2");

            entity.HasIndex(e => e.EmployeeId, "FKlu70qu3xy53sr908el4ewt933");

            entity.Property(e => e.EmpMaterialId).HasColumnName("emp_material_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.ProductSubMaterialId).HasColumnName("product_sub_material_id");
            entity.Property(e => e.RequestProductsSubmaterialsId).HasColumnName("request_products_submaterials_id");
            entity.Property(e => e.TotalMaterial).HasColumnName("total_material");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FKlu70qu3xy53sr908el4ewt933");

            entity.HasOne(d => d.Job).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK6w32wv1jekvi16tlgvlqnbpjk");

            entity.HasOne(d => d.ProductSubMaterial).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.ProductSubMaterialId)
                .HasConstraintName("FK8ust13b9nhy5dkbfi0nss97dc");

            entity.HasOne(d => d.RequestProductsSubmaterials).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.RequestProductsSubmaterialsId)
                .HasConstraintName("FK93s1hhmqpwwk8sxbxrsmv9om2");
        });

        modelBuilder.Entity<ForgotPassword>(entity =>
        {
            entity.HasKey(e => e.Fpid).HasName("PRIMARY");

            entity.ToTable("forgot_password");

            entity.HasIndex(e => e.UserUserId, "UK_436rcwp67sud355lgi3s4p1cv").IsUnique();

            entity.Property(e => e.Fpid).HasColumnName("fpid");
            entity.Property(e => e.ExpirationTime)
                .HasMaxLength(6)
                .HasColumnName("expiration_time");
            entity.Property(e => e.Otp).HasColumnName("otp");
            entity.Property(e => e.UserUserId).HasColumnName("user_user_id");

            entity.HasOne(d => d.UserUser).WithOne(p => p.ForgotPassword)
                .HasForeignKey<ForgotPassword>(d => d.UserUserId)
                .HasConstraintName("FK4smi7oqy3gk1eji1gtnytl9gq");
        });

        modelBuilder.Entity<InformationUser>(entity =>
        {
            entity.HasKey(e => e.InforId).HasName("PRIMARY");

            entity.ToTable("information_user");

            entity.Property(e => e.InforId).HasColumnName("infor_id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.Bank)
                .HasMaxLength(20)
                .HasColumnName("bank");
            entity.Property(e => e.BankAccountNumber)
                .HasMaxLength(20)
                .HasColumnName("bank_account_number");
            entity.Property(e => e.CityProvince)
                .HasMaxLength(30)
                .HasColumnName("city_province")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.District)
                .HasMaxLength(30)
                .HasColumnName("district")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .HasColumnName("fullname");
            entity.Property(e => e.HasAccount).HasColumnName("has_account");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .HasColumnName("phone_number");
            entity.Property(e => e.Wards)
                .HasMaxLength(30)
                .HasColumnName("wards")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<InputSubMaterial>(entity =>
        {
            entity.HasKey(e => e.InputId).HasName("PRIMARY");

            entity.ToTable("input_sub_material");

            entity.HasIndex(e => e.SubMaterialId, "FK32ey1l1wrps7qglujftsexinv");

            entity.HasIndex(e => e.ActionTypeId, "FK7bani79mn3epgffdbsflgltmf");

            entity.Property(e => e.InputId).HasColumnName("input_id");
            entity.Property(e => e.ActionTypeId).HasColumnName("action_type_id");
            entity.Property(e => e.CodeInput)
                .HasMaxLength(255)
                .HasColumnName("code_input");
            entity.Property(e => e.CreateDate)
                .HasMaxLength(6)
                .HasColumnName("create_date");
            entity.Property(e => e.DateInput)
                .HasMaxLength(6)
                .HasColumnName("date_input");
            entity.Property(e => e.OutPrice)
                .HasPrecision(38, 2)
                .HasColumnName("out_price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReasonExport)
                .HasMaxLength(255)
                .HasColumnName("reason_export");
            entity.Property(e => e.SubMaterialId).HasColumnName("sub_material_id");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(38, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.ActionType).WithMany(p => p.InputSubMaterials)
                .HasForeignKey(d => d.ActionTypeId)
                .HasConstraintName("FK7bani79mn3epgffdbsflgltmf");

            entity.HasOne(d => d.SubMaterial).WithMany(p => p.InputSubMaterials)
                .HasForeignKey(d => d.SubMaterialId)
                .HasConstraintName("FK32ey1l1wrps7qglujftsexinv");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PRIMARY");

            entity.ToTable("jobs");

            entity.HasIndex(e => e.RequestProductId, "FK5v6x7t8cdj0vcekwktl1eft59");

            entity.HasIndex(e => e.OrderDetailId, "FK9mawqgqvqfbgsxpmbtvc4kux7");

            entity.HasIndex(e => e.StatusId, "FKcomuel2dc6xc98j5lxkihastn");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Cost)
                .HasPrecision(38, 2)
                .HasColumnName("cost");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.JobLog)
                .HasColumnType("bit(1)")
                .HasColumnName("job_log");
            entity.Property(e => e.JobName)
                .HasMaxLength(255)
                .HasColumnName("job_name");
            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.OriginalQuantityProduct).HasColumnName("original_quantity_product");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.QuantityProduct).HasColumnName("quantity_product");
            entity.Property(e => e.Reassigned)
                .HasColumnType("bit(1)")
                .HasColumnName("reassigned");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TimeFinish)
                .HasMaxLength(6)
                .HasColumnName("time_finish");
            entity.Property(e => e.TimeStart)
                .HasMaxLength(6)
                .HasColumnName("time_start");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK5rp8qlixeemvvdu8fk3a4ih2m");

            entity.HasOne(d => d.Product).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("jobs_ibfk_2");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FK5v6x7t8cdj0vcekwktl1eft59");

            entity.HasOne(d => d.Status).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK60v5o2j0qplf8h1wtm18mb31x");

            entity.HasOne(d => d.User).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("jobs_ibfk_1");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PRIMARY");

            entity.ToTable("materials");

            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.MaterialName)
                .HasMaxLength(255)
                .HasColumnName("material_name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.StatusId, "FKjiqtdoncm83ebe7alrdhcqda7");

            entity.HasIndex(e => e.RefundId, "FKo8cpokv9obipamoc2debmp7hq");

            entity.HasIndex(e => e.InforId, "infor_id");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CityProvince)
                .HasMaxLength(255)
                .HasColumnName("city_province");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.ContractDate)
                .HasMaxLength(6)
                .HasColumnName("contract_date");
            entity.Property(e => e.Deposite)
                .HasPrecision(38, 2)
                .HasColumnName("deposite");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Discount)
                .HasPrecision(38, 2)
                .HasColumnName("discount");
            entity.Property(e => e.District)
                .HasMaxLength(255)
                .HasColumnName("district");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasColumnName("fullname");
            entity.Property(e => e.InforId).HasColumnName("infor_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderFinish)
                .HasMaxLength(6)
                .HasColumnName("order_finish");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.Refund)
                .HasPrecision(38, 2)
                .HasColumnName("refund");
            entity.Property(e => e.RefundId).HasColumnName("refund_id");
            entity.Property(e => e.Response)
                .HasMaxLength(255)
                .HasColumnName("response");
            entity.Property(e => e.SpecialOrder)
                .HasColumnType("bit(1)")
                .HasColumnName("special_order");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(38, 2)
                .HasColumnName("total_amount");
            entity.Property(e => e.Wards)
                .HasMaxLength(255)
                .HasColumnName("wards");

            entity.HasOne(d => d.Infor).WithMany(p => p.Orders)
                .HasForeignKey(d => d.InforId)
                .HasConstraintName("orders_ibfk_2");

            entity.HasOne(d => d.RefundNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RefundId)
                .HasConstraintName("FKo8cpokv9obipamoc2debmp7hq");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FKjiqtdoncm83ebe7alrdhcqda7");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PRIMARY");

            entity.ToTable("orderdetails");

            entity.HasIndex(e => e.OrderId, "order_id");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.RequestProductId, "request_product_id");

            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(38, 2)
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("orderdetails_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("orderdetails_ibfk_2");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("orderdetails_ibfk_3");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PRIMARY");

            entity.ToTable("positions");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionName)
                .HasMaxLength(255)
                .HasColumnName("position_name");
        });

        modelBuilder.Entity<ProcessProductError>(entity =>
        {
            entity.HasKey(e => e.ProcessProductErrorId).HasName("PRIMARY");

            entity.ToTable("process_product_error");

            entity.HasIndex(e => e.JobId, "FK2tfk8j3ss17pdp6c1kgvdra34");

            entity.HasIndex(e => e.ProductId, "FKg5p3w5f0vngx7f7e8ps3s8cq5");

            entity.HasIndex(e => e.RequestProductId, "FKmoh505ou60fy2xnndikay0wv0");

            entity.Property(e => e.ProcessProductErrorId).HasColumnName("process_product_error_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.IsFixed)
                .HasColumnType("bit(1)")
                .HasColumnName("is_fixed");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");
            entity.Property(e => e.Solution)
                .HasMaxLength(255)
                .HasColumnName("solution");

            entity.HasOne(d => d.Job).WithMany(p => p.ProcessProductErrors)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK2tfk8j3ss17pdp6c1kgvdra34");

            entity.HasOne(d => d.Product).WithMany(p => p.ProcessProductErrors)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FKg5p3w5f0vngx7f7e8ps3s8cq5");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.ProcessProductErrors)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FKmoh505ou60fy2xnndikay0wv0");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.StatusId, "FKsngqpr54og4mcg69ijn2sasfg");

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.CompletionTime).HasColumnName("completion_time");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.EnddateWarranty).HasColumnName("enddate_warranty");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.Price)
                .HasPrecision(38, 2)
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("products_ibfk_2");

            entity.HasOne(d => d.Status).WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FKsngqpr54og4mcg69ijn2sasfg");
        });

        modelBuilder.Entity<ProductRequestImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PRIMARY");

            entity.ToTable("product_request_images");

            entity.HasIndex(e => e.RequestProductId, "FK6ey4o5p8p7us41csl6qhjjlfx");

            entity.Property(e => e.ProductImageId).HasColumnName("product_image_id");
            entity.Property(e => e.ExtensionName)
                .HasMaxLength(255)
                .HasColumnName("extension_name");
            entity.Property(e => e.FileOriginalName)
                .HasMaxLength(255)
                .HasColumnName("file_original_name");
            entity.Property(e => e.FullPath)
                .HasMaxLength(255)
                .HasColumnName("full_path");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.ProductRequestImages)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FK6ey4o5p8p7us41csl6qhjjlfx");
        });

        modelBuilder.Entity<ProductSubMaterial>(entity =>
        {
            entity.HasKey(e => e.ProductSubMaterialId).HasName("PRIMARY");

            entity.ToTable("product_sub_materials");

            entity.HasIndex(e => e.InputId, "FKsontpag31fkmh10fclno79jj8");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.SubMaterialId, "sub_material_id");

            entity.Property(e => e.ProductSubMaterialId).HasColumnName("product_sub_material_id");
            entity.Property(e => e.InputId).HasColumnName("input_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.SubMaterial).HasColumnName("sub_material");
            entity.Property(e => e.SubMaterialId).HasColumnName("sub_material_id");

            entity.HasOne(d => d.Input).WithMany(p => p.ProductSubMaterials)
                .HasForeignKey(d => d.InputId)
                .HasConstraintName("FKsontpag31fkmh10fclno79jj8");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSubMaterials)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("product_sub_materials_ibfk_2");
        });

        modelBuilder.Entity<Productimage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PRIMARY");

            entity.ToTable("productimages");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.Property(e => e.ProductImageId).HasColumnName("product_image_id");
            entity.Property(e => e.ExtensionName)
                .HasMaxLength(255)
                .HasColumnName("extension_name");
            entity.Property(e => e.FileOriginalName)
                .HasMaxLength(255)
                .HasColumnName("file_original_name");
            entity.Property(e => e.FullPath)
                .HasMaxLength(255)
                .HasColumnName("full_path");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Productimages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("productimages_ibfk_1");
        });

        modelBuilder.Entity<RefundOrderStatus>(entity =>
        {
            entity.HasKey(e => e.RefundId).HasName("PRIMARY");

            entity.ToTable("refund_order_status");

            entity.Property(e => e.RefundId).HasColumnName("refund_id");
            entity.Property(e => e.RefundName)
                .HasMaxLength(255)
                .HasColumnName("refund_name");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PRIMARY");

            entity.ToTable("requests");

            entity.HasIndex(e => e.StatusId, "FKfe2n50twyoyhbygknc3k4ff6b");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CityProvince)
                .HasMaxLength(255)
                .HasColumnName("city_province");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.District)
                .HasMaxLength(255)
                .HasColumnName("district");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .HasMaxLength(255)
                .HasColumnName("fullname");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.RequestDate)
                .HasColumnType("datetime")
                .HasColumnName("request_date");
            entity.Property(e => e.Response)
                .HasMaxLength(255)
                .HasColumnName("response");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Wards)
                .HasMaxLength(255)
                .HasColumnName("wards");

            entity.HasOne(d => d.Status).WithMany(p => p.Requests)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FKfe2n50twyoyhbygknc3k4ff6b");

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("requests_ibfk_1");
        });

        modelBuilder.Entity<RequestImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PRIMARY");

            entity.ToTable("request_images");

            entity.HasIndex(e => e.RequestId, "FK66yetebhdmco2bmqsndfrec85");

            entity.HasIndex(e => e.OrderId, "FK7a55ichtysco1sycrm3vysrwr");

            entity.Property(e => e.ProductImageId).HasColumnName("product_image_id");
            entity.Property(e => e.ExtensionName)
                .HasMaxLength(255)
                .HasColumnName("extension_name");
            entity.Property(e => e.FileOriginalName)
                .HasMaxLength(255)
                .HasColumnName("file_original_name");
            entity.Property(e => e.FullPath)
                .HasMaxLength(255)
                .HasColumnName("full_path");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("image");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.RequestId).HasColumnName("request_id");

            entity.HasOne(d => d.Order).WithMany(p => p.RequestImages)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK7a55ichtysco1sycrm3vysrwr");
        });

        modelBuilder.Entity<RequestProduct>(entity =>
        {
            entity.HasKey(e => e.RequestProductId).HasName("PRIMARY");

            entity.ToTable("request_products");

            entity.HasIndex(e => e.StatusId, "FK7ilmeju320yqe5hnal7whb6gw");

            entity.HasIndex(e => e.RequestId, "FK8m3pan2s459jqlrv1v6nk11rm");

            entity.HasIndex(e => e.OrderId, "FKme4r4d17um7qon380xxp0qiwv");

            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");
            entity.Property(e => e.CompletionTime).HasColumnName("completion_time");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price)
                .HasPrecision(19, 4)
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.RequestProductName)
                .HasMaxLength(50)
                .HasColumnName("request_product_name");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Order).WithMany(p => p.RequestProducts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FKme4r4d17um7qon380xxp0qiwv");

            entity.HasOne(d => d.Status).WithMany(p => p.RequestProducts)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK7ilmeju320yqe5hnal7whb6gw");
        });

        modelBuilder.Entity<RequestProductsSubmaterial>(entity =>
        {
            entity.HasKey(e => e.RequestProductsSubmaterialsId).HasName("PRIMARY");

            entity.ToTable("request_products_submaterials");

            entity.HasIndex(e => e.InputId, "FK50ttmnhcigvcx23yc39wweher");

            entity.HasIndex(e => new { e.RequestProductId, e.SubMaterialId }, "request_product_id").IsUnique();

            entity.HasIndex(e => e.SubMaterialId, "sub_material_id");

            entity.Property(e => e.RequestProductsSubmaterialsId).HasColumnName("request_products_submaterials_id");
            entity.Property(e => e.InputId).HasColumnName("input_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");
            entity.Property(e => e.SubMaterial).HasColumnName("sub_material");
            entity.Property(e => e.SubMaterialId).HasColumnName("sub_material_id");

            entity.HasOne(d => d.Input).WithMany(p => p.RequestProductsSubmaterials)
                .HasForeignKey(d => d.InputId)
                .HasConstraintName("FK50ttmnhcigvcx23yc39wweher");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.RequestProductsSubmaterials)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("request_products_submaterials_ibfk_1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PRIMARY");

            entity.ToTable("salaries");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.SalaryId).HasColumnName("salary_id");
            entity.Property(e => e.Amount)
                .HasPrecision(38, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("salaries_ibfk_1");
        });

        modelBuilder.Entity<StatusJob>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("status_job");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Des)
                .HasMaxLength(255)
                .HasColumnName("des");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .HasColumnName("status_name");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("status_order");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<StatusProduct>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("status_product");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Descriptions)
                .HasMaxLength(255)
                .HasColumnName("descriptions");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .HasColumnName("status_name");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<StatusRequest>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("status_request");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<StatusUser>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PRIMARY");

            entity.ToTable("status_user");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<SubMaterial>(entity =>
        {
            entity.HasKey(e => e.SubMaterialId).HasName("PRIMARY");

            entity.ToTable("sub_materials");

            entity.HasIndex(e => e.MaterialId, "material_id");

            entity.Property(e => e.SubMaterialId).HasColumnName("sub_material_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.SubMaterialName)
                .HasMaxLength(255)
                .HasColumnName("sub_material_name");

            entity.HasOne(d => d.Material).WithMany(p => p.SubMaterials)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("sub_materials_ibfk_1");
        });

        modelBuilder.Entity<Suppliermaterial>(entity =>
        {
            entity.HasKey(e => e.SupplierMaterial1).HasName("PRIMARY");

            entity.ToTable("suppliermaterial");

            entity.HasIndex(e => e.SubMaterialId, "sub_material_id");

            entity.Property(e => e.SupplierMaterial1).HasColumnName("supplier_material");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .HasColumnName("phone_number");
            entity.Property(e => e.SubMaterialId).HasColumnName("sub_material_id");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(50)
                .HasColumnName("supplier_name");

            entity.HasOne(d => d.SubMaterial).WithMany(p => p.Suppliermaterials)
                .HasForeignKey(d => d.SubMaterialId)
                .HasConstraintName("suppliermaterial_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.StatusId, "FK6hywckynpmknvf8hnnqldr4mv");

            entity.HasIndex(e => e.PositionId, "fk_users_positions");

            entity.HasIndex(e => e.InforId, "infor_id");

            entity.HasIndex(e => e.RoleId, "role_id");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.InforId).HasColumnName("infor_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.Infor).WithMany(p => p.Users)
                .HasForeignKey(d => d.InforId)
                .HasConstraintName("users_ibfk_3");

            entity.HasOne(d => d.Position).WithMany(p => p.Users)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK6ph6xiiydudp6umjf2xckbbmi");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("users_ibfk_1");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK6hywckynpmknvf8hnnqldr4mv");
        });

        modelBuilder.Entity<Whitelist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("whitelist");

            entity.HasIndex(e => e.ProductId, "FK3ah7d2rv0856t3qmmkclx5vq5");

            entity.HasIndex(e => e.UserId, "FKdra6fv43vgtg0ysv68va5od5e");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Whitelists)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK3ah7d2rv0856t3qmmkclx5vq5");

            entity.HasOne(d => d.User).WithMany(p => p.Whitelists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FKdra6fv43vgtg0ysv68va5od5e");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
