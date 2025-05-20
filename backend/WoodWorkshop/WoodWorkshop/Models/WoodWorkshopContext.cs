using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WoodWorkshop.Models;

public partial class WoodWorkshopContext : DbContext
{
    public WoodWorkshopContext()
    {
    }

    public WoodWorkshopContext(DbContextOptions<WoodWorkshopContext> options)
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
        => optionsBuilder.UseSqlServer("Server=DESKTOP-LF8LV29\\SQLEXPRESS;Database=WoodWorkshop;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionType>(entity =>
        {
            entity.HasKey(e => e.ActionTypeId).HasName("PK__action_t__980094F108C8934F");

            entity.ToTable("action_type");

            entity.Property(e => e.ActionTypeId).HasColumnName("action_type_id");
            entity.Property(e => e.ActionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("action_name");
        });

        modelBuilder.Entity<Advancesalary>(entity =>
        {
            entity.HasKey(e => e.AdvanceSalaryId).HasName("PK__advances__B552B8A2417BD5E0");

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
                .HasConstraintName("FK__advancesa__job_i__0B91BA14");

            entity.HasOne(d => d.User).WithMany(p => p.Advancesalaries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__advancesa__user___0A9D95DB");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__categori__D54EE9B4E4AF63AF");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<EmployeeMaterial>(entity =>
        {
            entity.HasKey(e => e.EmpMaterialId).HasName("PK__employee__C2CC6ED52D0E14B7");

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
                .HasConstraintName("FK__employee___emplo__04E4BC85");

            entity.HasOne(d => d.Job).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK__employee___job_i__07C12930");

            entity.HasOne(d => d.ProductSubMaterial).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.ProductSubMaterialId)
                .HasConstraintName("FK__employee___produ__05D8E0BE");

            entity.HasOne(d => d.RequestProductsSubMaterials).WithMany(p => p.EmployeeMaterials)
                .HasForeignKey(d => d.RequestProductsSubMaterialsId)
                .HasConstraintName("FK__employee___reque__06CD04F7");
        });

        modelBuilder.Entity<ForgotPassword>(entity =>
        {
            entity.HasKey(e => e.Fpid).HasName("PK__forgot_p__330FD28FC7BAE32B");

            entity.ToTable("forgot_password");

            entity.Property(e => e.Fpid).HasColumnName("fpid");
            entity.Property(e => e.ExpirationTime)
                .HasColumnType("datetime")
                .HasColumnName("expiration_time");
            entity.Property(e => e.Otp).HasColumnName("otp");
            entity.Property(e => e.UserUserId).HasColumnName("user_user_id");

            entity.HasOne(d => d.UserUser).WithMany(p => p.ForgotPasswords)
                .HasForeignKey(d => d.UserUserId)
                .HasConstraintName("FK__forgot_pa__user___19DFD96B");
        });

        modelBuilder.Entity<InformationUser>(entity =>
        {
            entity.HasKey(e => e.InforId).HasName("PK__informat__5C9ACE2045CAF035");

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
            entity.HasKey(e => e.InputId).HasName("PK__input_su__038EEFF79D0DE7B4");

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
                .HasConstraintName("FK__input_sub__actio__74AE54BC");

            entity.HasOne(d => d.SubMaterial).WithMany(p => p.InputSubMaterials)
                .HasForeignKey(d => d.SubMaterialId)
                .HasConstraintName("FK__input_sub__sub_m__73BA3083");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PK__jobs__6E32B6A55A509E1A");

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
                .HasConstraintName("FK__jobs__job_id_par__693CA210");

            entity.HasOne(d => d.Product).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__jobs__product_id__6754599E");

            entity.HasOne(d => d.Status).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__jobs__status_id__68487DD7");

            entity.HasOne(d => d.User).WithMany(p => p.Jobs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__jobs__user_id__66603565");
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__material__6BFE1D284A757CD9");

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
            entity.HasKey(e => e.OrderId).HasName("PK__orders__4659622987B2BB78");

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
                .HasConstraintName("FK__orders__infor_id__6D0D32F4");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__orders__status_i__6C190EBB");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__orderdet__3C5A4080B73F7F66");

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
                .HasConstraintName("FK__orderdeta__order__7A672E12");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__orderdeta__produ__7B5B524B");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FK__orderdeta__reque__7C4F7684");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__position__99A0E7A4C18EA105");

            entity.ToTable("positions");

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.PositionName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("position_name");
        });

        modelBuilder.Entity<ProcessProductError>(entity =>
        {
            entity.HasKey(e => e.ProcessProductErrorId).HasName("PK__process___06004BC484D9946D");

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
                .HasConstraintName("FK__process_p__job_i__0E6E26BF");

            entity.HasOne(d => d.Product).WithMany(p => p.ProcessProductErrors)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__process_p__produ__0F624AF8");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.ProcessProductErrors)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FK__process_p__reque__10566F31");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__products__47027DF5B6B721EB");

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
                .HasConstraintName("FK__products__status__6383C8BA");
        });

