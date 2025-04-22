CREATE TABLE status_product (
    status_id INT IDENTITY(1,1) PRIMARY KEY,
    status_name VARCHAR(255),
    type INT,
    descriptions VARCHAR(255)
);

CREATE TABLE roles (
    role_id INT IDENTITY(1,1) PRIMARY KEY,
    role_name VARCHAR(255)
);

CREATE TABLE status_user (
    status_id INT IDENTITY(1,1) PRIMARY KEY,
    status_name VARCHAR(50)
);

CREATE TABLE positions (
    position_id INT IDENTITY(1,1) PRIMARY KEY,
    position_name VARCHAR(255)
);

CREATE TABLE information_user (
    infor_id INT IDENTITY(1,1) PRIMARY KEY,
    phone_number VARCHAR(50),
    fullname VARCHAR(50),
    address VARCHAR(250),
    bank VARCHAR(20),
    bank_account_number VARCHAR(20),
    city_province VARCHAR(30),
    district VARCHAR(30),
    wards VARCHAR(30),
    has_account INT
);

CREATE TABLE users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(255),
    password VARCHAR(255),
    email VARCHAR(255),
    role_id INT,
    status_id INT,
    hire_date DATE,
    infor_id INT,
    position_id INT,
    FOREIGN KEY (infor_id) REFERENCES information_user(infor_id),
    FOREIGN KEY (role_id) REFERENCES roles(role_id),
    FOREIGN KEY (status_id) REFERENCES status_user(status_id),
    FOREIGN KEY (position_id) REFERENCES positions(position_id)
);

CREATE TABLE status_order (
    status_id INT IDENTITY(1,1) PRIMARY KEY,
    status_name VARCHAR(255)
);

CREATE TABLE status_job (
    status_id INT IDENTITY(1,1) PRIMARY KEY,
    status_name VARCHAR(255),
    type INT,
    des VARCHAR(255)
);

CREATE TABLE materials (
    material_id INT IDENTITY(1,1) PRIMARY KEY,
    material_name VARCHAR(255),
    type VARCHAR(255)
);

CREATE TABLE sub_materials (
    sub_material_id INT IDENTITY(1,1) PRIMARY KEY,
    sub_material_name VARCHAR(255),
    material_id INT,
    description VARCHAR(255),
    code VARCHAR(255),
    FOREIGN KEY (material_id) REFERENCES materials(material_id)
);

CREATE TABLE action_type (
    action_type_id INT IDENTITY(1,1) PRIMARY KEY,
    action_name VARCHAR(255)
);

CREATE TABLE products (
    product_id INT IDENTITY(1,1) PRIMARY KEY,
    product_name VARCHAR(255),
    description VARCHAR(255),
    quantity INT,
    price DECIMAL(38,2),
    status_id INT,
    FOREIGN KEY (status_id) REFERENCES status_product(status_id)
);

CREATE TABLE jobs (
    job_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    product_id INT,
    description VARCHAR(255),
    status_id INT,
    job_id_parent INT,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (status_id) REFERENCES status_job(status_id),
    FOREIGN KEY (job_id_parent) REFERENCES jobs(job_id)
);

CREATE TABLE orders (
    order_id INT IDENTITY(1,1) PRIMARY KEY,
    order_date DATETIME,
    status_id INT,
    total_amount DECIMAL(38,2),
    special_order BIT,
    payment_method INT,
    deposite DECIMAL(38,2),
    infor_id INT,
    code VARCHAR(255),
    FOREIGN KEY (status_id) REFERENCES status_order(status_id),
    FOREIGN KEY (infor_id) REFERENCES information_user(infor_id)
);

