using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WoodWorkshop.Models;

public partial class WoodworkshopContext : DbContext
{
    public WoodworkshopContext()
    {
    }

    public WoodworkshopContext(DbContextOptions<WoodworkshopContext> options)
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

    public virtual DbSet<RequestImage> RequestImages { get; set; }

    public virtual DbSet<RequestProduct> RequestProducts { get; set; }

    public virtual DbSet<RequestProductsSubmaterial> RequestProductsSubmaterials { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StatusJob> StatusJobs { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<StatusProduct> StatusProducts { get; set; }

    public virtual DbSet<StatusUser> StatusUsers { get; set; }

    public virtual DbSet<SubMaterial> SubMaterials { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Whitelist> Whitelists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=WOODWORKSHOP;User Id=sa;Password=Laptrinh@2025;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionType>(entity =>
        {
            entity.HasKey(e => e.ActionTypeId).HasName("PK__action_t__980094F169500BFF");

            entity.ToTable("action_type");

            entity.Property(e => e.ActionTypeId).HasColumnName("action_type_id");
            entity.Property(e => e.ActionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("action_name");
        });

        modelBuilder.Entity<Advancesalary>(entity =>
        {
            entity.HasKey(e => e.AdvanceSalaryId).HasName("PK__advances__B552B8A263735956");

            entity.ToTable("advancesalary");

            entity.Property(e => e.AdvanceSalaryId).HasColumnName("advance_salary_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.IsAdvanceSuccess).HasColumnName("is_advance_success");
            entity.Property(e => e.IsApprove).HasColumnName("is_approve");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.PaymentDate)
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Job).WithMany(p => p.Advancesalaries)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__advancesa__job_i__797309D9");

            entity.HasOne(d => d.User).WithMany(p => p.Advancesalaries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__advancesa__user___787EE5A0");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B4EC3663DD");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<EmployeeMaterial>(entity =>
        {
            entity.HasKey(e => e.EmpMaterialId).HasName("PK__employee__C2CC6ED5F7EBE5F6");

            entity.ToTable("employee_materials");

            entity.Property(e => e.EmpMaterialId).HasColumnName("emp_material_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.ProductSubMaterialId).HasColumnName("product_sub_material_id");
            entity.Property(e => e.RequestProductsSubMaterialsId).HasColumnName("request_products_sub_materials_id");
            entity.Property(e => e.TotalMaterial)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_material");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__employee___emplo__72C60C4A");

            entity.HasOne(d => d.Job).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__employee___job_i__75A278F5");

            entity.HasOne(d => d.ProductSubMaterial).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.ProductSubMaterialId)
                .HasConstraintName("FK__employee___produ__73BA3083");

            entity.HasOne(d => d.RequestProductsSubMaterials).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.RequestProductsSubMaterialsId)
                .HasConstraintName("FK__employee___reque__74AE54BC");
        });

        modelBuilder.Entity<ForgotPassword>(entity =>
        {
            entity.HasKey(e => e.Fpid).HasName("PK__forgot_p__330FD28F2419EDCD");

            entity.ToTable("forgot_password");

            entity.Property(e => e.Fpid).HasColumnName("fpid");
            entity.Property(e => e.ExpirationTime)
                .HasColumnType("datetime")
                .HasColumnName("expiration_time");
            entity.Property(e => e.Otp).HasColumnName("otp");
            entity.Property(e => e.UserUserId).HasColumnName("user_user_id");

            entity.HasOne(d => d.UserUser).WithMany(p => p.ForgotPasswords)
                .HasForeignKey(d => d.UserUserId)
                .HasConstraintName("FK__forgot_pa__user___07C12930");
        });

        modelBuilder.Entity<InformationUser>(entity =>
        {
            entity.HasKey(e => e.InforId).HasName("PK__informat__5C9ACE20C08B95B0");

            entity.ToTable("information_user");

            entity.Property(e => e.InforId).HasColumnName("infor_id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Bank)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bank");
            entity.Property(e => e.BankAccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bank_account_number");
            entity.Property(e => e.CityProvince)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("city_province");
            entity.Property(e => e.District)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("district");
            entity.Property(e => e.Fullname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.HasAccount).HasColumnName("has_account");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.Wards)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("wards");
        });

        modelBuilder.Entity<InputSubMaterial>(entity =>
        {
            entity.HasKey(e => e.InputId).HasName("PK__input_su__038EEFF7F227CE74");

            entity.ToTable("input_sub_material");

            entity.Property(e => e.InputId).HasColumnName("input_id");
            entity.Property(e => e.ActionTypeId).HasColumnName("action_type_id");
            entity.Property(e => e.CodeInput)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("code_input");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.DateInput)
                .HasColumnType("datetime")
                .HasColumnName("date_input");
            entity.Property(e => e.OutPrice)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("out_price");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.SubMaterialId).HasColumnName("sub_material_id");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.ActionType).WithMany(p => p.InputSubMaterials)
                .HasForeignKey(d => d.ActionTypeId)
                .HasConstraintName("FK__input_sub__actio__628FA481");

            entity.HasOne(d => d.SubMaterial).WithMany(p => p.InputSubMaterials)
                .HasForeignKey(d => d.SubMaterialId)
                .HasConstraintName("FK__input_sub__sub_m__619B8048");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__jobs__6E32B6A54119A108");

            entity.ToTable("jobs");

            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.JobIdParent).HasColumnName("job_id_parent");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.JobIdParentNavigation).WithMany(p => p.InverseJobIdParentNavigation)
                .HasForeignKey(d => d.JobIdParent)
                .HasConstraintName("FK__jobs__job_id_par__571DF1D5");

