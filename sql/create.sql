USE dbchapeau01;

-- TABLES

-- Create a new table called 'tables'
CREATE TABLE tables
(
  table_id INT NOT NULL PRIMARY KEY,
  [state] VARCHAR(25) NOT NULL,
  capacity INT NOT NULL
);
GO

-- EMPLOYEES

-- Create a new table called 'roles'
CREATE TABLE roles
(
  role_id INT NOT NULL PRIMARY KEY,
  [name] NVARCHAR(60) NOT NULL
);
GO

-- Create a new table called 'employees'
CREATE TABLE employees
(
  employee_id INT NOT NULL PRIMARY KEY,
  first_name NVARCHAR(60) NOT NULL,
  last_name NVARCHAR(60) NOT NULL,
  [password] INT NOT NULL,
  [role] INT NOT NULL REFERENCES roles(role_id)
);
GO

-- MENUS

-- Create a new table called 'menus'
CREATE TABLE menus
(
  menu_id INT NOT NULL PRIMARY KEY,
  [name] NVARCHAR(60) NOT NULL,
  [start_time] TIME,
  [end_time] TIME
);
GO

-- Create a new table called 'categories'
CREATE TABLE categories
(
  category_id INT IDENTITY(1,1) PRIMARY KEY,
  [name] NVARCHAR(60) NOT NULL,
  menu_id INT NOT NULL REFERENCES menus(menu_id)
);
GO

-- ITEMS

-- Create a new table called 'tax_categories'
CREATE TABLE tax_categories
(
  tax_category_id INT NOT NULL PRIMARY KEY,
  [name] VARCHAR(30) NOT NULL,
  vat_percentage INT NOT NULL
);
GO

-- Create a new table called 'items'
CREATE TABLE items
(
  item_id INT IDENTITY(1,1) PRIMARY KEY,
  [name] NVARCHAR(80) NOT NULL,
  stock INT DEFAULT 0,
  price SMALLMONEY NOT NULL,
  menu_id INT NOT NULL REFERENCES menus(menu_id),
  tax_category INT NOT NULL REFERENCES tax_categories(tax_category_id),
  category INT NOT NULL REFERENCES categories(category_id)
);
GO

-- ORDERS

-- Create a new table called 'orders'
CREATE TABLE orders
(
  order_id INT IDENTITY(1,1) PRIMARY KEY,
  table_id INT NOT NULL REFERENCES tables(table_id),
  employee_id INT NOT NULL REFERENCES employees(employee_id),
  is_payed BIT DEFAULT 0
);
GO

-- Create a new table called 'orders_items'
CREATE TABLE orders_items
(
  order_item_id INT IDENTITY(1,1) PRIMARY KEY,
  order_id INT NOT NULL REFERENCES orders(order_id),
  item_id INT NOT NULL REFERENCES items(item_id),
  taken_at DATETIME NOT NULL,
  [state] VARCHAR(50) NOT NULL,
  state_time DATETIME NOT NULL,
  quantity INT NOT NULL,
  comment NVARCHAR(600)
);
GO

-- BILLS

-- Create a new table called 'bills'
CREATE TABLE bills
(
  bill_id INT IDENTITY(1,1) PRIMARY KEY,
  tip SMALLMONEY DEFAULT 0,
  order_price SMALLMONEY NOT NULL,
  payment_method NVARCHAR(60) NOT NULL,
  [date] DATETIME NOT NULL,
  feedback NVARCHAR(600),
  order_id INT NOT NULL REFERENCES orders(order_id)
);
GO