CREATE TABLE request_products (
    request_product_id INT IDENTITY(1,1) PRIMARY KEY,
    request_product_name VARCHAR(50),
    description VARCHAR(900),
    price DECIMAL(19,4),
    quantity INT,
    completion_time DATE,
    request_id INT,
    status_id INT,
    order_id INT,
    FOREIGN KEY (status_id) REFERENCES status_product(status_id),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

CREATE TABLE input_sub_material (
    input_id INT IDENTITY(1,1) PRIMARY KEY,
    date_input DATETIME,
    quantity DECIMAL(10, 2),
    unit_price DECIMAL(38,2),
    sub_material_id INT,
    action_type_id INT,
    out_price DECIMAL(38,2),
    create_date DATETIME,
    code_input VARCHAR(255),
    FOREIGN KEY (sub_material_id) REFERENCES sub_materials(sub_material_id),
    FOREIGN KEY (action_type_id) REFERENCES action_type(action_type_id)
);

CREATE TABLE request_products_submaterials (
    request_products_submaterials_id INT IDENTITY(1,1) PRIMARY KEY,
    request_product_id INT,
    quantity DECIMAL(10, 2),
    input_id INT,
    FOREIGN KEY (request_product_id) REFERENCES request_products(request_product_id)
);

CREATE TABLE orderdetails (
    order_detail_id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT,
    product_id INT,
    quantity INT,
    unit_price DECIMAL(38,2),
    request_product_id INT,
    FOREIGN KEY (order_id) REFERENCES orders(order_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (request_product_id) REFERENCES request_products(request_product_id)
);

CREATE TABLE productimages (
    product_image_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT,
    extension_name VARCHAR(255),
    file_original_name VARCHAR(255),
    full_path VARCHAR(255),
    image VARCHAR(255),
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE product_sub_materials (
    product_sub_material_id INT IDENTITY(1,1) PRIMARY KEY,
    product_id INT,
    quantity DECIMAL(10, 2),
    input_id INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id)
);

CREATE TABLE employee_materials (
    emp_material_id INT IDENTITY(1,1) PRIMARY KEY,
    employee_id INT,
    product_sub_material_id INT,
    request_products_sub_materials_id INT,
    total_material DECIMAL(10, 2),
    job_id INT,
    FOREIGN KEY (employee_id) REFERENCES users(user_id),
    FOREIGN KEY (product_sub_material_id) REFERENCES product_sub_materials(product_sub_material_id),
    FOREIGN KEY (request_products_sub_materials_id) REFERENCES request_products_submaterials(request_products_submaterials_id),
    FOREIGN KEY (job_id) REFERENCES jobs(job_id)
);

CREATE TABLE advancesalary (
    advance_salary_id INT IDENTITY(1,1) PRIMARY KEY,
    date DATETIME,
    amount DECIMAL(38,2),
    user_id INT,
    is_advance_success BIT,
    code VARCHAR(255),
    is_approve BIT,
    payment_date DATETIME,
    job_id INT,
    FOREIGN KEY (user_id) REFERENCES users(user_id),
    FOREIGN KEY (job_id) REFERENCES jobs(job_id)
);

CREATE TABLE process_product_error (
    process_product_error_id INT IDENTITY(1,1) PRIMARY KEY,
    code VARCHAR(255),
    description VARCHAR(255),
    is_fixed BIT,
    solution VARCHAR(255),
    job_id INT,
    product_id INT,
    request_product_id INT,
    quantity INT,
    FOREIGN KEY (job_id) REFERENCES jobs(job_id),
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (request_product_id) REFERENCES request_products(request_product_id)
);

CREATE TABLE request_images (
    product_image_id INT IDENTITY(1,1) PRIMARY KEY,
    extension_name VARCHAR(255),
    file_original_name VARCHAR(255),
    full_path VARCHAR(255),
    image VARCHAR(255),
    request_id INT,
    order_id INT,
    FOREIGN KEY (request_id) REFERENCES request_products(request_product_id),
    FOREIGN KEY (order_id) REFERENCES orders(order_id)
);

CREATE TABLE product_request_images (
    product_image_id INT IDENTITY(1,1) PRIMARY KEY,
    extension_name VARCHAR(255),
    file_original_name VARCHAR(255),
    full_path VARCHAR(255),
    image VARCHAR(255),
    request_product_id INT,
    FOREIGN KEY (request_product_id) REFERENCES request_products(request_product_id)
);

CREATE TABLE forgot_password (
    fpid INT IDENTITY(1,1) PRIMARY KEY,
    expiration_time DATETIME,
    otp INT,
    user_user_id INT,
    FOREIGN KEY (user_user_id) REFERENCES users(user_id)
);

CREATE TABLE refund_order_status (
    refund_id INT IDENTITY(1,1) PRIMARY KEY,
    refund_name VARCHAR(255)
);

CREATE TABLE whitelist (
    id BIGINT IDENTITY(1,1) PRIMARY KEY,
    product_id INT,
    user_id INT,
    FOREIGN KEY (product_id) REFERENCES products(product_id),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE categories (
    category_id INT IDENTITY(1,1) PRIMARY KEY,
    category_name VARCHAR(255)
);