            entity.HasOne(d => d.Product).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__jobs__product_id__5535A963");

            entity.HasOne(d => d.Status).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__jobs__status_id__5629CD9C");

            entity.HasOne(d => d.User).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__jobs__user_id__5441852A");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__material__6BFE1D282C850324");

            entity.ToTable("materials");

            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.MaterialName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("material_name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__46596229E9739A55");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Deposite)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("deposite");
            entity.Property(e => e.InforId).HasColumnName("infor_id");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
            entity.Property(e => e.SpecialOrder).HasColumnName("special_order");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Infor).WithMany(p => p.Orders)
                .HasForeignKey(d => d.InforId)
                .HasConstraintName("FK__orders__infor_id__5AEE82B9");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__orders__status_i__59FA5E80");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__orderdet__3C5A4080EC9EF3A4");

            entity.ToTable("orderdetails");

            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("unit_price");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__orderdeta__order__68487DD7");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__orderdeta__produ__693CA210");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FK__orderdeta__reque__6A30C649");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__position__99A0E7A42845ECD2");

            entity.ToTable("positions");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("position_name");
        });

        modelBuilder.Entity<ProcessProductError>(entity =>
        {
            entity.HasKey(e => e.ProcessProductErrorId).HasName("PK__process___06004BC4F795441D");

            entity.ToTable("process_product_error");

            entity.Property(e => e.ProcessProductErrorId).HasColumnName("process_product_error_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.IsFixed).HasColumnName("is_fixed");
            entity.Property(e => e.JobId).HasColumnName("job_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");
            entity.Property(e => e.Solution)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("solution");

            entity.HasOne(d => d.Job).WithMany(p => p.ProcessProductErrors)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__process_p__job_i__7C4F7684");

            entity.HasOne(d => d.Product).WithMany(p => p.ProcessProductErrors)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__process_p__produ__7D439ABD");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.ProcessProductErrors)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FK__process_p__reque__7E37BEF6");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF580F5ED8B");

            entity.ToTable("products");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(38, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("product_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Status).WithMany(p => p.Products)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__products__status__5165187F");
        });

        modelBuilder.Entity<ProductRequestImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__product___0302EB4A110B2A09");

            entity.ToTable("product_request_images");

            entity.Property(e => e.ProductImageId).HasColumnName("product_image_id");
            entity.Property(e => e.ExtensionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("extension_name");
            entity.Property(e => e.FileOriginalName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_original_name");
            entity.Property(e => e.FullPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("full_path");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.ProductRequestImages)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FK__product_r__reque__04E4BC85");
        });

        modelBuilder.Entity<ProductSubMaterial>(entity =>
        {
            entity.HasKey(e => e.ProductSubMaterialId).HasName("PK__product___F1CBC03E58AB5329");

            entity.ToTable("product_sub_materials");

            entity.Property(e => e.ProductSubMaterialId).HasColumnName("product_sub_material_id");
            entity.Property(e => e.InputId).HasColumnName("input_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSubMaterials)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__product_s__produ__6FE99F9F");
        });

        modelBuilder.Entity<Productimage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__producti__0302EB4AFE3F034A");

            entity.ToTable("productimages");

            entity.Property(e => e.ProductImageId).HasColumnName("product_image_id");
            entity.Property(e => e.ExtensionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("extension_name");
            entity.Property(e => e.FileOriginalName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_original_name");
            entity.Property(e => e.FullPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("full_path");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Productimages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__productim__produ__6D0D32F4");
        });

        modelBuilder.Entity<RefundOrderStatus>(entity =>
        {
            entity.HasKey(e => e.RefundId).HasName("PK__refund_o__897E9EA349363E2D");

            entity.ToTable("refund_order_status");

            entity.Property(e => e.RefundId).HasColumnName("refund_id");
            entity.Property(e => e.RefundName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("refund_name");
        });

        modelBuilder.Entity<RequestImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__request___0302EB4AC4EBB6D8");

            entity.ToTable("request_images");

            entity.Property(e => e.ProductImageId).HasColumnName("product_image_id");
            entity.Property(e => e.ExtensionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("extension_name");
            entity.Property(e => e.FileOriginalName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("file_original_name");
            entity.Property(e => e.FullPath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("full_path");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.RequestId).HasColumnName("request_id");

            entity.HasOne(d => d.Order).WithMany(p => p.RequestImages)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__request_i__order__02084FDA");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestImages)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__request_i__reque__01142BA1");
        });

        modelBuilder.Entity<RequestProduct>(entity =>
        {
            entity.HasKey(e => e.RequestProductId).HasName("PK__request___4FEF66DFC2ED3AD6");

            entity.ToTable("request_products");

            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");
            entity.Property(e => e.CompletionTime).HasColumnName("completion_time");
            entity.Property(e => e.Description)
                .HasMaxLength(900)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.RequestProductName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("request_product_name");
            entity.Property(e => e.StatusId).HasColumnName("status_id");

            entity.HasOne(d => d.Order).WithMany(p => p.RequestProducts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__request_p__order__5EBF139D");

            entity.HasOne(d => d.Status).WithMany(p => p.RequestProducts)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__request_p__statu__5DCAEF64");
        });

        modelBuilder.Entity<RequestProductsSubmaterial>(entity =>
        {
            entity.HasKey(e => e.RequestProductsSubmaterialsId).HasName("PK__request___F393A5551966B57D");

            entity.ToTable("request_products_submaterials");

            entity.Property(e => e.RequestProductsSubmaterialsId).HasColumnName("request_products_submaterials_id");
            entity.Property(e => e.InputId).HasColumnName("input_id");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.RequestProductsSubmaterials)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FK__request_p__reque__656C112C");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CCC3F2F023");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<StatusJob>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__status_j__3683B5317ED9395E");

            entity.ToTable("status_job");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Des)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("des");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status_name");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__status_o__3683B531A2E5ABA4");

            entity.ToTable("status_order");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<StatusProduct>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__status_p__3683B53180D03499");

            entity.ToTable("status_product");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Descriptions)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descriptions");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status_name");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<StatusUser>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__status_u__3683B5311A3E670E");

            entity.ToTable("status_user");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<SubMaterial>(entity =>
        {
            entity.HasKey(e => e.SubMaterialId).HasName("PK__sub_mate__CA29AD7A9930FC8C");

            entity.ToTable("sub_materials");

            entity.Property(e => e.SubMaterialId).HasColumnName("sub_material_id");
            entity.Property(e => e.Code)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.MaterialId).HasColumnName("material_id");
            entity.Property(e => e.SubMaterialName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sub_material_name");

            entity.HasOne(d => d.Material).WithMany(p => p.SubMaterials)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK__sub_mater__mater__4CA06362");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370F759250AE");

            entity.ToTable("users");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.HireDate).HasColumnName("hire_date");
            entity.Property(e => e.InforId).HasColumnName("infor_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");

            entity.HasOne(d => d.Infor).WithMany(p => p.Users)
                .HasForeignKey(d => d.InforId)
                .HasConstraintName("FK__users__infor_id__412EB0B6");

            entity.HasOne(d => d.Position).WithMany(p => p.Users)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__users__position___440B1D61");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__users__role_id__4222D4EF");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__users__status_id__4316F928");
        });

        modelBuilder.Entity<Whitelist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__whitelis__3213E83F3F893449");

            entity.ToTable("whitelist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Whitelists)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__whitelist__produ__0C85DE4D");

            entity.HasOne(d => d.User).WithMany(p => p.Whitelists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__whitelist__user___0D7A0286");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