        modelBuilder.Entity<ProductRequestImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__product___0302EB4AC493544C");

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
                .HasConstraintName("FK__product_r__reque__17036CC0");
        });

        modelBuilder.Entity<ProductSubMaterial>(entity =>
        {
            entity.HasKey(e => e.ProductSubMaterialId).HasName("PK__product___F1CBC03EF37BD08A");

            entity.ToTable("product_sub_materials");

            entity.Property(e => e.ProductSubMaterialId).HasColumnName("product_sub_material_id");
            entity.Property(e => e.InputId).HasColumnName("input_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSubMaterials)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__product_s__produ__02084FDA");
        });

        modelBuilder.Entity<Productimage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__producti__0302EB4A5ECF652C");

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
                .HasConstraintName("FK__productim__produ__7F2BE32F");
        });

        modelBuilder.Entity<RefundOrderStatus>(entity =>
        {
            entity.HasKey(e => e.RefundId).HasName("PK__refund_o__897E9EA3707BD0AD");

            entity.ToTable("refund_order_status");

            entity.Property(e => e.RefundId).HasColumnName("refund_id");
            entity.Property(e => e.RefundName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("refund_name");
        });

        modelBuilder.Entity<RequestImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__request___0302EB4A2A38519F");

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
                .HasConstraintName("FK__request_i__order__14270015");

            entity.HasOne(d => d.Request).WithMany(p => p.RequestImages)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK__request_i__reque__1332DBDC");
        });

        modelBuilder.Entity<RequestProduct>(entity =>
        {
            entity.HasKey(e => e.RequestProductId).HasName("PK__request___4FEF66DF8B7F09FF");

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
                .HasConstraintName("FK__request_p__order__70DDC3D8");

            entity.HasOne(d => d.Status).WithMany(p => p.RequestProducts)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__request_p__statu__6FE99F9F");
        });

        modelBuilder.Entity<RequestProductsSubmaterial>(entity =>
        {
            entity.HasKey(e => e.RequestProductsSubmaterialsId).HasName("PK__request___F393A55539FA4BC3");

            entity.ToTable("request_products_submaterials");

            entity.Property(e => e.RequestProductsSubmaterialsId).HasColumnName("request_products_submaterials_id");
            entity.Property(e => e.InputId).HasColumnName("input_id");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("quantity");
            entity.Property(e => e.RequestProductId).HasColumnName("request_product_id");

            entity.HasOne(d => d.RequestProduct).WithMany(p => p.RequestProductsSubmaterials)
                .HasForeignKey(d => d.RequestProductId)
                .HasConstraintName("FK__request_p__reque__778AC167");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CC2138E606");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role_name");
        });

        modelBuilder.Entity<StatusJob>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__status_j__3683B5317DABE2AA");

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
            entity.HasKey(e => e.StatusId).HasName("PK__status_o__3683B53126C92BFB");

            entity.ToTable("status_order");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<StatusProduct>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__status_p__3683B5319ADC125F");

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
            entity.HasKey(e => e.StatusId).HasName("PK__status_u__3683B531A430C0D0");

            entity.ToTable("status_user");

            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status_name");
        });

        modelBuilder.Entity<SubMaterial>(entity =>
        {
            entity.HasKey(e => e.SubMaterialId).HasName("PK__sub_mate__CA29AD7AC4A5FB74");

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
                .HasConstraintName("FK__sub_mater__mater__5EBF139D");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370F661265BA");

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
                .HasConstraintName("FK__users__infor_id__534D60F1");

            entity.HasOne(d => d.Position).WithMany(p => p.Users)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__users__position___5629CD9C");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__users__role_id__5441852A");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__users__status_id__5535A963");
        });

        modelBuilder.Entity<Whitelist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__whitelis__3213E83FAF46B9DB");

            entity.ToTable("whitelist");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Whitelists)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__whitelist__produ__1EA48E88");

            entity.HasOne(d => d.User).WithMany(p => p.Whitelists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__whitelist__user___1F98B2C1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
